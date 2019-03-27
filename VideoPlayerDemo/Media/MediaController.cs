using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using VideoPlayerDemo.Media.Callback;
using Java.Lang;
using Java.Util;
using VideoPlayerDemo;
using static Android.Widget.SeekBar;

namespace VideoPlayerDemo.Media
{
    public class MediaController : FrameLayout, IDanmukuSwitchListener, IOnSeekBarChangeListener, IVideoBackListener
    {
        private static int sDefaultTimeout = 3000;
        private static int FADE_OUT = 1;
        private static int SHOW_PROGRESS = 2;
        private Context mContext;
        private PopupWindow mWindow;
        private int mAnimStyle;
        private View mAnchor;
        private View mRoot;
        private SeekBar mProgress;
        private TextView mEndTime, mCurrentTime;
        private TextView mTitleView;
        private OutlineTextView mInfoView;
        private string mTitle;
        private long mDuration;
        private bool mShowing;
        private bool mDragging;
        private bool mInstantSeeking = true;
        private bool mFromXml = false;
        private ImageButton mPauseButton;
        private AudioManager mAM;
        private OnShownListener mShownListener;
        private OnHiddenListener mHiddenListener;
        private bool mDanmakuShow = false;
        private ImageView mBack;
        private ImageView mTvPlay;
        private Handler mHandler;
        private Runnable lastRunnable;

        private IMediaPlayerListener mPlayer;
        private IVideoBackListener mVideoBackListener;
        

        //private IDanmukuSwitchListener mDanmukuSwitchListener;
        //private IOnClickListener mPauseListener;
        //private IOnSeekBarChangeListener mSeekListener;

        //public void SetDanmakuSwitchListener(IDanmukuSwitchListener danmukuSwitchListener)
        //{
        //    this.mDanmukuSwitchListener = danmukuSwitchListener;
        //}

        public void SetVideoBackEvent(IVideoBackListener videoBackListener)
        {
            this.mVideoBackListener = videoBackListener;
        }



        public MediaController(Context context, IAttributeSet attrs)
                : base(context, attrs)
        {
            mRoot = this;
            mFromXml = true;
            InitController(context);
        }

        public MediaController(Context context)
                    : base(context)
        {
            if (!mFromXml && InitController(context))
            {
                InitFloatingWindow();
            }
        }

        private bool InitController(Context context)
        {
            mContext = context;

            mAM = (AudioManager)mContext.GetSystemService(Context.AudioService);

            mHandler = new Handler((Message msg) =>
            {
                long pos;
                switch (msg.What)
                {
                    case 1:
                        Hide();
                        break;
                    case 2:
                        pos = SetProgress();
                        if (!mDragging && mShowing)
                        {
                            msg = mHandler.ObtainMessage(msg.What);
                            mHandler.SendMessageDelayed(msg, 1000 - (pos % 1000));
                            UpdatePausePlay();
                        }
                        break;
                }
            });

            //mPauseListener = new mOnClickListener(this);

            //mPauseListener = new mOnClickListener(() => { mPauseListener.OnClick(this); }, this);
            //mBack.SetOnClickListener();
            return true;
        }
        private static string GenerateTime(long position)
        {
            int totalSeconds = (int)((position / 1000.0) + 0.5);
            int seconds = totalSeconds % 60;
            int minutes = (totalSeconds / 60) % 60;
            int hours = totalSeconds / 3600;
            if (hours > 0)
            {
                return string.Format("{0}:{1}:{2}", hours, minutes,
                        seconds);
            }
            else
            {
                return string.Format("{0}:{1}", minutes, seconds);
            }
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            if (mRoot != null)
            {
                InitControllerView(mRoot);
            }
        }


        private void InitFloatingWindow()
        {
            mWindow = new PopupWindow(mContext);
            mWindow.Focusable = false;
            mWindow.SetBackgroundDrawable(null);
            mWindow.OutsideTouchable = true;
            mAnimStyle = Android.Resource.Style.Animation;
        }


        /**
         * 设置VideoView
         */
        public void SetAnchorView(View view)
        {
            mAnchor = view;
            if (!mFromXml)
            {
                RemoveAllViews();
                mRoot = MakeControllerView();
                mWindow.ContentView = mRoot;
                mWindow.Width = view.Width;// LayoutParams.MatchParent;
                mWindow.Height = view.Height;// LayoutParams.WrapContent;
                //mWindow
            }
            InitControllerView(mRoot);
        }


        /**
         * 创建视图包含小部件,控制回放
         */
        protected View MakeControllerView()
        {
            return LayoutInflater.From(mContext).Inflate(Resource.Layout.layout_media_controller, this, false);
        }


        private void InitControllerView(View v)
        {
            mPauseButton = (ImageButton)v.FindViewById(Resource.Id.media_controller_play_pause);
            mTvPlay = (ImageView)v.FindViewById(Resource.Id.media_controller_tv_play);

            //mPauseButton.RequestFocus();
            //mPauseButton.Click += delegate {
            //    DoPauseResume();
            //    Show(sDefaultTimeout);
            //};
            if (mPauseButton != null && mTvPlay != null)
            {
                mPauseButton.RequestFocus();
                mPauseButton.Clickable = true;
                mPauseButton.Click += delegate
                {
                    DoPauseResume();
                    Show(sDefaultTimeout);
                };// .SetOnClickListener(this);

                mTvPlay.RequestFocus();
                mTvPlay.Clickable = true;
                mTvPlay.Click += delegate
                {
                    DoPauseResume();
                    Show(sDefaultTimeout);
                };//.SetOnClickListener(this);
            }

            mProgress = (SeekBar)v.FindViewById(Resource.Id.media_controller_seekbar);
            if (mProgress != null)
            {
                //if (mProgress is SeekBar)
                //{
                //    SeekBar seeker = (SeekBar)mProgress;

                //    //#region ??? 黑人问号
                //    //mSeekListener = new SeekBarChangeListenerModel(mDuration, mShowing, mDragging, mInstantSeeking, mFromXml, mHandler,
                //    //                        lastRunnable, mPlayer, mInfoView, mEndTime, mCurrentTime, mAM, mProgress, this);

                //    //#endregion

                //    seeker.SetOnSeekBarChangeListener(this);
                //    seeker.ThumbOffset = 1;// SetThumbOffset(1);
                //}

                mProgress.SetOnSeekBarChangeListener(this);
                mProgress.ThumbOffset = 1;// SetThumbOffset(1);
                mProgress.Max = 1000;// SetMax(1000);
            }

            mEndTime = (TextView)v.FindViewById(Resource.Id.media_controller_time_total);
            mCurrentTime = (TextView)v.FindViewById(Resource.Id.media_controller_time_current);
            mTitleView = (TextView)v.FindViewById(Resource.Id.media_controller_title);
            if (mTitleView != null)
            {
                mTitleView.Text = mTitle;//  setText(mTitle);
            }
            //LinearLayout mDanmakuLayout = (LinearLayout)v.FindViewById(Resource.Id.media_controller_danmaku_layout);
            //ImageView mDanmakuImage = (ImageView)v.FindViewById(Resource.Id.media_controller_danmaku_switch);
            //TextView mDanmakuText = (TextView)v.FindViewById(Resource.Id.media_controller_danmaku_text);

            //mDanmakuLayout.setOnClickListener(v1-> {
            //    if (mDanmakuShow)
            //    {
            //        mDanmakuImage.setImageResource(R.drawable.bili_player_danmaku_is_open);
            //        mDanmakuText.setText("弹幕开");
            //        mDanmukuSwitchListener.setDanmakuShow(true);
            //        mDanmakuShow = false;
            //    }
            //    else
            //    {
            //        mDanmakuImage.setImageResource(R.drawable.bili_player_danmaku_is_closed);
            //        mDanmakuText.setText("弹幕关");
            //        mDanmukuSwitchListener.setDanmakuShow(false);
            //        mDanmakuShow = true;
            //    }
            //});

            mBack = (ImageView)v.FindViewById(Resource.Id.media_controller_back);
            mBack.Click += delegate
            {
                DoPauseResume();
                Show(sDefaultTimeout);
                mVideoBackListener.Back();
            };
            //.SetOnClickListener(this);


        }


        public void SetMediaPlayer(IMediaPlayerListener player)
        {
            mPlayer = player;
            UpdatePausePlay();
        }


        /**
         * 拖动seekBar时回调
         */
        public void SetInstantSeeking(bool seekWhenDragging)
        {
            mInstantSeeking = seekWhenDragging;
        }


        public void Show()
        {
            Show(sDefaultTimeout);
        }


        /**
         * 设置播放的文件名称
         */
        public void SetTitle(string name)
        {
            mTitle = name;
            if (mTitleView != null)
            {
                mTitleView.Text = mTitle;// (mTitle);
            }
        }


        /**
         * 设置MediaController持有的View
         */
        public void SetInfoView(OutlineTextView v)
        {
            mInfoView = v;
        }


        private void DisableUnsupportedButtons()
        {
            if (mPauseButton != null && mTvPlay != null && !mPlayer.CanPause())
            {
                mPauseButton.Enabled = false;//.setEnabled(false);
                mTvPlay.Enabled = false;// setEnabled(false);
            }
        }


        /**
         * 改变控制器的动画风格的资源
         */
        public void SetAnimationStyle(int animationStyle)
        {
            mAnimStyle = animationStyle;
        }

        /**
         * 在屏幕上显示控制器
         */
        public void Show(int timeout)
        {
            if (!mShowing && mAnchor != null && mAnchor.WindowToken != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.IceCreamSandwich)
                {
                    mAnchor.SystemUiVisibility = StatusBarVisibility.Visible;// View.SystemUiFlagVisible;
                }
                if (mPauseButton != null && mTvPlay != null)
                {
                    mPauseButton.RequestFocus();
                    mTvPlay.RequestFocus();
                }
                DisableUnsupportedButtons();
                if (mFromXml)
                {
                    mAnchor.Visibility = ViewStates.Visible;

                }
                else
                {
                    int[] location = new int[2];
                    mAnchor.GetLocationOnScreen(location);
                    Rect anchorRect = new Rect(location[0], location[1],
                            location[0] + mAnchor.Width, location[1]
                            + mAnchor.Height);
                    mWindow.AnimationStyle = mAnimStyle;// m SetAnimationStyle(mAnimStyle);
                    mWindow.ShowAtLocation(mAnchor, GravityFlags.Bottom, anchorRect.Left, 0);
                }
                mShowing = true;
                if (mShownListener != null)
                {
                    mShownListener.OnShown();
                }
            }
            UpdatePausePlay();
            mHandler.SendEmptyMessage(SHOW_PROGRESS);
            if (timeout != 0)
            {
                mHandler.RemoveMessages(FADE_OUT);
                mHandler.SendMessageDelayed(mHandler.ObtainMessage(FADE_OUT),
                        timeout);
            }
        }


        public bool IsShowing()
        {
            return mShowing;
        }


        public void Hide()
        {
            if (mAnchor == null)
            {
                return;
            }
            if (mShowing)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.IceCreamSandwich)
                {
                    mAnchor.SystemUiVisibility = StatusBarVisibility.Hidden; // SetSystemUiVisibility(View.SYSTEM_UI_FLAG_HIDE_NAVIGATION);
                }
                try
                {
                    mHandler.RemoveMessages(SHOW_PROGRESS);
                    if (mFromXml)
                    {
                        mAnchor.Visibility = ViewStates.Gone;

                        //SetVisibility(ViewStates.Gone);
                    }
                    else
                    {
                        mWindow.Dismiss();
                    }
                }
                catch (IllegalArgumentException ex)
                {
                    Log.Debug("Error", "MediaController already removed" + ex.Message);

                }

                mShowing = false;
                if (mHiddenListener != null)
                {
                    mHiddenListener.OnHidden();
                }
            }
        }

        public void SetOnShownListener(OnShownListener l)
        {
            mShownListener = l;
        }


        public void SetOnHiddenListener(OnHiddenListener l)
        {
            mHiddenListener = l;
        }


        private long SetProgress()
        {
            if (mPlayer == null || mDragging)
            {
                return 0;
            }
            int position = mPlayer.GetCurrentPosition();
            int duration = mPlayer.GetDuration();
            if (mProgress != null)
            {
                if (duration > 0)
                {
                    long pos = 1000L * position / duration;
                    mProgress.Progress = (int)pos;// SetProgress((int)pos);
                }
                int percent = mPlayer.GetBufferPercentage();
                mProgress.SecondaryProgress = percent * 10;
            }
            mDuration = duration;
            if (mEndTime != null)
            {
                mEndTime.Text = GenerateTime(mDuration);
            }
            if (mCurrentTime != null)
            {
                mCurrentTime.Text = GenerateTime(position);
            }
            return position;
        }


        public override bool OnTouchEvent(MotionEvent e)
        {
            Show(sDefaultTimeout);
            return true;
        }


        public override bool OnTrackballEvent(MotionEvent ev)
        {
            Show(sDefaultTimeout);
            return false;
        }


        public override bool DispatchKeyEvent(KeyEvent e)
        {
            int keyCode = Convert.ToInt32(e.KeyCode);// GetKeyCode();
            if (e.RepeatCount == 0
                    && (keyCode == (int)Keycode.Headsethook
                    || keyCode == (int)Keycode.MediaPlayPause || keyCode == (int)Keycode.Space))
            {
                DoPauseResume();
                Show(sDefaultTimeout);
                if (mPauseButton != null && mTvPlay != null)
                {
                    mPauseButton.RequestFocus();
                    mTvPlay.RequestFocus();
                }
                return true;
            }
            else if (keyCode == (int)Keycode.MediaStop)
            {
                if (mPlayer.IsPlaying())
                {
                    mPlayer.Pause();
                    UpdatePausePlay();
                }
                return true;
            }
            else if (keyCode == (int)Keycode.Back
                  || keyCode == (int)Keycode.Menu)
            {
                Hide();
                return true;
            }
            else
            {
                Show(sDefaultTimeout);
            }
            return base.DispatchKeyEvent(e);
        }


        private void UpdatePausePlay()
        {
            if (mRoot == null || mPauseButton == null || mTvPlay == null)
            {
                return;
            }
            if (mPlayer.IsPlaying())
            {
                mPauseButton.SetImageResource(Resource.Drawable.bili_player_play_can_pause);
                mTvPlay.SetImageResource(Resource.Drawable.ic_tv_stop);
            }
            else
            {
                mPauseButton.SetImageResource(Resource.Drawable.bili_player_play_can_play);
                mTvPlay.SetImageResource(Resource.Drawable.ic_tv_play);
            }
        }


        private void DoPauseResume()
        {
            if (mPlayer.IsPlaying())
            {
                mPlayer.Pause();
            }
            else
            {
                mPlayer.Start();
            }
            UpdatePausePlay();
        }


        public void SetEnabled(bool enabled)
        {
            if (mPauseButton != null)
            {
                mPauseButton.Enabled = enabled;//.SetEnabled(enabled);
            }
            if (mTvPlay != null)
            {
                mTvPlay.Enabled = enabled;// setEnabled(enabled);
            }
            if (mProgress != null)
            {
                mProgress.Enabled = enabled;
            }
            DisableUnsupportedButtons();
            base.Enabled = enabled;
        }

        //public void Start()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Pause()
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetDuration()
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetCurrentPosition()
        //{
        //    throw new NotImplementedException();
        //}

        //public void SeekTo(long pos)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsPlaying()
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetBufferPercentage()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CanPause()
        //{
        //    throw new NotImplementedException();
        //}

        public void setDanmakuShow(bool isShow)
        {
            return;
            //throw new NotImplementedException();
        }
        
        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (!fromUser)
            {
                return;
            }
            long newposition = (mDuration * progress) / 1000;
            string time = GenerateTime(newposition);
            if (mInstantSeeking)
            {
                mHandler.RemoveCallbacks(lastRunnable);

                lastRunnable = new Runnable(() => mPlayer.SeekTo(newposition));

                mHandler.PostDelayed(lastRunnable, 200);
            }
            if (mInfoView != null)
            {
                mInfoView.Text = time;//.setText(time);
            }
            if (mCurrentTime != null)
            {
                mCurrentTime.Text = time;//.setText(time);
            }
            //throw new NotImplementedException();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            mDragging = true;
            Show(3600000);
            mHandler.RemoveMessages(SHOW_PROGRESS);
            if (mInstantSeeking)
            {
                mAM.SetStreamMute(Stream.Music, true);
            }
            if (mInfoView != null)
            {
                mInfoView.Text = "";// .setText("");
                mInfoView.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
            }
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            if (!mInstantSeeking)
            {
                mPlayer.SeekTo((mDuration * mProgress.Progress) / 1000);
            }
            if (mInfoView != null)
            {
                mInfoView.Text = ""; //.setText("");
                mInfoView.Visibility = ViewStates.Gone;// setVisibility(View.GONE);
            }
            Show(sDefaultTimeout);
            mHandler.RemoveMessages(SHOW_PROGRESS);
            mAM.SetStreamMute(Stream.Music, false);
            mDragging = false;
            mHandler.SendEmptyMessageDelayed(SHOW_PROGRESS, 1000);
        }

        public void Back()
        {
            DoPauseResume();
            Show(sDefaultTimeout);
        }

        public interface OnShownListener
        {
            void OnShown();
        }

        public interface OnHiddenListener
        {
            void OnHidden();
        }

        #region Old Listener
        //public class mOnClickListener : Java.Lang.Object, View.IOnClickListener
        //{
        //    private MediaController m_Contorller;

        //    public mOnClickListener(MediaController _mContorller)
        //    {
        //        m_Contorller = _mContorller;
        //    }
        //    public mOnClickListener(Action a, MediaController _mContorller)
        //    {
        //        m_Contorller = _mContorller;
        //    }
        //    public void OnClick(View v)
        //    {
        //        m_Contorller.DoPauseResume();
        //        m_Contorller.Show(sDefaultTimeout);
        //    }
        //}

        //public class SeekBarChangeListenerModel : Java.Lang.Object, IOnSeekBarChangeListener
        //{
        //    private long mDuration;
        //    private bool mShowing;
        //    private bool mDragging;
        //    private bool mInstantSeeking = true;
        //    private bool mFromXml = false;
        //    private Handler mHandler;
        //    private Runnable lastRunnable;
        //    private IMediaPlayerListener mPlayer;
        //    private OutlineTextView mInfoView;
        //    private TextView mEndTime, mCurrentTime;
        //    private AudioManager mAM;
        //    private ProgressBar mProgress;
        //    private MediaController m_Contorller;

        //    public SeekBarChangeListenerModel(long _mDuration, bool _mShowing, bool _mDragging,
        //                                      bool _mInstantSeeking, bool _mFromXml, Handler _mHandler,
        //                                      Runnable _lastRunnable, IMediaPlayerListener _mPlayer, OutlineTextView _mInfoView,
        //                                        TextView _mEndTime, TextView _mCurrentTime, AudioManager _mAM, ProgressBar _mProgress, MediaController _mContorller)
        //    {
        //        mDuration = _mDuration;
        //        mShowing = _mShowing;
        //        mDragging = _mDragging;
        //        mInstantSeeking = _mInstantSeeking;
        //        mFromXml = _mFromXml;
        //        mHandler = _mHandler;
        //        lastRunnable = _lastRunnable;
        //        mPlayer = _mPlayer;
        //        mInfoView = _mInfoView;
        //        mEndTime = _mEndTime;
        //        mCurrentTime = _mCurrentTime;
        //        mAM = _mAM;
        //        mProgress = _mProgress;
        //        m_Contorller = _mContorller;
        //    }

        //    public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        //    {
        //        if (!fromUser)
        //        {
        //            return;
        //        }
        //        long newposition = (mDuration * progress) / 1000;
        //        string time = GenerateTime(newposition);
        //        if (mInstantSeeking)
        //        {
        //            mHandler.RemoveCallbacks(lastRunnable);

        //            lastRunnable = new Runnable(() => mPlayer.SeekTo(newposition));

        //            mHandler.PostDelayed(lastRunnable, 200);
        //        }
        //        if (mInfoView != null)
        //        {
        //            mInfoView.Text = time;//.setText(time);
        //        }
        //        if (mCurrentTime != null)
        //        {
        //            mCurrentTime.Text = time;//.setText(time);
        //        }
        //        //throw new NotImplementedException();
        //    }

        //    public void OnStartTrackingTouch(SeekBar seekBar)
        //    {
        //        mDragging = true;
        //        m_Contorller.Show(3600000);
        //        mHandler.RemoveMessages(SHOW_PROGRESS);
        //        if (mInstantSeeking)
        //        {
        //            mAM.SetStreamMute(Stream.Music, true);
        //        }
        //        if (mInfoView != null)
        //        {
        //            mInfoView.Text = "";// .setText("");
        //            mInfoView.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
        //        }
        //    }

        //    public void OnStopTrackingTouch(SeekBar seekBar)
        //    {
        //        if (!mInstantSeeking)
        //        {
        //            mPlayer.SeekTo((mDuration * mProgress.Progress) / 1000);
        //        }
        //        if (mInfoView != null)
        //        {
        //            mInfoView.Text = ""; //.setText("");
        //            mInfoView.Visibility = ViewStates.Gone;// setVisibility(View.GONE);
        //        }
        //        m_Contorller.Show(sDefaultTimeout);
        //        mHandler.RemoveMessages(SHOW_PROGRESS);
        //        mAM.SetStreamMute(Stream.Music, false);
        //        mDragging = false;
        //        mHandler.SendEmptyMessageDelayed(SHOW_PROGRESS, 1000);
        //    }

        //}
        #endregion
    }

}
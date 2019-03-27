using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
//using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using VideoPlayerDemo.Media.Callback;
using Java.IO;
using Java.Lang;
using TV.Danmaku.Ijk.Media.Player;
using TV.Danmaku.Ijk.Media.Player.Pragma;

using static Android.Views.ViewGroup;
//using IOnErrorListener = Android.Media.MediaPlayer.IOnErrorListener;
//using IOnInfoListener = Android.Media.MediaPlayer.IOnInfoListener;

namespace VideoPlayerDemo.Media
{
    public class VideoPlayerView : SurfaceView, IMediaPlayerListener, IMediaPlayerOnCompletionListener, IMediaPlayerOnPreparedListener, 
                                  IMediaPlayerOnErrorListener, IMediaPlayerOnSeekCompleteListener,IMediaPlayerOnInfoListener, 
                                  IMediaPlayerOnBufferingUpdateListener, IMediaPlayerOnVideoSizeChangedListener, ISurfaceHolderCallback

    {
        public static string TAG = "VideoPlayerView";
        public static int VIDEO_LAYOUT_ORIGIN = 0;
        public static int VIDEO_LAYOUT_SCALE = 1;
        public static int VIDEO_LAYOUT_STRETCH = 2;
        public static int VIDEO_LAYOUT_ZOOM = 3;
        public static int STATE_ERROR = -1;
        public static int STATE_IDLE = 0;
        public static int STATE_PREPARING = 1;
        public static int STATE_PREPARED = 2;
        public static int STATE_PLAYING = 3;
        public static int STATE_PAUSED = 4;
        public static int STATE_PLAYBACK_COMPLETED = 5;
        public static int STATE_SUSPEND = 6;
        public static int STATE_RESUME = 7;
        public static int STATE_SUSPEND_UNSUPPORTED = 8;
        public Android.Net.Uri mUri;
        public long mDuration;
        public string mUserAgent;
        public int mCurrentState = STATE_IDLE;
        public int mTargetState = STATE_IDLE;
        public int mVideoLayout = VIDEO_LAYOUT_SCALE;

        public ISurfaceHolder mSurfaceHolder = null;
        public IMediaPlayer mMediaPlayer = null;
        public int mVideoWidth;
        public int mVideoHeight;
        public int mVideoSarNum;
        public int mVideoSarDen;
        public int mSurfaceWidth;
        public int mSurfaceHeight;
        public MediaController mMediaController;
        public View mMediaBufferingIndicator;
        public IMediaPlayerOnCompletionListener mOnCompletionListener;//, mCompletionListener;
        public IMediaPlayerOnPreparedListener mOnPreparedListener;//, mPreparedListener;
        public IMediaPlayerOnErrorListener mOnErrorListener;//, mErrorListener;
        public IMediaPlayerOnSeekCompleteListener mOnSeekCompleteListener;//, mSeekCompleteListener;
        public IMediaPlayerOnInfoListener mOnInfoListener;//, mInfoListener;
        public IMediaPlayerOnBufferingUpdateListener mOnBufferingUpdateListener;//, mBufferingUpdateListener;
        public IMediaPlayerOnVideoSizeChangedListener mOnSizeChangedListener;//, mSizeChangedListener;
        public OnControllerEventsListener mOnControllerEventsListener;
        private int mCurrentBufferPercentage;
        public long mSeekWhenPrepared;
        private bool mCanPause = true;
        private bool mCanSeekBack = true;
        private bool mCanSeekForward = true;
        private Context mContext;
        private IAttributeSet mAttr;

        #region Old Listener Func
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnBufferingUpdateListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnCompletionListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnErrorListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnInfoListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnPreparedListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnSeekCompleteListener;
        //using TV.Danmaku.Ijk.Media.Player.IMediaPlayer.OnVideoSizeChangedListener;


        //var mPreparedListener = new OnPreparedListener(this);
        //var mSizeChangedListener = new OnVideoSizeChangedListener(this);
        //var mCompletionListener = new OnCompletionListener(this);
        //var mErrorListener = new OnErrorListener(this);
        //var mBufferingUpdateListener = new OnBufferingUpdateListener(this);
        //var mInfoListener = new OnInfoListener(this);


        //public class OnVideoSizeChangedListener : Java.Lang.Object, IMediaPlayerOnVideoSizeChangedListener
        //{
        //    public VideoPlayerView vPlayer;
        //    public OnVideoSizeChangedListener(VideoPlayerView v_Player)
        //    {
        //        vPlayer = v_Player;
        //    }

        //    public void OnVideoSizeChanged(IMediaPlayer mp, int width, int height, int sarNum, int sarDen)
        //    {
        //        DebugLog.Dfmt(TAG, "onVideoSizeChanged: (%dx%d)", width, height);
        //        //Log.Info(TAG, "onVideoSizeChanged: (%dx%d)", width, height);
        //        vPlayer.mVideoWidth = mp.VideoWidth;//. GetVideoWidth();
        //        vPlayer.mVideoHeight = mp.VideoHeight;// getVideoHeight();
        //        vPlayer.mVideoSarNum = sarNum;
        //        vPlayer.mVideoSarDen = sarDen;
        //        if (vPlayer.mVideoWidth != 0 && vPlayer.mVideoHeight != 0)
        //        {
        //            vPlayer.SetVideoLayout(vPlayer.mVideoLayout);
        //        }
        //    }
        //}

        //public class OnPreparedListener : Java.Lang.Object, IMediaPlayerOnPreparedListener
        //{
        //    private VideoPlayerView v_Model;
        //    public OnPreparedListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }

        //    public OnPreparedListener(Action a, VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }
        //    public void OnPrepared(IMediaPlayer mp)
        //    {
        //        DebugLog.Dfmt(TAG, "OnPrepared");
        //        v_Model.mCurrentState = STATE_PREPARED;
        //        v_Model.mTargetState = STATE_PLAYING;
        //        if (v_Model.mOnPreparedListener != null)
        //        {
        //            v_Model.mOnPreparedListener.OnPrepared(v_Model.mMediaPlayer);
        //        }
        //        if (v_Model.mMediaController != null)
        //        {
        //            v_Model.mMediaController.Enabled = true;// setEnabled(true);
        //        }
        //        v_Model.mVideoWidth = mp.VideoWidth;// getVideoWidth();
        //        v_Model.mVideoHeight = mp.VideoHeight;// getVideoHeight();
        //        long seekToPosition = v_Model.mSeekWhenPrepared;
        //        if (seekToPosition != 0)
        //        {
        //            v_Model.SeekTo(seekToPosition);
        //        }
        //        if (v_Model.mVideoWidth != 0 && v_Model.mVideoHeight != 0)
        //        {
        //            v_Model.SetVideoLayout(v_Model.mVideoLayout);
        //            if (v_Model.mSurfaceWidth == v_Model.mVideoWidth
        //                    && v_Model.mSurfaceHeight == v_Model.mVideoHeight)
        //            {
        //                if (v_Model.mTargetState == STATE_PLAYING)
        //                {
        //                    v_Model.Start();
        //                    if (v_Model.mMediaController != null)
        //                    {
        //                        v_Model.mMediaController.Show();
        //                    }
        //                }
        //                else if (!v_Model.IsPlaying()
        //                      && (seekToPosition != 0 || v_Model.GetCurrentPosition() > 0))
        //                {
        //                    if (v_Model.mMediaController != null)
        //                    {
        //                        v_Model.mMediaController.Show(0);
        //                    }
        //                }
        //            }
        //        }
        //        else if (v_Model.mTargetState == STATE_PLAYING)
        //        {
        //            v_Model.Start();
        //        }
        //    }
        //}

        //private class OnCompletionListener : Java.Lang.Object, IMediaPlayerOnCompletionListener
        //{
        //    private VideoPlayerView v_Model;
        //    public OnCompletionListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }

        //    public void OnCompletion(IMediaPlayer p0)
        //    {
        //        DebugLog.D(TAG, "OnCompletion");
        //        v_Model.mCurrentState = STATE_PLAYBACK_COMPLETED;
        //        v_Model.mTargetState = STATE_PLAYBACK_COMPLETED;
        //        if (v_Model.mMediaController != null)
        //        {
        //            v_Model.mMediaController.Hide();
        //        }
        //        if (v_Model.mOnCompletionListener != null)
        //        {
        //            v_Model.mOnCompletionListener.OnCompletion(v_Model.mMediaPlayer);
        //        }
        //    }
        //}

        //private class OnErrorListener : Java.Lang.Object, IMediaPlayerOnErrorListener
        //{
        //    private VideoPlayerView v_Model;
        //    public OnErrorListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }

        //    public bool OnError(IMediaPlayer p0, int what, int extra)
        //    {
        //        DebugLog.Dfmt(TAG, "Error: %d, %d", what, extra);
        //        v_Model.mCurrentState = STATE_ERROR;
        //        v_Model.mTargetState = STATE_ERROR;
        //        if (v_Model.mMediaController != null)
        //        {
        //            v_Model.mMediaController.Hide();
        //        }
        //        if (v_Model.mOnErrorListener != null)
        //        {
        //            if (v_Model.mOnErrorListener.OnError(v_Model.mMediaPlayer, what, extra))
        //            {
        //                return true;
        //            }
        //        }
        //        if (v_Model.WindowToken != null)
        //        {
        //            int message = what == (int)MediaError.NotValidForProgressivePlayback ?
        //                    Resource. String.video_error_text_invalid_progressive_playback : Resource.String.video_error_text_unknown;
        //            new AlertDialog.Builder(v_Model.mContext)
        //                    .SetTitle(Resource.String.video_error_title)
        //                    .SetMessage(message)
        //                    .SetPositiveButton(Resource.String.video_error_button, (dialog, whichButton) =>
        //                    {
        //                        if (v_Model.mOnCompletionListener != null)
        //                        {
        //                            v_Model.mOnCompletionListener.OnCompletion(v_Model.mMediaPlayer);
        //                        }
        //                    }).SetCancelable(false).Show();
        //        }
        //        return true;
        //    }
        //}

        //private class OnBufferingUpdateListener : Java.Lang.Object, IMediaPlayerOnBufferingUpdateListener //mBufferingUpdateListener = new OnBufferingUpdateListener()
        //{
        //    private VideoPlayerView v_Model;
        //    public OnBufferingUpdateListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }
        //    public void OnBufferingUpdate(IMediaPlayer mp, int percent)
        //    {
        //        v_Model.mCurrentBufferPercentage = percent;
        //        if (v_Model.mOnBufferingUpdateListener != null)
        //        {
        //            v_Model.mOnBufferingUpdateListener.OnBufferingUpdate(mp, percent);
        //        }
        //    }
        //}

        //private class OnInfoListener : Java.Lang.Object, IMediaPlayerOnInfoListener
        //{
        //    private VideoPlayerView v_Model;
        //    public OnInfoListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }
        //    public bool OnInfo(IMediaPlayer mp, int what, int extra)
        //    {
        //        DebugLog.Dfmt(TAG, "onInfo: (%d, %d)", what, extra);
        //        if (v_Model.mOnInfoListener != null)
        //        {
        //            v_Model.mOnInfoListener.OnInfo(mp, what, extra);
        //        }
        //        else if (v_Model.mMediaPlayer != null)
        //        {
        //            if (what == (int)Android.Media.MediaInfo.BufferingStart)
        //            {
        //                DebugLog.Dfmt(TAG, "onInfo: (MEDIA_INFO_BUFFERING_START)");
        //                if (v_Model.mMediaBufferingIndicator != null)
        //                {
        //                    v_Model.mMediaBufferingIndicator.Visibility = ViewStates.Visible;// .setVisibility(View.VISIBLE);
        //                }
        //            }
        //            else if (what == (int)Android.Media.MediaInfo.BufferingEnd)//IMediaPlayer.MEDIA_INFO_BUFFERING_END)
        //            {
        //                DebugLog.Dfmt(TAG, "onInfo: (MEDIA_INFO_BUFFERING_END)");
        //                if (v_Model.mMediaBufferingIndicator != null)
        //                {
        //                    v_Model.mMediaBufferingIndicator.Visibility = ViewStates.Gone;//   .setVisibility(View.GONE);
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //}

        //private class OnSeekCompleteListener : Java.Lang.Object, IMediaPlayerOnSeekCompleteListener
        //{
        //    private VideoPlayerView v_Model;
        //    public OnSeekCompleteListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }
        //    public void OnSeekComplete(IMediaPlayer mp)
        //    {
        //        DebugLog.D(TAG, "onSeekComplete");
        //        if (v_Model.mOnSeekCompleteListener != null)
        //        {
        //            v_Model.mOnSeekCompleteListener.OnSeekComplete(mp);
        //        }
        //    }
        //}

        //private class mSHCallBack : Java.Lang.Object, ISurfaceHolderCallback
        //{
        //    private VideoPlayerView v_Model;
        //    public mSHCallBack(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }
        //    public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        //    {
        //        v_Model.mSurfaceHolder = holder;
        //        if (v_Model.mMediaPlayer != null)
        //        {
        //            v_Model.mMediaPlayer.SetDisplay(v_Model.mSurfaceHolder);
        //        }
        //        v_Model.mSurfaceWidth = width;
        //        v_Model.mSurfaceHeight = height;
        //        bool isValidState = (v_Model.mTargetState == STATE_PLAYING);
        //        bool hasValidSize = (v_Model.mVideoWidth == width && v_Model.mVideoHeight == height);
        //        if (v_Model.mMediaPlayer != null && isValidState && hasValidSize)
        //        {
        //            if (v_Model.mSeekWhenPrepared != 0)
        //            {
        //                v_Model.SeekTo(v_Model.mSeekWhenPrepared);
        //            }
        //            v_Model.Start();
        //            if (v_Model.mMediaController != null)
        //            {
        //                if (v_Model.mMediaController.IsShowing())
        //                {
        //                    v_Model.mMediaController.Hide();
        //                }
        //                v_Model.mMediaController.Show();
        //            }
        //        }
        //    }

        //    public void SurfaceCreated(ISurfaceHolder holder)
        //    {
        //        v_Model.mSurfaceHolder = holder;
        //        if (v_Model.mMediaPlayer != null && v_Model.mCurrentState == STATE_SUSPEND
        //                && v_Model.mTargetState == STATE_RESUME)
        //        {
        //            v_Model.mMediaPlayer.SetDisplay(v_Model.mSurfaceHolder);
        //            v_Model.Resume();
        //        }
        //        else
        //        {
        //            v_Model.OpenVideo();
        //        }
        //    }

        //    public void SurfaceDestroyed(ISurfaceHolder holder)
        //    {
        //        v_Model.mSurfaceHolder = null;
        //        if (v_Model.mMediaController != null)
        //        {
        //            v_Model.mMediaController.Hide();
        //        }
        //        if (v_Model.mCurrentState != STATE_SUSPEND)
        //        {
        //            v_Model.Release(true);
        //        }
        //    }
        //}


        #endregion

            
        public VideoPlayerView(Context context)
            : base(context)
        {
            mContext = context;
            //mAttr = attrs;
            InitVideoView(context);
        }


        public VideoPlayerView(Context context, IAttributeSet attrs)
                    : base(context, attrs, 0)
        {
            mContext = context;
            mAttr = attrs;
            InitVideoView(context);
        }


        public VideoPlayerView(Context context, IAttributeSet attrs, int defStyle)
                     : base(context, attrs, defStyle)
        {

            mContext = context;
            mAttr = attrs;
            InitVideoView(context);
        }

        private void InitVideoView(Context ctx)
        {
            mSurfaceHolder = base.Holder;
            //ISurfaceHolderCallback ish = new SurfaceHolderCallBack(this);
         
           
            //mOnSeekCompleteListener = new OnSeekCompleteListener(this);

            mContext = ctx;
            mVideoWidth = 0;
            mVideoHeight = 0;
            mVideoSarNum = 0;
            mVideoSarDen = 0;

            //ISurfaceHolderCallback mshBack = new mSHCallBack(this);

            mSurfaceHolder.AddCallback(this);
            //Holder.AddCallback(mshBack);
            Focusable = true;
            FocusableInTouchMode = true;
            RequestFocus();

            mCurrentState = STATE_IDLE;
            mTargetState = STATE_IDLE;
            if (ctx is Activity)
            {
                ((Activity)ctx).VolumeControlStream = Stream.Music;// .SetVolumeControlStream(Stream.Music);
            }
        }


        #region Func-Check
        protected bool IsInPlaybackState()
        {
            return (mMediaPlayer != null && mCurrentState != STATE_ERROR
                    && mCurrentState != STATE_IDLE && mCurrentState != STATE_PREPARING);
        }

        public void Resume()
        {
            if (mSurfaceHolder == null && mCurrentState == STATE_SUSPEND)
            {
                mTargetState = STATE_RESUME;
            }
            else if (mCurrentState == STATE_SUSPEND_UNSUPPORTED)
            {
                OpenVideo();
            }
        }

        public int GetVideoWidth()
        {
            return mVideoWidth;
        }

        public int GetVideoHeight()
        {
            return mVideoHeight;
        }



        public bool CanSeekBackward()
        {
            return mCanSeekBack;
        }

        public bool CanSeekForward()
        {
            return mCanSeekForward;
        }

        public void Release(bool cleartargetstate)
        {
            if (mMediaPlayer != null)
            {
                mMediaPlayer.Reset();
                mMediaPlayer.Release();
                mMediaPlayer = null;
                mCurrentState = STATE_IDLE;
                if (cleartargetstate)
                {
                    mTargetState = STATE_IDLE;
                }
            }
        }
        #endregion

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int width = GetDefaultSize(mVideoWidth, widthMeasureSpec);
            int height = GetDefaultSize(mVideoHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);
        }


        public void SetVideoLayout(int layout)
        {
            //LinearLayout linelayout = FindViewById<LinearLayout>(layout);// new LinearLayout(mContext);
            LayoutParams lp = base.LayoutParameters;// linelayout.LayoutParameters;// FindViewById<LayoutParams>(layout);// GetChildAt(0). new LayoutParams(mContext, mAttr);// v.LayoutParameters;//  GetLayoutParams();
            var res = ScreenResolution.GetResolution(mContext);
            int windowWidth = res.FirstOrDefault().Key, windowHeight = res.FirstOrDefault().Value;
            float windowRatio = windowWidth / (float)windowHeight;
            int sarNum = mVideoSarNum;
            int sarDen = mVideoSarDen;
            if (mVideoHeight > 0 && mVideoWidth > 0)
            {
                float videoRatio = ((float)(mVideoWidth)) / mVideoHeight;
                if (sarNum > 0 && sarDen > 0)
                {
                    videoRatio = videoRatio * sarNum / sarDen;
                }
                mSurfaceHeight = mVideoHeight;
                mSurfaceWidth = mVideoWidth;
                if (VIDEO_LAYOUT_ORIGIN == layout && mSurfaceWidth < windowWidth
                        && mSurfaceHeight < windowHeight)
                {
                    lp.Width = (int)(mSurfaceHeight * videoRatio);
                    lp.Height = mSurfaceHeight;
                }
                else if (layout == VIDEO_LAYOUT_ZOOM)
                {
                    lp.Width = windowRatio > videoRatio ? windowWidth
                            : (int)(videoRatio * windowHeight);
                    lp.Height = windowRatio < videoRatio ? windowHeight
                            : (int)(windowWidth / videoRatio);
                }
                else
                {
                    bool full = layout == VIDEO_LAYOUT_STRETCH;
                    lp.Width = (full || windowRatio < videoRatio) ? windowWidth
                            : (int)(videoRatio * windowHeight);
                    lp.Height = (full || windowRatio > videoRatio) ? windowHeight
                            : (int)(windowWidth / videoRatio);
                }
                Holder.SetFixedSize(mSurfaceWidth, mSurfaceHeight);
                DebugLog.Dfmt(
                        TAG,
                        "VIDEO: %dx%dx%f[SAR:%d:%d], Surface: %dx%d, LP: %dx%d, Window: %dx%dx%f",
                        mVideoWidth, mVideoHeight, videoRatio, mVideoSarNum,
                        mVideoSarDen, mSurfaceWidth, mSurfaceHeight, lp.Width,
                        lp.Height, windowWidth, windowHeight, windowRatio);
            }
            mVideoLayout = layout;
        }



        public bool IsValid()
        {
            return (mSurfaceHolder != null && mSurfaceHolder.Surface.IsValid);
        }


        public void SetVideoPath(string path)
        {
            //Android.Net.Uri videoPath = new Android.Net.Uri(path);
            SetVideoURI(Android.Net.Uri.Parse(path));
        }


        public void SetVideoURI(Android.Net.Uri uri)
        {
            mUri = uri;
            mSeekWhenPrepared = 0;
            OpenVideo();
            RequestLayout();
            Invalidate();
        }

        public void SetUserAgent(string ua)
        {
            mUserAgent = ua;
        }


        public void StopPlayback()
        {
            if (mMediaPlayer != null)
            {
                mMediaPlayer.Stop();
                mMediaPlayer.Release();
                mMediaPlayer = null;
                mCurrentState = STATE_IDLE;
                mTargetState = STATE_IDLE;
            }
        }


        private void OpenVideo()
        {
            if (mUri == null || mSurfaceHolder == null)
            {
                return;
            }
            Intent i = new Intent("com.android.music.musicservicecommand");
            i.PutExtra("command", "pause");
            mContext.SendBroadcast(i);
            Release(false);
            try
            {
                mDuration = -1;
                mCurrentBufferPercentage = 0;
                // mMediaPlayer = new AndroidMediaPlayer();
                IjkMediaPlayer ijkMediaPlayer = null;
                if (mUri != null)
                {
                    ijkMediaPlayer = new IjkMediaPlayer();
                    ijkMediaPlayer.SetLogEnabled(false);
                    ijkMediaPlayer.SetOption(IjkMediaPlayer.OptCategoryCodec, "skip_loop_filter", "48");
                }
                mMediaPlayer = ijkMediaPlayer;
                if (mMediaPlayer == null) return;

                mMediaPlayer.SetOnPreparedListener(this);
                mMediaPlayer.SetOnVideoSizeChangedListener(this);
                mMediaPlayer.SetOnCompletionListener(this);
                mMediaPlayer.SetOnErrorListener(this);
                mMediaPlayer.SetOnBufferingUpdateListener(this);
                mMediaPlayer.SetOnInfoListener(this);
                mMediaPlayer.SetOnSeekCompleteListener(this);//;mOnSeekCompleteListener);

                if (mUri != null)
                {
                    mMediaPlayer.SetDataSource(mContext, mUri);
                }
                mMediaPlayer.SetDisplay(mSurfaceHolder);
                mMediaPlayer.SetScreenOnWhilePlaying(true);
                mMediaPlayer.PrepareAsync();
                mCurrentState = STATE_PREPARING;
                AttachMediaController();
            }
            catch (IOException ex)
            {
                DebugLog.E(TAG, "Unable to open content: " + mUri, ex);
                mCurrentState = STATE_ERROR;
                mTargetState = STATE_ERROR;
                mOnErrorListener.OnError(mMediaPlayer, (int)MediaError.Unknown, 0);
            }
            catch (IllegalArgumentException ex)
            {
                DebugLog.E(TAG, "Unable to open content: " + mUri, ex);
                mCurrentState = STATE_ERROR;
                mTargetState = STATE_ERROR;
                mOnErrorListener.OnError(mMediaPlayer, (int)MediaError.Unknown, 0);
            }
        }



        public void SetMediaController(MediaController controller)
        {
            if (mMediaController != null)
            {
                mMediaController.Hide();
            }
            mMediaController = controller;
            AttachMediaController();
        }


        public void SetMediaBufferingIndicator(View mediaBufferingIndicator)
        {
            if (mMediaBufferingIndicator != null)
            {
                mMediaBufferingIndicator.Visibility = ViewStates.Gone;// .setVisibility(View.GONE);
            }
            mMediaBufferingIndicator = mediaBufferingIndicator;
        }


        public void AttachMediaController()
        {
            if (mMediaPlayer != null && mMediaController != null)
            //if (mMediaController != null)
            {
                mMediaController.SetMediaPlayer(this);
                View anchorView = this.Parent is View ? (View)this.Parent : this;
                mMediaController.SetAnchorView(anchorView);
                mMediaController.SetEnabled(IsInPlaybackState());

            }
            //getParent() instanceof View ? (View)this
            //            .getParent() : this;
        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            if (IsInPlaybackState() && mMediaController != null)
            {
                ToggleMediaControlsVisiblity();
            }
            return false;
        }


        public override bool OnTrackballEvent(MotionEvent ev)
        {
            if (IsInPlaybackState() && mMediaController != null)
            {
                ToggleMediaControlsVisiblity();
            }
            return false;
        }


        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            bool isKeyCodeSupported = keyCode != Keycode.Back
                    && keyCode != Keycode.VolumeUp
                    && keyCode != Keycode.VolumeDown
                    && keyCode != Keycode.Menu
                    && keyCode != Keycode.Call
                    && keyCode != Keycode.Endcall;
            if (IsInPlaybackState() && isKeyCodeSupported
                    && mMediaController != null)
            {
                if (keyCode == Keycode.Headsethook
                        || keyCode == Keycode.MediaPlay
                        || keyCode == Keycode.Space)
                {
                    if (mMediaPlayer.IsPlaying)//.IsPlaying())
                    {
                        Pause();
                        mMediaController.Show();
                    }
                    else
                    {
                        Start();
                        mMediaController.Hide();
                    }
                    return true;
                }
                else if (keyCode == Keycode.MediaStop
                      && mMediaPlayer.IsPlaying)//IsPlaying())
                {
                    Pause();
                    mMediaController.Show();
                }
                else
                {
                    ToggleMediaControlsVisiblity();
                }
            }
            return base.OnKeyDown(keyCode, e);
        }


        private void ToggleMediaControlsVisiblity()
        {
            if (mMediaController.IsShowing())
            {
                mMediaController.Hide();
            }
            else
            {
                mMediaController.Show();
            }
        }

        #region IMediaPlayer Listener  Init

        public void SetOnPreparedListener(IMediaPlayerOnPreparedListener l)
        {
            this.mOnPreparedListener = l;
        }

        public void SetOnCompletionListener(IMediaPlayerOnCompletionListener l)
        {
            mOnCompletionListener = l;
        }

        public void SetOnErrorListener(IMediaPlayerOnErrorListener l)
        {
            mOnErrorListener = l;
        }

        public void SetOnBufferingUpdateListener(IMediaPlayerOnBufferingUpdateListener l)
        {
            mOnBufferingUpdateListener = l;
        }

        public void SetOnSeekCompleteListener(IMediaPlayerOnSeekCompleteListener l)
        {
            mOnSeekCompleteListener = l;
        }

        public void SetOnInfoListener(IMediaPlayerOnInfoListener l)
        {
            mOnInfoListener = l;
        }

        public void SetOnControllerEventsListener(OnControllerEventsListener l)
        {
            mOnControllerEventsListener = l;
        }

        #endregion

        #region IMediaPlayerListener Func

        public void Start()
        {
            if (IsInPlaybackState())
            {
                mMediaPlayer.Start();
                mCurrentState = STATE_PLAYING;
            }
            mTargetState = STATE_PLAYING;
            mOnControllerEventsListener.OnVideoResume();
        }

        public void Pause()
        {
            if (IsInPlaybackState())
            {
                if (mMediaPlayer.IsPlaying)
                {
                    mMediaPlayer.Pause();
                    mCurrentState = STATE_PAUSED;
                }
            }
            mTargetState = STATE_PAUSED;
            mOnControllerEventsListener.OnVideoPause();
        }

        public int GetDuration()
        {
            if (IsInPlaybackState())
            {
                if (mDuration > 0)
                {
                    return (int)mDuration;
                }
                mDuration = mMediaPlayer.Duration;
                return (int)mDuration;
            }
            mDuration = -1;
            return (int)mDuration;
        }

        public int GetCurrentPosition()
        {
            if (IsInPlaybackState())
            {
                long position = mMediaPlayer.CurrentPosition;//.getCurrentPosition();
                return (int)position;
            }
            return 0;
        }

        public void SeekTo(long pos)
        {
            if (IsInPlaybackState())
            {
                mMediaPlayer.SeekTo(pos);
                mSeekWhenPrepared = 0;
            }
            else
            {
                mSeekWhenPrepared = pos;
            }
        }

        public bool IsPlaying()
        {
            return IsInPlaybackState() && mMediaPlayer.IsPlaying;// isPlaying();
        }

        public int GetBufferPercentage()
        {
            if (mMediaPlayer != null)
            {
                return mCurrentBufferPercentage;
            }
            return 0;
        }

        public bool CanPause()
        {
            return mCanPause;
        }

        public void OnCompletion(IMediaPlayer p0)
        {
            DebugLog.D(TAG, "OnCompletion");
            mCurrentState = STATE_PLAYBACK_COMPLETED;
            mTargetState = STATE_PLAYBACK_COMPLETED;
            if (mMediaController != null)
            {
                mMediaController.Hide();
            }
            if (mOnCompletionListener != null)
            {
                mOnCompletionListener.OnCompletion(mMediaPlayer);
            }
        }

        public void OnPrepared(IMediaPlayer mp)
        {
            DebugLog.Dfmt(TAG, "OnPrepared");
            mCurrentState = STATE_PREPARED;
            mTargetState = STATE_PLAYING;
            if (mOnPreparedListener != null)
            {
                mOnPreparedListener.OnPrepared(mMediaPlayer);
            }
            if (mMediaController != null)
            {
                mMediaController.SetEnabled(true);// .Enabled = true;// setEnabled(true);
            }
            mVideoWidth = mp.VideoWidth;// getVideoWidth();
            mVideoHeight = mp.VideoHeight;// getVideoHeight();
            long seekToPosition = mSeekWhenPrepared;
            if (seekToPosition != 0)
            {
                SeekTo(seekToPosition);
            }
            if (mVideoWidth != 0 && mVideoHeight != 0)
            {
                SetVideoLayout(mVideoLayout);
                if (mSurfaceWidth == mVideoWidth
                        && mSurfaceHeight == mVideoHeight)
                {
                    if (mTargetState == STATE_PLAYING)
                    {
                        Start();
                        if (mMediaController != null)
                        {
                            mMediaController.Show();
                        }
                    }
                    else if (!IsPlaying()
                          && (seekToPosition != 0 || GetCurrentPosition() > 0))
                    {
                        if (mMediaController != null)
                        {
                            mMediaController.Show(0);
                        }
                    }
                }
            }
            else if (mTargetState == STATE_PLAYING)
            {
                Start();
            }
        }
    

        public bool OnError(IMediaPlayer p0, int what, int extra)
        {
            DebugLog.Dfmt(TAG, "Error: %d, %d", what, extra);
            mCurrentState = STATE_ERROR;
            mTargetState = STATE_ERROR;
            if (mMediaController != null)
            {
                mMediaController.Hide();
            }
            if (mOnErrorListener != null)
            {
                if (mOnErrorListener.OnError(mMediaPlayer, what, extra))
                {
                    return true;
                }
            }
            if (WindowToken != null)
            {
                int message = what == (int)MediaError.NotValidForProgressivePlayback ?
                        Resource.String.video_error_text_invalid_progressive_playback : Resource.String.video_error_text_unknown;
                new AlertDialog.Builder(mContext)
                        .SetTitle(Resource.String.video_error_title)
                        .SetMessage(message)
                        .SetPositiveButton(Resource.String.video_error_button, (dialog, whichButton) =>
                        {
                            if (mOnCompletionListener != null)
                            {
                                mOnCompletionListener.OnCompletion(mMediaPlayer);
                            }
                        }).SetCancelable(false).Show();
            }
            return true;
        }
    

        public void OnSeekComplete(IMediaPlayer mp)
        {
            DebugLog.D(TAG, "onSeekComplete");
            if (mOnSeekCompleteListener != null)
            {
                mOnSeekCompleteListener.OnSeekComplete(mp);
            }
        }

        public bool OnInfo(IMediaPlayer mp, int what, int extra)
        {
            DebugLog.Dfmt(TAG, "onInfo: (%d, %d)", what, extra);
            if (mOnInfoListener != null)
            {
                mOnInfoListener.OnInfo(mp, what, extra);
            }
            else if (mMediaPlayer != null)
            {
                if (what == (int)Android.Media.MediaInfo.BufferingStart)
                {
                    DebugLog.Dfmt(TAG, "onInfo: (MEDIA_INFO_BUFFERING_START)");
                    if (mMediaBufferingIndicator != null)
                    {
                        mMediaBufferingIndicator.Visibility = ViewStates.Visible;// .setVisibility(View.VISIBLE);
                    }
                }
                else if (what == (int)Android.Media.MediaInfo.BufferingEnd)//IMediaPlayer.MEDIA_INFO_BUFFERING_END)
                {
                    DebugLog.Dfmt(TAG, "onInfo: (MEDIA_INFO_BUFFERING_END)");
                    if (mMediaBufferingIndicator != null)
                    {
                        mMediaBufferingIndicator.Visibility = ViewStates.Gone;//   .setVisibility(View.GONE);
                    }
                }
            }
            return true;
        }

        public void OnVideoSizeChanged(IMediaPlayer mp, int width, int height, int sarNum, int sarDen)
        {
            DebugLog.Dfmt(TAG, "onVideoSizeChanged: (%dx%d)", width, height);
            //Log.Info(TAG, "onVideoSizeChanged: (%dx%d)", width, height);
            mVideoWidth = mp.VideoWidth;//. GetVideoWidth();
            mVideoHeight = mp.VideoHeight;// getVideoHeight();
            mVideoSarNum = sarNum;
            mVideoSarDen = sarDen;
            if (mVideoWidth != 0 && mVideoHeight != 0)
            {
                SetVideoLayout(mVideoLayout);
            }
        }

        public void OnBufferingUpdate(IMediaPlayer mp, int percent)
        {
            mCurrentBufferPercentage = percent;
            if (mOnBufferingUpdateListener != null)
            {
                mOnBufferingUpdateListener.OnBufferingUpdate(mp, percent);
            }
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
            mSurfaceHolder = holder;
            if (mMediaPlayer != null)
            {
                mMediaPlayer.SetDisplay(mSurfaceHolder);
            }
            mSurfaceWidth = width;
            mSurfaceHeight = height;
            bool isValidState = (mTargetState == STATE_PLAYING);
            bool hasValidSize = (mVideoWidth == width && mVideoHeight == height);
            if (mMediaPlayer != null && isValidState && hasValidSize)
            {
                if (mSeekWhenPrepared != 0)
                {
                    SeekTo(mSeekWhenPrepared);
                }
                Start();
                if (mMediaController != null)
                {
                    if (mMediaController.IsShowing())
                    {
                        mMediaController.Hide();
                    }
                    mMediaController.Show();
                }
            }
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            mSurfaceHolder = holder;
            if (mMediaPlayer != null && mCurrentState == STATE_SUSPEND
                    && mTargetState == STATE_RESUME)
            {
                mMediaPlayer.SetDisplay(mSurfaceHolder);
                Resume();
            }
            else
            {
                OpenVideo();
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            mSurfaceHolder = null;
            if (mMediaController != null)
            {
                mMediaController.Hide();
            }
            if (mCurrentState != STATE_SUSPEND)
            {
                Release(true);
            }
        }

        #endregion

        public interface OnControllerEventsListener
        {
            void OnVideoPause();

            void OnVideoResume();
        }
    }
}
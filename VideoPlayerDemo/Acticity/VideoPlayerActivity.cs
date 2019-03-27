using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VideoPlayerDemo.Base;
using VideoPlayerDemo.Media;
using VideoPlayerDemo.Media.Callback;
//using Comic_Android.Utils;
//using ComicAPI.Model;
//using ComicAPI.Service;
//using Com.Trello.Rxlifecycle2;
using static Android.Widget.TextView;
using MediaController = VideoPlayerDemo.Media.MediaController;
using IO.Reactivex;
using Java.Util.Concurrent;
using VideoPlayerDemo.Utils;
using TV.Danmaku.Ijk.Media.Player;
using IO.Reactivex.Functions;
using IO.Reactivex.Android.Schedulers;
using Java.Lang;
using TV.Danmaku.Ijk.Media.Player.Pragma;
using Android.Util;
//using Comic_Android.Entity;
//using IO.Reactivex.Android.Schedulers;
//using IO.Reactivex.Functions;
//using TV.Danmaku.Ijk.Media.Player;

namespace VideoPlayerDemo.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class VideoPlayerActivity : RxBaseActivity, IVideoBackListener, IDanmukuSwitchListener, IMediaPlayerOnInfoListener, IMediaPlayerOnSeekCompleteListener, VideoPlayerView.OnControllerEventsListener, IMediaPlayerOnCompletionListener, IMediaPlayerOnPreparedListener
    {
        private string TAG = "VideoPlayerActivity";
        VideoPlayerView mPlayerView;
        View mBufferingIndicator;
        RelativeLayout mVideoPrepareLayout;
        ImageView mAnimImageView;
        TextView mPrepareText;

        private int cid;
        private string title;
        private int LastPosition = 0;
        private string startText = "初始化播放器...";
        private AnimationDrawable mLoadingAnim;
        //private DanmakuContext danmakuContext;

        public delegate IFunction MethodtDelegate();

        public override int getLayoutId()
        {
            return Resource.Layout.activity_video_player;

        }
        public override void initViews(Bundle savedInstanceState)
        {
            try
            {
                Intent intent = Intent;//  getIntent(); ???
                if (intent != null)
                {
                    cid = intent.GetIntExtra(ConstantUtil.EXTRA_CID, 0);
                    title = "Test";// intent.GetStringExtra(ConstantUtil.EXTRA_TITLE);
                }
                InitAnimation();
                InitMediaPlayer();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "initViews--" + e.ToString());
            }
        }

        private void InitMediaPlayer()
        {
            try
            {
                //var onInfoListener = new OnInfoListener(this);
                //var onSeekCompleteListener = new OnSeekCompleteListener();
                //var onCompletionListener = new OnCompletionListener();
                //var onControllerEventsListener = new OnControllerEventsListener();

                //配置播放器
                MediaController mMediaController = new MediaController(this);
                mMediaController.SetTitle(title);// setTitle(title);

                mPlayerView.SetVideoLayout(mPlayerView.Id);
                mPlayerView.SetMediaController(mMediaController);
                mPlayerView.SetMediaBufferingIndicator(mBufferingIndicator);
                mPlayerView.RequestFocus();

                mPlayerView.SetOnInfoListener(this);
                mPlayerView.SetOnSeekCompleteListener(this);
                mPlayerView.SetOnCompletionListener(this);
                mPlayerView.SetOnControllerEventsListener(this);

                //设置返回键监听
                mMediaController.SetVideoBackEvent(this);

                #region 弹幕
                //设置弹幕开关监听
                //mMediaController.SetDanmakuSwitchListener(this);
                //配置弹幕库
                //mDanmakuView.enableDanmakuDrawingCache(true);
                ////设置最大显示行数
                //HashMap<Integer, Integer> maxLinesPair = new HashMap<>();
                ////滚动弹幕最大显示5行
                //maxLinesPair.Put(BaseDanmaku.TYPE_SCROLL_RL, 5);
                ////设置是否禁止重叠
                //HashMap<Integer, Boolean> overlappingEnablePair = new HashMap<>();
                //overlappingEnablePair.put(BaseDanmaku.TYPE_SCROLL_RL, true);
                //overlappingEnablePair.put(BaseDanmaku.TYPE_FIX_TOP, true);
                ////设置弹幕样式
                //danmakuContext = DanmakuContext.create();
                //danmakuContext.setDanmakuStyle(IDisplayer.DANMAKU_STYLE_STROKEN, 3)
                //        .setDuplicateMergingEnabled(false)
                //        .setScrollSpeedFactor(1.2f)
                //        .setScaleTextSize(0.8f)
                //        .setMaximumLines(maxLinesPair)
                //        .preventOverlapping(overlappingEnablePair);
                #endregion

                LoadData();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "InitMediaPlayer--" + e.ToString());
            }
        }

        /**
      * 初始化加载动画
      */
        private void InitAnimation()
        {
            try
            {
                if (mVideoPrepareLayout == null)
                {
                    mPlayerView = FindViewById<VideoPlayerView>(Resource.Id.playerView);
                    mBufferingIndicator = FindViewById<View>(Resource.Id.buffering_indicator);
                    mVideoPrepareLayout = FindViewById<RelativeLayout>(Resource.Id.video_start);
                    mAnimImageView = FindViewById<ImageView>(Resource.Id.bili_anim);
                    mPrepareText = FindViewById<TextView>(Resource.Id.video_start_info);
                }

                mVideoPrepareLayout.Visibility = ViewStates.Visible;// .SetVisibility(View.VISIBLE);

                startText = startText + "【完成】\n解析视频地址...";
                mPrepareText.SetText(startText, BufferType.Normal);
                mLoadingAnim = (AnimationDrawable)mAnimImageView.Background;// GetBackground();
                mLoadingAnim.Start();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "InitAnimation--" + e.ToString());
            }
        }

        public override void initToolBar()
        {
            try
            {
                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
                Window.SetBackgroundDrawable(null);
                Window.AddFlags(WindowManagerFlags.KeepScreenOn);
                //SupportActionBar.Hide();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "initToolBar--" + e.ToString());
            }

        }

        public void Back()
        {
            OnBackPressed();
            //throw new NotImplementedException();
        }


        /**
        * 获取视频数据以及解析弹幕
        */
        public void LoadData()
        {
            try
            {
                var videoPath = Android.Net.Uri.Parse("http://112.25.9.182:8088/hc.yinyuetai.com/uploads/videos/common/8D0A01661538DDE86306C35D8ABBD474.mp4");
                mPlayerView.SetVideoURI(videoPath);
                mPlayerView.SetOnPreparedListener(this);
                mPlayerView.Start();


                #region
                //        RetrofitHelper.getBiliGoAPI()
                //          .getHDVideoUrl(cid, 4, ConstantUtil.VIDEO_TYPE_MP4)
                //          .compose(bindToLifecycle())
                //          .map(videoInfo->Uri.parse(videoInfo.getDurl().get(0).getUrl()))
                //          .observeOn(AndroidSchedulers.mainThread())
                //          .flatMap(new Func1<Uri, Observable<BaseDanmakuParser>>() {
                //                @Override
                //                public Observable<BaseDanmakuParser> call(Uri uri)
                //        {
                //            mPlayerView.setVideoURI(uri);
                //            mPlayerView.setOnPreparedListener(mp-> {
                //                mLoadingAnim.stop();
                //                startText = startText + "【完成】\n视频缓冲中...";
                //                mPrepareText.setText(startText);
                //                mVideoPrepareLayout.setVisibility(View.GONE);
                //            });
                //        String url = "http://comment.bilibili.com/" + cid + ".xml";
                //        return BiliDanmukuDownloadUtil.downloadXML(url);
                //    }
                //})
                //            .subscribeOn(Schedulers.io())
                //            .observeOn(AndroidSchedulers.mainThread())
                //            .subscribe(baseDanmakuParser -> {
                //    mDanmakuView.prepare(baseDanmakuParser, danmakuContext);
                //    mDanmakuView.showFPS(false);
                //    mDanmakuView.enableDanmakuDrawingCache(false);
                //    mDanmakuView.setCallback(new DrawHandler.Callback() {
                //                    @Override
                //                    public void prepared()
                //    {
                //        mDanmakuView.start();
                //    }

                //    @Override
                //                    public void updateTimer(DanmakuTimer danmakuTimer)
                //    {
                //    }

                //    @Override
                //                    public void danmakuShown(BaseDanmaku danmaku)
                //    {
                //    }

                //    @Override
                //                    public void drawingFinished()
                //    {
                //    }
                //});
                //                mPlayerView.start();
                //            }, throwable -> {
                //                startText = startText + "【失败】\n视频缓冲中...";
                //                mPrepareText.setText(startText);
                //                startText = startText + "【失败】\n" + throwable.getMessage();
                //                mPrepareText.setText(startText);
                //            });
                #endregion
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "LoadDate--" + e.ToString());
            }
        }

        #region Old Listener
        //public class OnInfoListener : Java.Lang.Object, IMediaPlayerOnInfoListener
        //{

        //    private VideoPlayerActivity v_Model;
        //    public OnInfoListener(VideoPlayerActivity m)
        //    {
        //        v_Model = m;
        //    }
        //    public bool OnInfo(IMediaPlayer mp, int what, int extra)
        //    {
        //        if (what == (int)Android.Media.MediaInfo.BufferingStart)
        //        {
        //            if (v_Model.mBufferingIndicator != null)
        //            {
        //                v_Model.mBufferingIndicator.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
        //            }
        //            //if (v_Model.mDanmakuView != null && mDanmakuView.isPrepared())
        //            //{
        //            //    mDanmakuView.pause();

        //            //}
        //        }
        //        else if (what == (int)Android.Media.MediaInfo.BufferingEnd)//  IMediaPlayer.MEDIA_INFO_BUFFERING_END)
        //        {
        //            //if (mDanmakuView != null && mDanmakuView.isPaused())
        //            //{
        //            //    mDanmakuView.resume();
        //            //}
        //            if (v_Model.mBufferingIndicator != null)
        //            {
        //                v_Model.mBufferingIndicator.Visibility = ViewStates.Gone;// .setVisibility(View.GONE);
        //            }
        //        }
        //        return true;
        //    }
        //}

        //public class OnSeekCompleteListener : Java.Lang.Object, IMediaPlayerOnSeekCompleteListener
        //{
        //    public void OnSeekComplete(IMediaPlayer p0)
        //    {
        //        //throw new NotImplementedException();
        //    }
        //}

        //public class OnCompletionListener : Java.Lang.Object, IMediaPlayerOnCompletionListener
        //{
        //    public void OnCompletion(IMediaPlayer p0)
        //    {
        //        //throw new NotImplementedException();
        //    }
        //}

        //public class OnControllerEventsListener : Java.Lang.Object, VideoPlayerView.OnControllerEventsListener
        //{
        //    public void OnVideoPause()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void OnVideoResume()
        //    {
        //        //throw new NotImplementedException();
        //    }
        //}

        //public class OnPreparedListener : Java.Lang.Object, IMediaPlayerOnPreparedListener
        //{
        //    private VideoPlayerView v_Model;//mPlayerView
        //    private VideoPlayerActivity vPlayer;
        //    public OnPreparedListener(VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }

        //    public OnPreparedListener(Action a, VideoPlayerView m)
        //    {
        //        v_Model = m;
        //    }

        //    public OnPreparedListener(VideoPlayerActivity v_Player, VideoPlayerView m)
        //    {
        //        v_Model = m;
        //        vPlayer = v_Player;
        //    }
        //    public void OnPrepared(IMediaPlayer mp)
        //    {
        //        vPlayer.mLoadingAnim.Stop();
        //        vPlayer.startText += "【完成】\n视频缓冲中...";
        //        vPlayer.mPrepareText.SetText(vPlayer.startText, BufferType.Normal);
        //        vPlayer.mVideoPrepareLayout.Visibility = ViewStates.Gone;// setVisibility(View.GONE);

        //        DebugLog.Dfmt("Test", "OnPrepared");
        //        v_Model.mCurrentState = 2;// v_Model.STATE_PREPARED;
        //        v_Model.mTargetState = 3;//STATE_PLAYING;
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
        //            v_Model.SetVideoLayout(vPlayer.mPlayerView.Id);
        //            if (v_Model.mSurfaceWidth == v_Model.mVideoWidth
        //                    && v_Model.mSurfaceHeight == v_Model.mVideoHeight)
        //            {
        //                if (v_Model.mTargetState == 3)//STATE_PLAYING)
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
        //        else if (v_Model.mTargetState == 3)//STATE_PLAYING)
        //        {
        //            v_Model.Start();
        //        }
        //    }
        //}

        #endregion
        #region New Listener 
        /**
        * 视频缓冲事件回调
        */
        public bool OnInfo(IMediaPlayer mp, int what, int extra)
        {
            if (what == (int)Android.Media.MediaInfo.BufferingStart)
            {
                if (mBufferingIndicator != null)
                {
                    mBufferingIndicator.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
                }
            }
            else if (what == (int)Android.Media.MediaInfo.BufferingEnd)//  IMediaPlayer.MEDIA_INFO_BUFFERING_END)
            {
                if (mBufferingIndicator != null)
                {
                    mBufferingIndicator.Visibility = ViewStates.Gone;// .setVisibility(View.GONE);
                }
            }
            return true;
        }
        /**
        * 视频跳转事件回调
        */
        public void OnSeekComplete(IMediaPlayer p0)
        {
            return;
            //throw new NotImplementedException();
        }

       
        /**
        * 控制条控制状态事件回调
        */
        public void OnVideoPause()
        {
            return;
        }
        /**
        * 控制条控制状态事件回调
        */
        public void OnVideoResume()
        {
            return;
        }
        /**
         * 视频播放完成事件回调
         */
        public void OnCompletion(IMediaPlayer p0)
        {
            mPlayerView.Pause();
        }

        public void OnPrepared(IMediaPlayer p0)
        {
            mLoadingAnim.Stop();
            startText = startText + "【完成】\n视频缓冲中...";
            mPrepareText.SetText(startText, BufferType.Normal);
            mVideoPrepareLayout.Visibility = ViewStates.Gone;
        }
        #endregion
        protected override void OnResume()
        {
            base.OnResume();
            
            if (mPlayerView != null && !mPlayerView.IsPlaying())
            {
                mPlayerView.SeekTo(LastPosition);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (mPlayerView != null)
            {
                LastPosition = mPlayerView.GetCurrentPosition();// .CurrentPosition;
                mPlayerView.Pause();
            }
           
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (mPlayerView != null && mPlayerView.DrawingCacheEnabled)
            {
                mPlayerView.DestroyDrawingCache();// destroyDrawingCache();
            }
            
            if (mLoadingAnim != null)
            {
                mLoadingAnim.Stop();
                mLoadingAnim = null;
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            
            if (mLoadingAnim != null)
            {
                mLoadingAnim.Stop();
                mLoadingAnim = null;
            }
        }
        public void setDanmakuShow(bool isShow)
        {
            return;
            //throw new NotImplementedException();
        }

        //protected override void OnCreate(Bundle savedInstanceState)
        //{

        //    base.OnCreate(savedInstanceState);
        //    //SetContentView(Resource.Layout.activity_video_player);

        //    //mPlayerView = FindViewById<VideoPlayerView>(Resource.Id.playerView);
        //    //mBufferingIndicator = FindViewById<View>(Resource.Id.buffering_indicator);
        //    //mVideoPrepareLayout = FindViewById<RelativeLayout>(Resource.Id.video_start);
        //    //mAnimImageView = FindViewById<ImageView>(Resource.Id.bili_anim);
        //    //mPrepareText = FindViewById<TextView>(Resource.Id.video_start_info);

        //    // Create your application here
        //}

    }

}

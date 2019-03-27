using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Flyco.Tablayout;
using VideoPlayerDemo.Activities;
using VideoPlayerDemo.Base;
using VideoPlayerDemo.Event;
using VideoPlayerDemo.Utils;
using Android.Support.V4.App;

using static Android.Support.Design.Widget.AppBarLayout;
using static Android.Support.V4.View.ViewPager;
using VideoPlayerDemo.Widget;
using VideoPlayerDemo.Media;
using Android.Util;
using MediaController = VideoPlayerDemo.Media.MediaController;
using VideoPlayerDemo.Media.Callback;
using TV.Danmaku.Ijk.Media.Player;
using Java.Lang;
using Android.Runtime;

namespace VideoPlayerDemo.Acticity
{
    [Android.App.Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class VideoDetailsActivity : RxBaseActivity, IOnOffsetChangedListener, IOnPageChangeListener,
         IVideoBackListener,  IMediaPlayerOnInfoListener, IMediaPlayerOnSeekCompleteListener,
        VideoPlayerView.OnControllerEventsListener, IMediaPlayerOnCompletionListener, IMediaPlayerOnPreparedListener
    {
        private string TAG = "VideoDetailsActivity";
        Android.Support.V7.Widget.Toolbar mToolbar;
        CollapsingToolbarLayout mCollapsingToolbarLayout;
        ImageView mVideoPreview;
        SlidingTabLayout mSlidingTabLayout;
        ViewPager mViewPager;
        FloatingActionButton mFAB;
        AppBarLayout mAppBarLayout;
        TextView mTvPlayer;
        TextView mAvText;
        VideoPlayerView mPlayerView;
        View mBufferingIndicator;

        private int av;
        private string imgUrl;
        //private VideoDetailsInfo mVideoDetailsInfo;
        private string[] titles = new string[2];// = new Java.Lang.String[]();
        private List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();

        public override int getLayoutId()
        {
            return Resource.Layout.activity_video_details;
        }

        public override void initToolBar()
        {
            //mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //mCollapsingToolbarLayout = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            //mVideoPreview = FindViewById<ImageView>(Resource.Id.video_preview);
            //mSlidingTabLayout = FindViewById<SlidingTabLayoutPlus>(Resource.Id.tab_layout);
            //mViewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
            //mFAB = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //mAppBarLayout = FindViewById<AppBarLayout>(Resource.Id.app_bar_layout);
            //mTvPlayer = FindViewById<TextView>(Resource.Id.tv_player);
            //mAvText = FindViewById<TextView>(Resource.Id.tv_av);

            mToolbar.Title = "";//.setTitle("");
            SetSupportActionBar(mToolbar);

            Android.Support.V7.App.ActionBar supportActionBar = this.SupportActionBar;// SupportActionBar;// GetSupportActionBar();
            if (supportActionBar != null)
            {
                supportActionBar.SetDisplayHomeAsUpEnabled(true);//  .setDisplayHomeAsUpEnabled(true);
                //supportActionBar.Hide();
            }
            //设置还没收缩时状态下字体颜色
            mCollapsingToolbarLayout.SetExpandedTitleColor((int)Color.Transparent);
            //设置收缩后Toolbar上字体的颜色
            mCollapsingToolbarLayout.SetCollapsedTitleTextColor((int)Color.White);
            //设置StatusBar透明

            SystemBarHelper.ImmersiveStatusBar(this);

            SystemBarHelper.SetHeightAndPadding(this, mToolbar);

            //Sys
            mAvText.Text = ("av" + av);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }




        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.menu_video, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed();
            }
            return base.OnOptionsItemSelected(item);
        }


        public override void initViews(Bundle savedInstanceState)
        {
            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            mCollapsingToolbarLayout = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            mVideoPreview = FindViewById<ImageView>(Resource.Id.video_preview);
            mSlidingTabLayout = FindViewById<SlidingTabLayout>(Resource.Id.tab_layout);
            mViewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
            mFAB = FindViewById<FloatingActionButton>(Resource.Id.fab);
            mAppBarLayout = FindViewById<AppBarLayout>(Resource.Id.app_bar_layout);
            mTvPlayer = FindViewById<TextView>(Resource.Id.tv_player);
            mAvText = FindViewById<TextView>(Resource.Id.tv_av);
            mPlayerView = FindViewById<VideoPlayerView>(Resource.Id.video_view);
            mBufferingIndicator = FindViewById<View>(Resource.Id.buffering_indicator);

            Intent intent = this.Intent;// getIntent();
            if (intent != null)
            {
                av = intent.GetIntExtra(ConstantUtil.EXTRA_AV, -1);
                imgUrl = intent.GetStringExtra(ConstantUtil.EXTRA_IMG_URL);
            }
            InitMediaPlayer();

            LoadData();
            mFAB.Clickable = false;// setClickable(false);
            Color stateColor = new Color(Resource.Color.gray_20);

            mFAB.BackgroundTintList = ColorStateList.ValueOf(stateColor);// SetBackgroundTintList(ColorStateList.valueOf(getResources().getColor(R.color.gray_20)));
            mFAB.TranslationY = -Resources.GetDimension(Resource.Dimension.floating_action_button_size_half);//  SetTranslationY(-getResources().getDimension(R.dimen.floating_action_button_size_half));
            //var mFAB_OnClick = new OnClickListener(this);
            mFAB.Click += delegate {
                Intent mIntent = new Intent(this, typeof(VideoPlayerActivity));
                mIntent.PutExtra(ConstantUtil.EXTRA_CID, 1);//.getAid());
                mIntent.PutExtra(ConstantUtil.EXTRA_TITLE, "From Test");
                //mIntent.PutExtra(ConstantUtil.EXTRA_CID, v_detail.mVideoDetailsInfo.getData().getPages()[0].getCid());//.getAid());
                //mIntent.PutExtra(ConstantUtil.EXTRA_TITLE, v_detail.mVideoDetailsInfo.getData().getTitle());
                StartActivity(mIntent);
            };//   SetOnClickListener(mFAB_OnClick);

            mAppBarLayout.AddOnOffsetChangedListener(this);
            //mAppBarLayout.OffsetChanged += delegate {
            //    new OnOffsetChangedListener(this);
            //};

         

            var mAppBar_OffsetChanged = new OnOffsetChangedListener(this);
            mAppBarLayout.AddOnOffsetChangedListener(mAppBar_OffsetChanged);

            //mTvPlayer.Click += delegate
            //{
            //    mAppBar_OffsetChanged.mCurrentState = AppBarStateChangeEvent.State.EXPANDED;
            //    mTvPlayer.Visibility = ViewStates.Gone;// .setVisibility(View.GONE);
            //    mAvText.Visibility = ViewStates.Visible;// .setVisibility(View.VISIBLE);
            //    mToolbar.SetContentInsetsRelative(DisplayUtil.dp2px(BaseContext, 15), 0);
            //};

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
                mMediaController.SetTitle("123321");// setTitle(title);

                mPlayerView.SetVideoLayout(mPlayerView.Id);
                mPlayerView.SetMediaController(mMediaController);
                mPlayerView.RequestFocus();
                mPlayerView.SetMediaBufferingIndicator(mBufferingIndicator);
                mPlayerView.SetOnInfoListener(this);
                mPlayerView.SetOnSeekCompleteListener(this);
                mPlayerView.SetOnCompletionListener(this);
                mPlayerView.SetOnControllerEventsListener(this);

                //设置返回键监听
                mMediaController.SetVideoBackEvent(this);

                //LoadData();
            }
            catch (Java.Lang.Exception e)
            {
                Log.Error(TAG, "InitMediaPlayer--" + e.ToString());
            }
        }

        public void LoadData()
        {
            //throw new NotImplementedException();
            var videoPath = Android.Net.Uri.Parse("https://f.us.sinaimg.cn/002Gjiielx07pMmlxld601040201aSSp0E010.mp4?label=mp4_hd&template=854x480.28.0&Expires=1550034733&ssig=%2Bt67LHoE%2BE&KID=unistore,video");
            mPlayerView.SetVideoURI(videoPath);
            mPlayerView.SetOnPreparedListener(this);
            mPlayerView.Start();

            finishTask();
            mFAB.Clickable = false;// setClickable(false);
            Color v_color = new Color(Resource.Color.gray_20);
            
            mFAB.SetBackgroundColor(v_color);
          
            return;
        }

        public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
        {
            SetViewsTranslation(verticalOffset);
            
        }
        
        public class OnOffsetChangedListener : AppBarStateChangeEvent
        {
            private VideoDetailsActivity v_detail;
            public OnOffsetChangedListener(VideoDetailsActivity model)
            {
                v_detail = model;
            }
            

            public override void OnStateChanged(AppBarLayout appBarLayout, State state, int verticalOffset)
            {
                if (state == State.EXPANDED)
                {
                    //展开状态
                    v_detail.mTvPlayer.Visibility = ViewStates.Gone;// .setVisibility(View.GONE);
                    v_detail.mAvText.Visibility = ViewStates.Visible;// .setVisibility(View.VISIBLE);
                    v_detail.mToolbar.SetContentInsetsRelative(DisplayUtil.dp2px(v_detail.BaseContext, 15), 0);
                }
                else if (state == State.COLLAPSED)
                {
                    //折叠状态
                    v_detail.mTvPlayer.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
                    v_detail.mAvText.Visibility = ViewStates.Gone;//.setVisibility(View.GONE);
                    v_detail.mToolbar.SetContentInsetsRelative(DisplayUtil.dp2px(v_detail, 150), 0);
                }
                else
                {
                    v_detail.mTvPlayer.Visibility = ViewStates.Gone;//.setVisibility(View.GONE);
                    v_detail.mAvText.Visibility = ViewStates.Visible;//.setVisibility(View.VISIBLE);
                    v_detail.mToolbar.SetContentInsetsRelative(DisplayUtil.dp2px(v_detail, 15), 0);
                }
                //if (v_detail.mCollapsingToolbarLayout.NestedScrollingEnabled)
                //{
                   
                //}
            }
        }


        private void SetViewsTranslation(int target)
        {
            mFAB.TranslationY = target;//  .SetTranslationY(target);
            if (target == 0)
            {
                ShowFAB();
            }
            else if (target < 0)
            {
                HideFAB();
            }
        }

        private void ShowFAB()
        {
            mFAB.Animate().ScaleX(1f).ScaleY(1f)
                    .SetInterpolator(new OvershootInterpolator())
                    .Start();
            mFAB.Clickable = true;// SetClickable(true);
        }

        private void HideFAB()
        {
            mFAB.Animate().ScaleX(0f).ScaleY(0f)
                    .SetInterpolator(new AccelerateInterpolator())
                    .Start();
            mFAB.Clickable = false;// setClickable(false);
        }

        //    public static void Launch(Android.App.Activity activity, int aid, String imgUrl)
        //    {
        //        Intent intent = new Intent(activity, typeof(VideoDetailsActivity));//.class);
        //        intent.AddFlags(ActivityFlags.NewTask);//  Intent.FLAG_ACTIVITY_NEW_TASK);
        //        intent.PutExtra(ConstantUtil.EXTRA_AV, aid);
        //        intent.PutExtra(ConstantUtil.EXTRA_IMG_URL, imgUrl);
        //        activity.StartActivity(intent);
        //    }

        public void finishTask()
        {
            mFAB.Clickable = true;// setClickable(true);
            Color mFAB_color = new Color(Resource.Color.colorPrimary);

            mFAB.BackgroundTintList = ColorStateList.ValueOf(mFAB_color);
            //SetBackgroundTintList(
            //    ColorStateList.valueOf(getResources().getColor(R.color.colorPrimary)));
            mCollapsingToolbarLayout.Title = "";//.setTitle("");
            if (Android.Text.TextUtils.IsEmpty(imgUrl))
            {
                //Glide.with(VideoDetailsActivity.this)
                //        .load(mVideoDetailsInfo)
                //        .centerCrop()
                //        .diskCacheStrategy(DiskCacheStrategy.ALL)
                //        .placeholder(R.drawable.bili_default_image_tv)
                //        .dontAnimate()
                //        .into(mVideoPreview);
            }

            VideoIntroductionFragment mVideoIntroductionFragment = VideoIntroductionFragment.newInstance(av);
            //VideoCommentFragment mVideoCommentFragment = VideoCommentFragment.newInstance(av);
            var accountFragment = new FragmentAccount();
            var homeFragment = new FragmentHome();
            fragments.Add(mVideoIntroductionFragment);
            fragments.Add(homeFragment);

            //SetPagerTitle(mVideoDetailsInfo.getData().getStat().getReply().ToString());//  String.valueOf(mVideoDetailsInfo.getStat().getReply()));
            SetPagerTitle("123");
        }

        private void SetPagerTitle(string num)
        {
            titles[0] = "简介";// .Add("简介");
            titles[1] = "评论" + "(" + num + ")";//.Add("评论" + "(" + num + ")");
            VideoDetailsPagerAdapter mAdapter = new VideoDetailsPagerAdapter(SupportFragmentManager, fragments, titles);
            mViewPager.Adapter = mAdapter;// SetAdapter(mAdapter);
            //mViewPager.OffscreenPageLimit = 2;// SetOffscreenPageLimit(2);
            mSlidingTabLayout.SetViewPager(mViewPager);
            MeasureTabLayoutTextWidth(0);
            //var vdaonpagechangeListenter = new VDA_OnPageChangeListener(this);
            mViewPager.AddOnPageChangeListener(this);
        }

        public void OnPageScrollStateChanged(int state)
        {
            return;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            return;
        }

        public void OnPageSelected(int position)
        {
            return;
            //MeasureTabLayoutTextWidth(position);
        }

        private void MeasureTabLayoutTextWidth(int position)
        {
            string title = titles[position].ToString();
            TextView titleView = mSlidingTabLayout.GetTitleView(position);
            Android.Text.TextPaint paint = titleView.Paint;//.GetPaint();
            float textWidth = paint.MeasureText(title);
            mSlidingTabLayout.IndicatorWidth = textWidth;// / 3;//.SetIndicatorWidth(textWidth / 3);
        }

        public class VideoDetailsPagerAdapter : FragmentStatePagerAdapter
        {
            private List<Android.Support.V4.App.Fragment> fragments;
            private Java.Lang.String[] titles  = new Java.Lang.String[2];
            public override int Count => fragments == null ? 0 : GetCount();

            public VideoDetailsPagerAdapter(FragmentManager fm, List<Fragment> fragments, string[] titlesList) : base(fm)
            {
                this.fragments = fragments;
                for (int i = 0; i < titlesList.Length; i++)
                {
                    titles[i] = new Java.Lang.String(titlesList[i]);
                }
                //this.titles = titlesList;
            }

            public override Fragment GetItem(int position)
            {
                return fragments[position];
            }

            public int GetCount()
            {
                return fragments.Count();
            }

            public  ICharSequence GetPageTitle(int position)
            {
                return titles[position]; //CharSequence.ArrayFromStringArray(new string[] { titles[position] })[0];
            }
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return titles[position];
            }
        }

        public static T Cast<T>(List<string> obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }

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
           // mAppBarLayout.NestedScrollingEnabled = true;
            return;
        }
        /**
        * 控制条控制状态事件回调
        */
        public void OnVideoResume()
        {

            //if(mPlayerView.IsPlaying())
            //mAppBarLayout.NestedScrollingEnabled = false;
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
            //mAppBarLayout.NestedScrollingEnabled = false;
            //mLoadingAnim.Stop();
            //startText = startText + "【完成】\n视频缓冲中...";
            //mPrepareText.SetText(startText, BufferType.Normal);
            //mVideoPrepareLayout.Visibility = ViewStates.Gone;
        }

        public void Back()
        {
            OnBackPressed();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();

            //if (mLoadingAnim != null)
            //{
            //    mLoadingAnim.Stop();
            //    mLoadingAnim = null;
            //}
        }
        #endregion
    }

}
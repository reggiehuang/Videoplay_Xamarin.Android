using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Flyco.Tablayout;
using Com.Flyco.Tablayout.Listener;
using Java.Lang;
using VideoPlayerDemo.Acticity.Adapter;
using static Android.Support.V4.View.ViewPager;

namespace VideoPlayerDemo.Acticity
{
    [Activity(Label = "TestTabActivity")]
    public class TestTabActivity : AppCompatActivity, IOnTabSelectListener, IOnPageChangeListener
    {
        private static List<Android.Support.V4.App.Fragment> mFragments = new List<Android.Support.V4.App.Fragment>();
        private static System.String[] mTitles = {
            "热门", "IOS", "Android"
            , "前端", "后端", "设计", "工具资源"
    };

        private MyPagerAdapter mAdapter;

        SlidingTabLayout mSlidingTabLayout;
        ViewPager mViewPager;

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            return;
        }

        public void OnPageScrollStateChanged(int state)
        {
            return;
        }

        public void OnPageSelected(int position)
        {
            MeasureTabLayoutTextWidth(position);
            //return;
        }

        public void OnTabReselect(int p0)
        {
            return;
        }

        public void OnTabSelect(int p0)
        {
            return;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_test_tab);//.test.layout.activity_main2);
            // Create your application here
            
            foreach (var item in mTitles)
            {
                if (item == "IOS")
                {
                    VideoIntroductionFragment mVideoIntroductionFragment = VideoIntroductionFragment.newInstance(1);
                    mFragments.Add(mVideoIntroductionFragment);
                }
                else
                {
                    mFragments.Add(SimpleCardFragment.getInstance(item));
                }
                
            }

            mSlidingTabLayout = FindViewById<SlidingTabLayout>(Resource.Id.tab_layout);
            mViewPager = FindViewById<ViewPager>(Resource.Id.view_pager);


            mAdapter = new MyPagerAdapter(SupportFragmentManager);
            mViewPager.Adapter = mAdapter;// SetAdapter(mAdapter);
            //mViewPager.OffscreenPageLimit = 2;// SetOffscreenPageLimit(2);
            mSlidingTabLayout.SetViewPager(mViewPager);
            MeasureTabLayoutTextWidth(0);
            //var vdaonpagechangeListenter = new VDA_OnPageChangeListener(this);
            mViewPager.AddOnPageChangeListener(this);
        }


        private void MeasureTabLayoutTextWidth(int position)
        {
            string title = mTitles[position].ToString();
            TextView titleView = mSlidingTabLayout.GetTitleView(position);
            Android.Text.TextPaint paint = titleView.Paint;//.GetPaint();
            float textWidth = paint.MeasureText(title);
            mSlidingTabLayout.IndicatorWidth = textWidth / 3;//.SetIndicatorWidth(textWidth / 3);
        }


        private class MyPagerAdapter : FragmentPagerAdapter
        {
            public override int Count => GetCount();

            public MyPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {

            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return mFragments[position];
            }

            public int GetCount()
            {
                return mTitles.Count();
            }

            //public ICharSequence GetPageTitle(int position)
            //{
            //    return mTitles[position]; //CharSequence.ArrayFromStringArray(new string[] { titles[position] })[0];
            //}
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return CharSequence.ArrayFromStringArray(new string[] { mTitles[position] })[0]; ;// mTitles[position];
            }

            //    @Override
            //public int getCount()
            //{
            //    return mFragments.size();
            //}

            //@Override
            //public CharSequence getPageTitle(int position)
            //{
            //    return mTitles[position];
            //}


            //public override Fragment GetItem(int position)
            //{
            //    return mFragments.get(position);
            //}
        }
    }
}
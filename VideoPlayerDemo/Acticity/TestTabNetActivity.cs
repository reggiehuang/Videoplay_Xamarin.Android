using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Acticity
{
    [Activity(Label = "TestTabNetActivity")]
    public class TestTabNetActivity : FragmentActivity
    {
        private Handler _handler = new Handler();
        private PagerSlidingTabStrip.PagerSlidingTabStrip _tabs;
        private ViewPager _pager;
        private MyPagerAdapter _adapter;
        private bool _useAdapter2;

        private Drawable _oldBackground = null;
        private Color _currentColor = Color.Argb(0xff, 0x66, 0x66, 0x66);

        private static List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();

        public class MyPagerAdapter : FragmentPagerAdapter
        {
            private Android.Support.V4.App.FragmentManager SupportFragmentManager;

            public MyPagerAdapter(Android.Support.V4.App.FragmentManager SupportFragmentManager)
                : base(SupportFragmentManager)
            {
                // TODO: Complete member initialization
                this.SupportFragmentManager = SupportFragmentManager;
               // _count = SharedState.Count != 0 ? SharedState.Count : Titles.Length;
                _titles = new string[Titles.Length];
                Array.Copy(Titles, _titles, Titles.Length);
                //if (_count != SharedState.Count)
                //    SharedState.Count = _count;
            }

            protected internal static readonly string[] Titles = { "Categories", "Home", "Top Paid", "Top Free", "Top Grossing", "Top New Paid",
                                                                    "Top New Free", "Trending" };

            protected internal static readonly string[] Titles2 = Titles.Select(s => s + " (Alt)").ToArray();

            protected internal readonly string[] _titles;

            //protected virtual SuperAwesomeCardFragment CreateAwesomeFragment(int position)
            //{
            //    return new SuperAwesomeCardFragment();
            //}

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                Android.Util.Log.Info("MyPagerAdapter", string.Format("GetItem being called for position {0}", position));
                var toReturn = fragments[position];
                return toReturn;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                Android.Util.Log.Info("MyPagerAdapter", string.Format("InstantiateItem being called for position {0}", position));
                var result = base.InstantiateItem(container, position);
                //SuperAwesomeCardFragment frag = result as SuperAwesomeCardFragment;
                //if (frag != null)
                //{
                //    Configure(frag, position);
                //    frag.ChangeTitleRequested += toReturn_ChangeTitleRequested;
                //}
                return result;
            }

            //protected virtual void Configure(SuperAwesomeCardFragment frag, int position)
            //{
            //    frag.Configure(position, false);
            //}

            void toReturn_ChangeTitleRequested(object sender, int e)
            {
                ChangeTitle(e);
            }

            private int _count;
            public override int Count
            {
                get { return _count; }
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(_titles[position]);
            }

            /// <summary>
            /// used to demonstrate how the control can respond to tabs being added and removed.
            /// </summary>
            /// <param name="count"></param>
            public void SetCount(int count)
            {
                if (count < 0 || count > Titles.Length)
                    return;

                _count = count;
                //SharedState.Count = count;
                NotifyDataSetChanged();
            }

            public virtual void ChangeTitle(int position)
            {
                if (_titles[position] == Titles[position])
                {
                    _titles[position] = Titles2[position];
                }
                else
                {
                    _titles[position] = Titles[position];
                }
                //this one has to do it this way because 
                NotifyDataSetChanged();
            }
        }


        private class DrawableCallback : Java.Lang.Object, Drawable.ICallback
        {
            TestTabNetActivity _activity;

            public DrawableCallback(TestTabNetActivity activity)
            {
                _activity = activity;
            }

            #region ICallback Members

            public void InvalidateDrawable(Drawable who)
            {
                _activity.ActionBar.SetBackgroundDrawable(who);
            }

            public void ScheduleDrawable(Drawable who, Java.Lang.IRunnable what, long when)
            {
                _activity._handler.PostAtTime(what, when);
            }

            public void UnscheduleDrawable(Drawable who, Java.Lang.IRunnable what)
            {
                _activity._handler.RemoveCallbacks(what);
            }

            #endregion
        }

        private DrawableCallback _drawableCallback;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layout_test_slidingtab_net);

            if (bundle != null)
            {
                _useAdapter2 = bundle.GetBoolean("useAdapter2", false);
                var colorInt = bundle.GetInt("color", -1);
                if (colorInt != -1)
                    _currentColor = new Color(colorInt);
            }

            _drawableCallback = new DrawableCallback(this);
            _tabs = FindViewById<PagerSlidingTabStrip.PagerSlidingTabStrip>(Resource.Id.tabs);
            _pager = FindViewById<ViewPager>(Resource.Id.pager);

            int pageMargin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            _pager.PageMargin = pageMargin;
            //_pager.Adapter = _adapter;

            InitAdapter();

        }

        private void InitAdapter()
        {
            var accountFragment = new FragmentAccount();
            var homeFragment = new FragmentHome();
            fragments.Add(accountFragment);
            fragments.Add(homeFragment);

            _pager.Adapter = null;
            var oldAdapter = _adapter;
            _adapter = null;// _useAdapter2 ? new MyPagerAdapter2(this, SupportFragmentManager) : new MyPagerAdapter(SupportFragmentManager);
            _pager.Adapter = _adapter;
            _tabs.SetViewPager(_pager);
            //have to dispose it after we've set the view pager, otherwise an error occurs because we've dumped out
            //the Java Reference.
            if (oldAdapter != null)
            {
                oldAdapter.Dispose();
            }
        }
    }
}
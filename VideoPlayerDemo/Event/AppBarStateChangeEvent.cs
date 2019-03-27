using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Event
{
    /**
   * Created by hcc on 16/9/20 05:32
   * 100332338@qq.com
   * <p>
   * 监听CollapsingToolbarLayout的折叠状态
   */

    public abstract class AppBarStateChangeEvent : Java.Lang.Object, AppBarLayout.IOnOffsetChangedListener
    {
        public enum State
        {
            EXPANDED,
            COLLAPSED,
            IDLE
        }

        public State mCurrentState = State.IDLE;


        public abstract void OnStateChanged(AppBarLayout appBarLayout, State state, int verticalOffset);

        public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
        {
            if (verticalOffset == 0)
            {
                if (mCurrentState != State.EXPANDED)
                {
                    OnStateChanged(appBarLayout, State.EXPANDED, verticalOffset);
                }
                mCurrentState = State.EXPANDED;
            }
            else if (Math.Abs(verticalOffset) >= appBarLayout.TotalScrollRange)
            {
                if (mCurrentState != State.COLLAPSED)
                {
                    OnStateChanged(appBarLayout, State.COLLAPSED, verticalOffset);
                }
                mCurrentState = State.COLLAPSED;
            }
            else
            {
                if (mCurrentState != State.IDLE)
                {
                    OnStateChanged(appBarLayout, State.IDLE, verticalOffset);
                }
                mCurrentState = State.IDLE;
            }
        }


    }
}
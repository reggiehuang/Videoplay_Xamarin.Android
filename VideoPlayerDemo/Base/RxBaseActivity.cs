using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Trello.Rxlifecycle2;
//using Butterknife;
using Android.Support.V7.App;
using IO.Reactivex;
using VideoPlayerDemo.Base;

namespace VideoPlayerDemo.Base
{
    public abstract class RxBaseActivity : RxAppCompatActivity
    {
        //private IUnbinder bind;
         
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //设置布局内容
            SetContentView(getLayoutId());

            //初始化黄油刀控件绑定框架
            // bind = ButterKnife.Bind(this);//  .Bind(this);
            //初始化控件
            initViews(savedInstanceState);
            //初始化ToolBar
            initToolBar();
        }


        /**
         * 设置布局layout
         *
         * @return
         */
        public abstract int getLayoutId();

        /**
         * 初始化views
         *
         * @param savedInstanceState
         */
        public abstract void initViews(Bundle savedInstanceState);

        /**
         * 初始化toolbar
         */
        public abstract void initToolBar();

        /**
         * 加载数据
         */
        public void loadData()
        { }


        /**
         * 显示进度条
         */
        public void showProgressBar()
        {
        }

        /**
         * 隐藏进度条
         */
        public void hideProgressBar()
        {
        }

        /**
         * 初始化recyclerView
         */
        public void initRecyclerView()
        {
        }

        /**
         * 初始化refreshLayout
         */
        public void initRefreshLayout()
        {
        }

        /**
         * 设置数据显示
         */
        public void finishTask()
        {
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            //bind.Unbind();//  unbind();
        }
    }
}
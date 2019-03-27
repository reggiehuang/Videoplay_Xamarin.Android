using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
//using Butterknife;


namespace VideoPlayerDemo.Base
{
    public abstract class RxLazyFragment : RxFragment
    {
        private View parentView;
        private FragmentActivity activity;
        // 标志位 标志已经初始化完成。
        protected bool isPrepared;
        //标志位 fragment是否可见
        protected bool isVisible;
        

        public abstract int getLayoutResId();



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }


        //        onViewCreated在onCreateView执行完后立即执行。
        //onCreateView返回的就是fragment要显示的view。
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle state)
        {
            parentView = inflater.Inflate(getLayoutResId(), container, false);
            activity = GetSupportActivity();
            return parentView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            finishCreateView(savedInstanceState);
        }

        /**
         * 初始化views
         *
         * @param state
         */
        public abstract void finishCreateView(Bundle state);


        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            
        }


        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);
            this.activity = (FragmentActivity)this.Activity;
        }


        public override void OnDetach()
        {
            base.OnDetach();
            this.activity = null;
        }


        public FragmentActivity GetSupportActivity()
        {
            return (FragmentActivity)this.Activity; //base.ParentFragment.Activity;//.GetActivity();
        }


        public Android.App.ActionBar GetSupportActionBar()
        {
            return GetSupportActivity().ActionBar;//.GetActionBar();
        }


        public Context GetApplicationContext()
        {
            return this.Activity == null ? null : this.Activity.ApplicationContext;

            //(GeetActivity() == null ?null : GetActivity().GetApplicationContext()) 
            //: this.activity.ApplicationInfo;
        }


        /**
         * Fragment数据的懒加载
         */
        public void SetUserVisibleHint(bool isVisibleToUser)
        {
            //base.SetUserVisibleHint(isVisibleToUser);
            if (UserVisibleHint)//
            {
                isVisible = true;
                onVisible();
            }
            else
            {
                isVisible = false;
                onInvisible();
            }
        }

        /**
         * fragment显示时才加载数据
         */
        protected void onVisible()
        {
            lazyLoad();
        }

        /**
         * fragment懒加载方法
         */
        protected void lazyLoad()
        {
        }

        /**
         * fragment隐藏
         */
        protected void onInvisible()
        {
        }

        /**
         * 加载数据
         */
        protected void loadData()
        {
        }

        /**
         * 显示进度条
         */
        protected void showProgressBar()
        {
        }

        /**
         * 隐藏进度条
         */
        protected void hideProgressBar()
        {
        }

        /**
         * 初始化recyclerView
         */
        protected void initRecyclerView()
        {
        }

        /**
         * 初始化refreshLayout
         */
        protected void initRefreshLayout()
        {
        }

        /**
         * 设置数据显示
         */
        protected void finishTask()
        {
        }

        public T GetViewById<T>(int id) where T : View
        {
            return (T)parentView.FindViewById(id);
        }

    }
}
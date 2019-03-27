using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Trello.Rxlifecycle2;
using Com.Trello.Rxlifecycle2.Android;
using IO.Reactivex;
using IO.Reactivex.Subjects;

namespace VideoPlayerDemo.Base
{
    public class RxFragment : Android.Support.V4.App.Fragment, ILifecycleProvider
    {
        private BehaviorSubject lifecycleSubject = BehaviorSubject.Create();

        public LifecycleTransformer BindToLifecycle()
        {
            return RxLifecycleAndroid.BindFragment(lifecycleSubject);
        }

        public LifecycleTransformer BindUntilEvent(Java.Lang.Object p0)
        {
            return RxLifecycle.BindUntilEvent(lifecycleSubject, p0);
        }

        //public Observable ILifecycleProvider.Lifecycle()
        //{
        //    //throw new NotImplementedException();
        //    return lifecycleSubject.Hide();
        //}

        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);
            lifecycleSubject.OnNext(FragmentEvent.Attach);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            lifecycleSubject.OnNext(FragmentEvent.Create);
            // Create your application here
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            lifecycleSubject.OnNext(FragmentEvent.CreateView);
        }


        public override void OnStart()
        {
            base.OnStart();
            //lifecycleSubject.OnNext(ActivityEvent.Start);

            lifecycleSubject.OnNext(FragmentEvent.Start);
        }

        public override void OnResume()
        {
            base.OnResume();
            //lifecycleSubject.OnNext(ActivityEvent.Resume);

            lifecycleSubject.OnNext(FragmentEvent.Resume);
        }
        public override void OnPause()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Pause);

            lifecycleSubject.OnNext(FragmentEvent.Pause);
            base.OnPause();
        }
        public override void OnStop()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Stop);

            lifecycleSubject.OnNext(FragmentEvent.Stop);
            base.OnStop();
        }

        public override void OnDestroyView()
        {

            lifecycleSubject.OnNext(FragmentEvent.DestroyView);
            base.OnDestroyView();
        }

        public override void OnDestroy()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Destroy);

            lifecycleSubject.OnNext(FragmentEvent.Destroy);
            base.OnDestroy();
        }

        public override void OnDetach()
        {
            lifecycleSubject.OnNext(FragmentEvent.Detach);
            base.OnDetach();
        }

        IO.Reactivex.Observable ILifecycleProvider.Lifecycle()
        {
            return lifecycleSubject.Hide();
        }
    }
}
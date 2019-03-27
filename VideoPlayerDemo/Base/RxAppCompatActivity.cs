using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Trello.Rxlifecycle2;
using Com.Trello.Rxlifecycle2.Android;
using IO.Reactivex;
using IO.Reactivex.Subjects;
using Java.Lang;

namespace VideoPlayerDemo.Base
{
    public abstract class RxAppCompatActivity : AppCompatActivity, ILifecycleProvider
    {

        private BehaviorSubject lifecycleSubject = BehaviorSubject.Create();
        private ActivityEvent activityEvent;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activityEvent = ActivityEvent.Create;
            lifecycleSubject.OnNext(activityEvent);
        }

        protected override void OnStart()
        {
            base.OnStart();
            //lifecycleSubject.OnNext(ActivityEvent.Start);
            activityEvent = ActivityEvent.Start;
            lifecycleSubject.OnNext(activityEvent);
        }

        protected override void OnResume()
        {
            base.OnResume();
            //lifecycleSubject.OnNext(ActivityEvent.Resume);
            activityEvent = ActivityEvent.Resume;
            lifecycleSubject.OnNext(activityEvent);
        }
        protected override void OnPause()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Pause);
            activityEvent = ActivityEvent.Pause;
            lifecycleSubject.OnNext(activityEvent);
            base.OnPause();
        }
        protected override void OnStop()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Stop);
            activityEvent = ActivityEvent.Stop;
            lifecycleSubject.OnNext(activityEvent);
            base.OnStop();
        }


        protected override void OnDestroy()
        {
            //lifecycleSubject.OnNext(ActivityEvent.Destroy);
            activityEvent = ActivityEvent.Destroy;
            lifecycleSubject.OnNext(activityEvent);
            base.OnDestroy();
        }

        public LifecycleTransformer BindToLifecycle()
        {
            return RxLifecycleAndroid.BindActivity(lifecycleSubject);
        }

        public LifecycleTransformer BindUntilEvent(Java.Lang.Object p0)
        {
            return RxLifecycle.BindUntilEvent(lifecycleSubject, p0);

        }

        Observable ILifecycleProvider.Lifecycle()
        {
            return lifecycleSubject.Hide();
        }
    }
}
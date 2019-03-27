package md5d81be01db7095856d78a9ebbd6c6a9a1;


public abstract class RxAppCompatActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		com.trello.rxlifecycle2.LifecycleProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_bindToLifecycle:()Lcom/trello/rxlifecycle2/LifecycleTransformer;:GetBindToLifecycleHandler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"n_bindUntilEvent:(Ljava/lang/Object;)Lcom/trello/rxlifecycle2/LifecycleTransformer;:GetBindUntilEvent_Ljava_lang_Object_Handler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"n_lifecycle:()Lio/reactivex/Observable;:GetLifecycleHandler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Base.RxAppCompatActivity, VideoPlayerDemo", RxAppCompatActivity.class, __md_methods);
	}


	public RxAppCompatActivity ()
	{
		super ();
		if (getClass () == RxAppCompatActivity.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Base.RxAppCompatActivity, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public com.trello.rxlifecycle2.LifecycleTransformer bindToLifecycle ()
	{
		return n_bindToLifecycle ();
	}

	private native com.trello.rxlifecycle2.LifecycleTransformer n_bindToLifecycle ();


	public com.trello.rxlifecycle2.LifecycleTransformer bindUntilEvent (java.lang.Object p0)
	{
		return n_bindUntilEvent (p0);
	}

	private native com.trello.rxlifecycle2.LifecycleTransformer n_bindUntilEvent (java.lang.Object p0);


	public io.reactivex.Observable lifecycle ()
	{
		return n_lifecycle ();
	}

	private native io.reactivex.Observable n_lifecycle ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

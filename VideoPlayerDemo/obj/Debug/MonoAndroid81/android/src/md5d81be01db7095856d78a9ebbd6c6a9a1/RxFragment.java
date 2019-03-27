package md5d81be01db7095856d78a9ebbd6c6a9a1;


public class RxFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer,
		com.trello.rxlifecycle2.LifecycleProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttach:(Landroid/app/Activity;)V:GetOnAttach_Landroid_app_Activity_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onViewCreated:(Landroid/view/View;Landroid/os/Bundle;)V:GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onDestroyView:()V:GetOnDestroyViewHandler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onDetach:()V:GetOnDetachHandler\n" +
			"n_bindToLifecycle:()Lcom/trello/rxlifecycle2/LifecycleTransformer;:GetBindToLifecycleHandler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"n_bindUntilEvent:(Ljava/lang/Object;)Lcom/trello/rxlifecycle2/LifecycleTransformer;:GetBindUntilEvent_Ljava_lang_Object_Handler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"n_lifecycle:()Lio/reactivex/Observable;:GetLifecycleHandler:Com.Trello.Rxlifecycle2.ILifecycleProviderInvoker, ICE.RxLifecycle.Droid\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Base.RxFragment, VideoPlayerDemo", RxFragment.class, __md_methods);
	}


	public RxFragment ()
	{
		super ();
		if (getClass () == RxFragment.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Base.RxFragment, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onAttach (android.app.Activity p0)
	{
		n_onAttach (p0);
	}

	private native void n_onAttach (android.app.Activity p0);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onViewCreated (android.view.View p0, android.os.Bundle p1)
	{
		n_onViewCreated (p0, p1);
	}

	private native void n_onViewCreated (android.view.View p0, android.os.Bundle p1);


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


	public void onDestroyView ()
	{
		n_onDestroyView ();
	}

	private native void n_onDestroyView ();


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onDetach ()
	{
		n_onDetach ();
	}

	private native void n_onDetach ();


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

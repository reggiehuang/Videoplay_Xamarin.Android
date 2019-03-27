package md5d81be01db7095856d78a9ebbd6c6a9a1;


public abstract class RxBaseActivity
	extends md5d81be01db7095856d78a9ebbd6c6a9a1.RxAppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Base.RxBaseActivity, VideoPlayerDemo", RxBaseActivity.class, __md_methods);
	}


	public RxBaseActivity ()
	{
		super ();
		if (getClass () == RxBaseActivity.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Base.RxBaseActivity, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

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

package mono.com.flyco.tablayout.listener;


public class OnTabSelectListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.flyco.tablayout.listener.OnTabSelectListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTabReselect:(I)V:GetOnTabReselect_IHandler:Com.Flyco.Tablayout.Listener.IOnTabSelectListenerInvoker, Binding_FlycoTabLayoutLib\n" +
			"n_onTabSelect:(I)V:GetOnTabSelect_IHandler:Com.Flyco.Tablayout.Listener.IOnTabSelectListenerInvoker, Binding_FlycoTabLayoutLib\n" +
			"";
		mono.android.Runtime.register ("Com.Flyco.Tablayout.Listener.IOnTabSelectListenerImplementor, Binding_FlycoTabLayoutLib", OnTabSelectListenerImplementor.class, __md_methods);
	}


	public OnTabSelectListenerImplementor ()
	{
		super ();
		if (getClass () == OnTabSelectListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Flyco.Tablayout.Listener.IOnTabSelectListenerImplementor, Binding_FlycoTabLayoutLib", "", this, new java.lang.Object[] {  });
	}


	public void onTabReselect (int p0)
	{
		n_onTabReselect (p0);
	}

	private native void n_onTabReselect (int p0);


	public void onTabSelect (int p0)
	{
		n_onTabSelect (p0);
	}

	private native void n_onTabSelect (int p0);

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

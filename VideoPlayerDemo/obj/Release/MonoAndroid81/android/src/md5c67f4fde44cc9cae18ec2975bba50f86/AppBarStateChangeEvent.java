package md5c67f4fde44cc9cae18ec2975bba50f86;


public abstract class AppBarStateChangeEvent
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.AppBarLayout.OnOffsetChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOffsetChanged:(Landroid/support/design/widget/AppBarLayout;I)V:GetOnOffsetChanged_Landroid_support_design_widget_AppBarLayout_IHandler:Android.Support.Design.Widget.AppBarLayout/IOnOffsetChangedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Event.AppBarStateChangeEvent, VideoPlayerDemo", AppBarStateChangeEvent.class, __md_methods);
	}


	public AppBarStateChangeEvent ()
	{
		super ();
		if (getClass () == AppBarStateChangeEvent.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Event.AppBarStateChangeEvent, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1)
	{
		n_onOffsetChanged (p0, p1);
	}

	private native void n_onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1);

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

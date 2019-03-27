package md5674a3a834b96a12ba7ca87cec1b85ae9;


public class SlidingTabLayoutPlus_V_OnClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Widget.SlidingTabLayoutPlus+V_OnClickListener, VideoPlayerDemo", SlidingTabLayoutPlus_V_OnClickListener.class, __md_methods);
	}


	public SlidingTabLayoutPlus_V_OnClickListener ()
	{
		super ();
		if (getClass () == SlidingTabLayoutPlus_V_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.SlidingTabLayoutPlus+V_OnClickListener, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public SlidingTabLayoutPlus_V_OnClickListener (android.support.v4.view.ViewPager p0, android.widget.LinearLayout p1, com.flyco.tablayout.listener.OnTabSelectListener p2, boolean p3)
	{
		super ();
		if (getClass () == SlidingTabLayoutPlus_V_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.SlidingTabLayoutPlus+V_OnClickListener, VideoPlayerDemo", "Android.Support.V4.View.ViewPager, Xamarin.Android.Support.Core.UI:Android.Widget.LinearLayout, Mono.Android:Com.Flyco.Tablayout.Listener.IOnTabSelectListener, Binding_FlycoTabLayoutLib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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

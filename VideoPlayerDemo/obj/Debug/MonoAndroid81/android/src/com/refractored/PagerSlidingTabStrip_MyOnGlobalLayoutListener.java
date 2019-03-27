package com.refractored;


public class PagerSlidingTabStrip_MyOnGlobalLayoutListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("com.refractored.PagerSlidingTabStrip+MyOnGlobalLayoutListener, Refractored.PagerSlidingTabStrip", PagerSlidingTabStrip_MyOnGlobalLayoutListener.class, __md_methods);
	}


	public PagerSlidingTabStrip_MyOnGlobalLayoutListener ()
	{
		super ();
		if (getClass () == PagerSlidingTabStrip_MyOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("com.refractored.PagerSlidingTabStrip+MyOnGlobalLayoutListener, Refractored.PagerSlidingTabStrip", "", this, new java.lang.Object[] {  });
	}

	public PagerSlidingTabStrip_MyOnGlobalLayoutListener (com.refractored.PagerSlidingTabStrip p0)
	{
		super ();
		if (getClass () == PagerSlidingTabStrip_MyOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("com.refractored.PagerSlidingTabStrip+MyOnGlobalLayoutListener, Refractored.PagerSlidingTabStrip", "com.refractored.PagerSlidingTabStrip, Refractored.PagerSlidingTabStrip", this, new java.lang.Object[] { p0 });
	}


	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

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

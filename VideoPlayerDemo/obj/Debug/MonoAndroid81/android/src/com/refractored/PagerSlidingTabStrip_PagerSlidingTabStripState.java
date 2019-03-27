package com.refractored;


public class PagerSlidingTabStrip_PagerSlidingTabStripState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler\n" +
			"n_InitializeCreator:()Lcom/refractored/PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator;:__export__\n" +
			"";
		mono.android.Runtime.register ("com.refractored.PagerSlidingTabStrip+PagerSlidingTabStripState, Refractored.PagerSlidingTabStrip", PagerSlidingTabStrip_PagerSlidingTabStripState.class, __md_methods);
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcel p0)
	{
		super (p0);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("com.refractored.PagerSlidingTabStrip+PagerSlidingTabStripState, Refractored.PagerSlidingTabStrip", "Android.OS.Parcel, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcel p0, java.lang.ClassLoader p1)
	{
		super (p0, p1);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("com.refractored.PagerSlidingTabStrip+PagerSlidingTabStripState, Refractored.PagerSlidingTabStrip", "Android.OS.Parcel, Mono.Android:Java.Lang.ClassLoader, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public PagerSlidingTabStrip_PagerSlidingTabStripState (android.os.Parcelable p0)
	{
		super (p0);
		if (getClass () == PagerSlidingTabStrip_PagerSlidingTabStripState.class)
			mono.android.TypeManager.Activate ("com.refractored.PagerSlidingTabStrip+PagerSlidingTabStripState, Refractored.PagerSlidingTabStrip", "Android.OS.IParcelable, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	private static com.refractored.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator CREATOR = InitializeCreator ();


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

	private static com.refractored.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator InitializeCreator ()
	{
		return n_InitializeCreator ();
	}

	private static native com.refractored.PagerSlidingTabStrip_PagerSlidingTabStripState_SavedStateCreator n_InitializeCreator ();

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

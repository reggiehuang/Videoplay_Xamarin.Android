package md5674a3a834b96a12ba7ca87cec1b85ae9;


public class CircleProgressView_WheelSavedState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_GetCreator:()Lmd5674a3a834b96a12ba7ca87cec1b85ae9/CircleProgressView_WheelSavedState_WheelSavedStateCreator;:__export__\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Widget.CircleProgressView+WheelSavedState, VideoPlayerDemo", CircleProgressView_WheelSavedState.class, __md_methods);
	}


	public CircleProgressView_WheelSavedState (android.os.Parcel p0)
	{
		super (p0);
		if (getClass () == CircleProgressView_WheelSavedState.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.CircleProgressView+WheelSavedState, VideoPlayerDemo", "Android.OS.Parcel, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CircleProgressView_WheelSavedState (android.os.Parcelable p0)
	{
		super (p0);
		if (getClass () == CircleProgressView_WheelSavedState.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.CircleProgressView+WheelSavedState, VideoPlayerDemo", "Android.OS.IParcelable, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public static md5674a3a834b96a12ba7ca87cec1b85ae9.CircleProgressView_WheelSavedState_WheelSavedStateCreator CREATOR = GetCreator ();

	public static md5674a3a834b96a12ba7ca87cec1b85ae9.CircleProgressView_WheelSavedState_WheelSavedStateCreator GetCreator ()
	{
		return n_GetCreator ();
	}

	private static native md5674a3a834b96a12ba7ca87cec1b85ae9.CircleProgressView_WheelSavedState_WheelSavedStateCreator n_GetCreator ();

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

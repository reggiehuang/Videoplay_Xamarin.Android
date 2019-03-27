package md5674a3a834b96a12ba7ca87cec1b85ae9;


public class CircleProgressView_WheelSavedState_WheelSavedStateCreator
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.os.Parcelable.Creator
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_createFromParcel:(Landroid/os/Parcel;)Ljava/lang/Object;:GetCreateFromParcel_Landroid_os_Parcel_Handler:Android.OS.IParcelableCreatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_newArray:(I)[Ljava/lang/Object;:GetNewArray_IHandler:Android.OS.IParcelableCreatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Widget.CircleProgressView+WheelSavedState+WheelSavedStateCreator, VideoPlayerDemo", CircleProgressView_WheelSavedState_WheelSavedStateCreator.class, __md_methods);
	}


	public CircleProgressView_WheelSavedState_WheelSavedStateCreator ()
	{
		super ();
		if (getClass () == CircleProgressView_WheelSavedState_WheelSavedStateCreator.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.CircleProgressView+WheelSavedState+WheelSavedStateCreator, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object createFromParcel (android.os.Parcel p0)
	{
		return n_createFromParcel (p0);
	}

	private native java.lang.Object n_createFromParcel (android.os.Parcel p0);


	public java.lang.Object[] newArray (int p0)
	{
		return n_newArray (p0);
	}

	private native java.lang.Object[] n_newArray (int p0);

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

package md5674a3a834b96a12ba7ca87cec1b85ae9;


public class UserTagView
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setOnClickListener:(Landroid/view/View$OnClickListener;)V:GetSetOnClickListener_Landroid_view_View_OnClickListener_Handler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", UserTagView.class, __md_methods);
	}


	public UserTagView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == UserTagView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public UserTagView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == UserTagView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public UserTagView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == UserTagView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public UserTagView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == UserTagView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void setOnClickListener (android.view.View.OnClickListener p0)
	{
		n_setOnClickListener (p0);
	}

	private native void n_setOnClickListener (android.view.View.OnClickListener p0);

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

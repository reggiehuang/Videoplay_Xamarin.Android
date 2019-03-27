package md5674a3a834b96a12ba7ca87cec1b85ae9;


public class UserTagView_OnClickListener
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
		mono.android.Runtime.register ("VideoPlayerDemo.Widget.UserTagView+OnClickListener, VideoPlayerDemo", UserTagView_OnClickListener.class, __md_methods);
	}


	public UserTagView_OnClickListener ()
	{
		super ();
		if (getClass () == UserTagView_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView+OnClickListener, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public UserTagView_OnClickListener (md5674a3a834b96a12ba7ca87cec1b85ae9.UserTagView p0)
	{
		super ();
		if (getClass () == UserTagView_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Widget.UserTagView+OnClickListener, VideoPlayerDemo", "VideoPlayerDemo.Widget.UserTagView, VideoPlayerDemo", this, new java.lang.Object[] { p0 });
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

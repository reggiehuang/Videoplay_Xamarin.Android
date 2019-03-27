package md509804c5e123c8dc75f4f8c7cee088677;


public class AbsRecyclerViewAdapter_Abs_OnClickListener
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
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnClickListener, VideoPlayerDemo", AbsRecyclerViewAdapter_Abs_OnClickListener.class, __md_methods);
	}


	public AbsRecyclerViewAdapter_Abs_OnClickListener ()
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter_Abs_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnClickListener, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public AbsRecyclerViewAdapter_Abs_OnClickListener (md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter p0, md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter_ClickableViewHolder p1, int p2)
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter_Abs_OnClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnClickListener, VideoPlayerDemo", "VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter, VideoPlayerDemo:VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+ClickableViewHolder, VideoPlayerDemo:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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

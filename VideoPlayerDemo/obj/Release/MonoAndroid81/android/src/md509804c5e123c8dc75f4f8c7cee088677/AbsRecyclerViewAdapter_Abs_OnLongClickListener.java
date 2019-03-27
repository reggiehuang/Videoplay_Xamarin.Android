package md509804c5e123c8dc75f4f8c7cee088677;


public class AbsRecyclerViewAdapter_Abs_OnLongClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLongClick:(Landroid/view/View;)Z:GetOnLongClick_Landroid_view_View_Handler:Android.Views.View/IOnLongClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnLongClickListener, VideoPlayerDemo", AbsRecyclerViewAdapter_Abs_OnLongClickListener.class, __md_methods);
	}


	public AbsRecyclerViewAdapter_Abs_OnLongClickListener ()
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter_Abs_OnLongClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnLongClickListener, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public AbsRecyclerViewAdapter_Abs_OnLongClickListener (md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter p0, md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter_ClickableViewHolder p1, int p2)
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter_Abs_OnLongClickListener.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+Abs_OnLongClickListener, VideoPlayerDemo", "VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter, VideoPlayerDemo:VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter+ClickableViewHolder, VideoPlayerDemo:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onLongClick (android.view.View p0)
	{
		return n_onLongClick (p0);
	}

	private native boolean n_onLongClick (android.view.View p0);

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

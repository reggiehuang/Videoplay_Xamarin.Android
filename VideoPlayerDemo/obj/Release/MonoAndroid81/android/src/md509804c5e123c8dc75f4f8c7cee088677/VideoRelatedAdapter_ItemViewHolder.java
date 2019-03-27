package md509804c5e123c8dc75f4f8c7cee088677;


public class VideoRelatedAdapter_ItemViewHolder
	extends md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter_ClickableViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.Adapter.VideoRelatedAdapter+ItemViewHolder, VideoPlayerDemo", VideoRelatedAdapter_ItemViewHolder.class, __md_methods);
	}


	public VideoRelatedAdapter_ItemViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == VideoRelatedAdapter_ItemViewHolder.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.VideoRelatedAdapter+ItemViewHolder, VideoPlayerDemo", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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

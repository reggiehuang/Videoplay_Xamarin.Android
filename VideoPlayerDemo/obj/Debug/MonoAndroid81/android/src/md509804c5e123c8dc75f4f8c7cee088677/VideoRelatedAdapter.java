package md509804c5e123c8dc75f4f8c7cee088677;


public class VideoRelatedAdapter
	extends md509804c5e123c8dc75f4f8c7cee088677.AbsRecyclerViewAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemCount:()I:GetGetItemCountHandler\n" +
			"n_onCreateViewHolder:(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;:GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"n_onBindViewHolder:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.Adapter.VideoRelatedAdapter, VideoPlayerDemo", VideoRelatedAdapter.class, __md_methods);
	}


	public VideoRelatedAdapter ()
	{
		super ();
		if (getClass () == VideoRelatedAdapter.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.VideoRelatedAdapter, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public VideoRelatedAdapter (android.support.v7.widget.RecyclerView p0)
	{
		super ();
		if (getClass () == VideoRelatedAdapter.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.VideoRelatedAdapter, VideoPlayerDemo", "Android.Support.V7.Widget.RecyclerView, Xamarin.Android.Support.v7.RecyclerView", this, new java.lang.Object[] { p0 });
	}


	public int getItemCount ()
	{
		return n_getItemCount ();
	}

	private native int n_getItemCount ();


	public android.support.v7.widget.RecyclerView.ViewHolder onCreateViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateViewHolder (p0, p1);
	}

	private native android.support.v7.widget.RecyclerView.ViewHolder n_onCreateViewHolder (android.view.ViewGroup p0, int p1);


	public void onBindViewHolder (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onBindViewHolder (p0, p1);
	}

	private native void n_onBindViewHolder (android.support.v7.widget.RecyclerView.ViewHolder p0, int p1);

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

package md509804c5e123c8dc75f4f8c7cee088677;


public abstract class AbsRecyclerViewAdapter
	extends android.support.v7.widget.RecyclerView.Adapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onBindViewHolder:(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V:GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter, VideoPlayerDemo", AbsRecyclerViewAdapter.class, __md_methods);
	}


	public AbsRecyclerViewAdapter ()
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public AbsRecyclerViewAdapter (android.support.v7.widget.RecyclerView p0)
	{
		super ();
		if (getClass () == AbsRecyclerViewAdapter.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.Adapter.AbsRecyclerViewAdapter, VideoPlayerDemo", "Android.Support.V7.Widget.RecyclerView, Xamarin.Android.Support.v7.RecyclerView", this, new java.lang.Object[] { p0 });
	}


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

package md5025ad8ae54194ab8d1ac139fb14ea016;


public class VideoDetailsActivity_VideoDetailsPagerAdapter
	extends android.support.v4.app.FragmentStatePagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getItem:(I)Landroid/support/v4/app/Fragment;:GetGetItem_IHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.VideoDetailsActivity+VideoDetailsPagerAdapter, VideoPlayerDemo", VideoDetailsActivity_VideoDetailsPagerAdapter.class, __md_methods);
	}


	public VideoDetailsActivity_VideoDetailsPagerAdapter (android.support.v4.app.FragmentManager p0)
	{
		super (p0);
		if (getClass () == VideoDetailsActivity_VideoDetailsPagerAdapter.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.VideoDetailsActivity+VideoDetailsPagerAdapter, VideoPlayerDemo", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.Fragment", this, new java.lang.Object[] { p0 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.support.v4.app.Fragment getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native android.support.v4.app.Fragment n_getItem (int p0);

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

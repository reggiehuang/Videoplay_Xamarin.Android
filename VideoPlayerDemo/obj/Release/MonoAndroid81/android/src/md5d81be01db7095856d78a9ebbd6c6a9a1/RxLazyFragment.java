package md5d81be01db7095856d78a9ebbd6c6a9a1;


public abstract class RxLazyFragment
	extends md5d81be01db7095856d78a9ebbd6c6a9a1.RxFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onViewCreated:(Landroid/view/View;Landroid/os/Bundle;)V:GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onDestroyView:()V:GetOnDestroyViewHandler\n" +
			"n_onAttach:(Landroid/app/Activity;)V:GetOnAttach_Landroid_app_Activity_Handler\n" +
			"n_onDetach:()V:GetOnDetachHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Base.RxLazyFragment, VideoPlayerDemo", RxLazyFragment.class, __md_methods);
	}


	public RxLazyFragment ()
	{
		super ();
		if (getClass () == RxLazyFragment.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Base.RxLazyFragment, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onViewCreated (android.view.View p0, android.os.Bundle p1)
	{
		n_onViewCreated (p0, p1);
	}

	private native void n_onViewCreated (android.view.View p0, android.os.Bundle p1);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onDestroyView ()
	{
		n_onDestroyView ();
	}

	private native void n_onDestroyView ();


	public void onAttach (android.app.Activity p0)
	{
		n_onAttach (p0);
	}

	private native void n_onAttach (android.app.Activity p0);


	public void onDetach ()
	{
		n_onDetach ();
	}

	private native void n_onDetach ();

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

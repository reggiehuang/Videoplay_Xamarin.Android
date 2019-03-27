package md5025ad8ae54194ab8d1ac139fb14ea016;


public class VideoIntroductionFragment_ReadDataTask
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.VideoIntroductionFragment+ReadDataTask, VideoPlayerDemo", VideoIntroductionFragment_ReadDataTask.class, __md_methods);
	}


	public VideoIntroductionFragment_ReadDataTask ()
	{
		super ();
		if (getClass () == VideoIntroductionFragment_ReadDataTask.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.VideoIntroductionFragment+ReadDataTask, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}

	public VideoIntroductionFragment_ReadDataTask (android.os.Handler p0)
	{
		super ();
		if (getClass () == VideoIntroductionFragment_ReadDataTask.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.VideoIntroductionFragment+ReadDataTask, VideoPlayerDemo", "Android.OS.Handler, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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

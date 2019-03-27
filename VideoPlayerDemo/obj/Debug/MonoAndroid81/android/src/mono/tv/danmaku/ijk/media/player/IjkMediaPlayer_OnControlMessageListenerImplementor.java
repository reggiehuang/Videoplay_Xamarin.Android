package mono.tv.danmaku.ijk.media.player;


public class IjkMediaPlayer_OnControlMessageListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IjkMediaPlayer.OnControlMessageListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onControlResolveSegmentUrl:(I)Ljava/lang/String;:GetOnControlResolveSegmentUrl_IHandler:TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer/IOnControlMessageListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnControlMessageListenerImplementor, ICE.MediaPlay.Droid", IjkMediaPlayer_OnControlMessageListenerImplementor.class, __md_methods);
	}


	public IjkMediaPlayer_OnControlMessageListenerImplementor ()
	{
		super ();
		if (getClass () == IjkMediaPlayer_OnControlMessageListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnControlMessageListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String onControlResolveSegmentUrl (int p0)
	{
		return n_onControlResolveSegmentUrl (p0);
	}

	private native java.lang.String n_onControlResolveSegmentUrl (int p0);

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

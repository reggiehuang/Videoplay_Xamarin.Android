package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnVideoSizeChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnVideoSizeChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onVideoSizeChanged:(Ltv/danmaku/ijk/media/player/IMediaPlayer;IIII)V:GetOnVideoSizeChanged_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIIIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnVideoSizeChangedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnVideoSizeChangedListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnVideoSizeChangedListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnVideoSizeChangedListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnVideoSizeChangedListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnVideoSizeChangedListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onVideoSizeChanged (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2, int p3, int p4)
	{
		n_onVideoSizeChanged (p0, p1, p2, p3, p4);
	}

	private native void n_onVideoSizeChanged (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2, int p3, int p4);

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

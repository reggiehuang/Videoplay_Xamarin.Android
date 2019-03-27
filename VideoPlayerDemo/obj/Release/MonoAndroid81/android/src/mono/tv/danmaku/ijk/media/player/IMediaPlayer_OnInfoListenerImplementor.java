package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnInfoListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnInfoListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInfo:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnInfo_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnInfoListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnInfoListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnInfoListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2)
	{
		return n_onInfo (p0, p1, p2);
	}

	private native boolean n_onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2);

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

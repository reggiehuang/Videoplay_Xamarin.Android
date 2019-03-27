package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnErrorListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnErrorListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnError_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnErrorListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnErrorListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnErrorListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnErrorListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnErrorListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnErrorListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onError (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2)
	{
		return n_onError (p0, p1, p2);
	}

	private native boolean n_onError (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2);

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

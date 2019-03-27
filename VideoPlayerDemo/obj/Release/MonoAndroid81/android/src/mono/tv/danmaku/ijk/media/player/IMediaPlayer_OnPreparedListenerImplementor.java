package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnPreparedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnPreparedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPrepared:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnPrepared_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnPreparedListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnPreparedListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnPreparedListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onPrepared (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onPrepared (p0);
	}

	private native void n_onPrepared (tv.danmaku.ijk.media.player.IMediaPlayer p0);

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

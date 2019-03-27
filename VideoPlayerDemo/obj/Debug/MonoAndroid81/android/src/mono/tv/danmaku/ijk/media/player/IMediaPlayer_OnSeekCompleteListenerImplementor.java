package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnSeekCompleteListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnSeekCompleteListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSeekComplete:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnSeekComplete_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnSeekCompleteListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnSeekCompleteListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnSeekCompleteListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onSeekComplete (p0);
	}

	private native void n_onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0);

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

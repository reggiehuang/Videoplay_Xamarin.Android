package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnCompletionListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnCompletionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCompletion:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnCompletion_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnCompletionListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnCompletionListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnCompletionListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCompletion (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onCompletion (p0);
	}

	private native void n_onCompletion (tv.danmaku.ijk.media.player.IMediaPlayer p0);

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

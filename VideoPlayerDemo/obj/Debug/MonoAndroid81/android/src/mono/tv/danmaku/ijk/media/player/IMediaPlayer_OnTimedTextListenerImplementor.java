package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnTimedTextListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnTimedTextListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTimedText:(Ltv/danmaku/ijk/media/player/IMediaPlayer;Ltv/danmaku/ijk/media/player/IjkTimedText;)V:GetOnTimedText_Ltv_danmaku_ijk_media_player_IMediaPlayer_Ltv_danmaku_ijk_media_player_IjkTimedText_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnTimedTextListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnTimedTextListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnTimedTextListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnTimedTextListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnTimedTextListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnTimedTextListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onTimedText (tv.danmaku.ijk.media.player.IMediaPlayer p0, tv.danmaku.ijk.media.player.IjkTimedText p1)
	{
		n_onTimedText (p0, p1);
	}

	private native void n_onTimedText (tv.danmaku.ijk.media.player.IMediaPlayer p0, tv.danmaku.ijk.media.player.IjkTimedText p1);

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

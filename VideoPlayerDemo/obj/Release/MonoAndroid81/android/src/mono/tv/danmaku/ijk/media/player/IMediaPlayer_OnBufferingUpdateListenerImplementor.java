package mono.tv.danmaku.ijk.media.player;


public class IMediaPlayer_OnBufferingUpdateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnBufferingUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onBufferingUpdate:(Ltv/danmaku/ijk/media/player/IMediaPlayer;I)V:GetOnBufferingUpdate_Ltv_danmaku_ijk_media_player_IMediaPlayer_IHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnBufferingUpdateListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnBufferingUpdateListenerImplementor, ICE.MediaPlay.Droid", IMediaPlayer_OnBufferingUpdateListenerImplementor.class, __md_methods);
	}


	public IMediaPlayer_OnBufferingUpdateListenerImplementor ()
	{
		super ();
		if (getClass () == IMediaPlayer_OnBufferingUpdateListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnBufferingUpdateListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onBufferingUpdate (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1)
	{
		n_onBufferingUpdate (p0, p1);
	}

	private native void n_onBufferingUpdate (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1);

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

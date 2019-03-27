package mono.tv.danmaku.ijk.media.player;


public class IjkMediaPlayer_OnMediaCodecSelectListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IjkMediaPlayer.OnMediaCodecSelectListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMediaCodecSelect:(Ltv/danmaku/ijk/media/player/IMediaPlayer;Ljava/lang/String;II)Ljava/lang/String;:GetOnMediaCodecSelect_Ltv_danmaku_ijk_media_player_IMediaPlayer_Ljava_lang_String_IIHandler:TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer/IOnMediaCodecSelectListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnMediaCodecSelectListenerImplementor, ICE.MediaPlay.Droid", IjkMediaPlayer_OnMediaCodecSelectListenerImplementor.class, __md_methods);
	}


	public IjkMediaPlayer_OnMediaCodecSelectListenerImplementor ()
	{
		super ();
		if (getClass () == IjkMediaPlayer_OnMediaCodecSelectListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnMediaCodecSelectListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String onMediaCodecSelect (tv.danmaku.ijk.media.player.IMediaPlayer p0, java.lang.String p1, int p2, int p3)
	{
		return n_onMediaCodecSelect (p0, p1, p2, p3);
	}

	private native java.lang.String n_onMediaCodecSelect (tv.danmaku.ijk.media.player.IMediaPlayer p0, java.lang.String p1, int p2, int p3);

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

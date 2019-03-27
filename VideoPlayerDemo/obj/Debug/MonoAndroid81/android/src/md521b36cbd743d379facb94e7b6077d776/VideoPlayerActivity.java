package md521b36cbd743d379facb94e7b6077d776;


public class VideoPlayerActivity
	extends md5d81be01db7095856d78a9ebbd6c6a9a1.RxBaseActivity
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnInfoListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnSeekCompleteListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnCompletionListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnPreparedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"n_onInfo:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnInfo_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onSeekComplete:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnSeekComplete_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onCompletion:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnCompletion_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onPrepared:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnPrepared_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Activities.VideoPlayerActivity, VideoPlayerDemo", VideoPlayerActivity.class, __md_methods);
	}


	public VideoPlayerActivity ()
	{
		super ();
		if (getClass () == VideoPlayerActivity.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Activities.VideoPlayerActivity, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();


	public boolean onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2)
	{
		return n_onInfo (p0, p1, p2);
	}

	private native boolean n_onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2);


	public void onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onSeekComplete (p0);
	}

	private native void n_onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0);


	public void onCompletion (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onCompletion (p0);
	}

	private native void n_onCompletion (tv.danmaku.ijk.media.player.IMediaPlayer p0);


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

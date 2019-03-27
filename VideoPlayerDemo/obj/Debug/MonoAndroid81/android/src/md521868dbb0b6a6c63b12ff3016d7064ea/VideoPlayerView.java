package md521868dbb0b6a6c63b12ff3016d7064ea;


public class VideoPlayerView
	extends android.view.SurfaceView
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnCompletionListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnPreparedListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnErrorListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnSeekCompleteListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnInfoListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnBufferingUpdateListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnVideoSizeChangedListener,
		android.view.SurfaceHolder.Callback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTrackballEvent:(Landroid/view/MotionEvent;)Z:GetOnTrackballEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"n_onCompletion:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnCompletion_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onPrepared:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnPrepared_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onError:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnError_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnErrorListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onSeekComplete:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnSeekComplete_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onInfo:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnInfo_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onBufferingUpdate:(Ltv/danmaku/ijk/media/player/IMediaPlayer;I)V:GetOnBufferingUpdate_Ltv_danmaku_ijk_media_player_IMediaPlayer_IHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnBufferingUpdateListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onVideoSizeChanged:(Ltv/danmaku/ijk/media/player/IMediaPlayer;IIII)V:GetOnVideoSizeChanged_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIIIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnVideoSizeChangedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_surfaceChanged:(Landroid/view/SurfaceHolder;III)V:GetSurfaceChanged_Landroid_view_SurfaceHolder_IIIHandler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceCreated:(Landroid/view/SurfaceHolder;)V:GetSurfaceCreated_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceDestroyed:(Landroid/view/SurfaceHolder;)V:GetSurfaceDestroyed_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Media.VideoPlayerView, VideoPlayerDemo", VideoPlayerView.class, __md_methods);
	}


	public VideoPlayerView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == VideoPlayerView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.VideoPlayerView, VideoPlayerDemo", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public VideoPlayerView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == VideoPlayerView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.VideoPlayerView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public VideoPlayerView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == VideoPlayerView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.VideoPlayerView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public VideoPlayerView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == VideoPlayerView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.VideoPlayerView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public boolean onTrackballEvent (android.view.MotionEvent p0)
	{
		return n_onTrackballEvent (p0);
	}

	private native boolean n_onTrackballEvent (android.view.MotionEvent p0);


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);


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


	public boolean onError (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2)
	{
		return n_onError (p0, p1, p2);
	}

	private native boolean n_onError (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2);


	public void onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0)
	{
		n_onSeekComplete (p0);
	}

	private native void n_onSeekComplete (tv.danmaku.ijk.media.player.IMediaPlayer p0);


	public boolean onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2)
	{
		return n_onInfo (p0, p1, p2);
	}

	private native boolean n_onInfo (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2);


	public void onBufferingUpdate (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1)
	{
		n_onBufferingUpdate (p0, p1);
	}

	private native void n_onBufferingUpdate (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1);


	public void onVideoSizeChanged (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2, int p3, int p4)
	{
		n_onVideoSizeChanged (p0, p1, p2, p3, p4);
	}

	private native void n_onVideoSizeChanged (tv.danmaku.ijk.media.player.IMediaPlayer p0, int p1, int p2, int p3, int p4);


	public void surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3)
	{
		n_surfaceChanged (p0, p1, p2, p3);
	}

	private native void n_surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3);


	public void surfaceCreated (android.view.SurfaceHolder p0)
	{
		n_surfaceCreated (p0);
	}

	private native void n_surfaceCreated (android.view.SurfaceHolder p0);


	public void surfaceDestroyed (android.view.SurfaceHolder p0)
	{
		n_surfaceDestroyed (p0);
	}

	private native void n_surfaceDestroyed (android.view.SurfaceHolder p0);

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

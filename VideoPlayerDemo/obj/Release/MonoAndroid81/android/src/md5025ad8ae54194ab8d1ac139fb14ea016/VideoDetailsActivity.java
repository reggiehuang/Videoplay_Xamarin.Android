package md5025ad8ae54194ab8d1ac139fb14ea016;


public class VideoDetailsActivity
	extends md5d81be01db7095856d78a9ebbd6c6a9a1.RxBaseActivity
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.AppBarLayout.OnOffsetChangedListener,
		android.support.v4.view.ViewPager.OnPageChangeListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnInfoListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnSeekCompleteListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnCompletionListener,
		tv.danmaku.ijk.media.player.IMediaPlayer.OnPreparedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"n_onOffsetChanged:(Landroid/support/design/widget/AppBarLayout;I)V:GetOnOffsetChanged_Landroid_support_design_widget_AppBarLayout_IHandler:Android.Support.Design.Widget.AppBarLayout/IOnOffsetChangedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"n_onPageScrollStateChanged:(I)V:GetOnPageScrollStateChanged_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"n_onPageScrolled:(IFI)V:GetOnPageScrolled_IFIHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"n_onPageSelected:(I)V:GetOnPageSelected_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"n_onInfo:(Ltv/danmaku/ijk/media/player/IMediaPlayer;II)Z:GetOnInfo_Ltv_danmaku_ijk_media_player_IMediaPlayer_IIHandler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnInfoListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onSeekComplete:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnSeekComplete_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnSeekCompleteListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onCompletion:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnCompletion_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnCompletionListenerInvoker, ICE.MediaPlay.Droid\n" +
			"n_onPrepared:(Ltv/danmaku/ijk/media/player/IMediaPlayer;)V:GetOnPrepared_Ltv_danmaku_ijk_media_player_IMediaPlayer_Handler:TV.Danmaku.Ijk.Media.Player.IMediaPlayerOnPreparedListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Acticity.VideoDetailsActivity, VideoPlayerDemo", VideoDetailsActivity.class, __md_methods);
	}


	public VideoDetailsActivity ()
	{
		super ();
		if (getClass () == VideoDetailsActivity.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Acticity.VideoDetailsActivity, VideoPlayerDemo", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();


	public void onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1)
	{
		n_onOffsetChanged (p0, p1);
	}

	private native void n_onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1);


	public void onPageScrollStateChanged (int p0)
	{
		n_onPageScrollStateChanged (p0);
	}

	private native void n_onPageScrollStateChanged (int p0);


	public void onPageScrolled (int p0, float p1, int p2)
	{
		n_onPageScrolled (p0, p1, p2);
	}

	private native void n_onPageScrolled (int p0, float p1, int p2);


	public void onPageSelected (int p0)
	{
		n_onPageSelected (p0);
	}

	private native void n_onPageSelected (int p0);


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

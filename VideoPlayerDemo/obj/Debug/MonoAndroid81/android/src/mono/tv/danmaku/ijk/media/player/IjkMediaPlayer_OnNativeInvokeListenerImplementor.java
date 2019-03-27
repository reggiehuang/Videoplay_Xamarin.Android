package mono.tv.danmaku.ijk.media.player;


public class IjkMediaPlayer_OnNativeInvokeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.danmaku.ijk.media.player.IjkMediaPlayer.OnNativeInvokeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNativeInvoke:(ILandroid/os/Bundle;)Z:GetOnNativeInvoke_ILandroid_os_Bundle_Handler:TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer/IOnNativeInvokeListenerInvoker, ICE.MediaPlay.Droid\n" +
			"";
		mono.android.Runtime.register ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnNativeInvokeListenerImplementor, ICE.MediaPlay.Droid", IjkMediaPlayer_OnNativeInvokeListenerImplementor.class, __md_methods);
	}


	public IjkMediaPlayer_OnNativeInvokeListenerImplementor ()
	{
		super ();
		if (getClass () == IjkMediaPlayer_OnNativeInvokeListenerImplementor.class)
			mono.android.TypeManager.Activate ("TV.Danmaku.Ijk.Media.Player.IjkMediaPlayer+IOnNativeInvokeListenerImplementor, ICE.MediaPlay.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onNativeInvoke (int p0, android.os.Bundle p1)
	{
		return n_onNativeInvoke (p0, p1);
	}

	private native boolean n_onNativeInvoke (int p0, android.os.Bundle p1);

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

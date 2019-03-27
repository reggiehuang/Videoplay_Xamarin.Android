package md521868dbb0b6a6c63b12ff3016d7064ea;


public class OutlineTextView
	extends android.widget.TextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setTextColor:(I)V:GetSetTextColor_IHandler\n" +
			"n_setShadowLayer:(FFFI)V:GetSetShadowLayer_FFFIHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"";
		mono.android.Runtime.register ("VideoPlayerDemo.Media.OutlineTextView, VideoPlayerDemo", OutlineTextView.class, __md_methods);
	}


	public OutlineTextView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == OutlineTextView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.OutlineTextView, VideoPlayerDemo", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public OutlineTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == OutlineTextView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.OutlineTextView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public OutlineTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == OutlineTextView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.OutlineTextView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public OutlineTextView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == OutlineTextView.class)
			mono.android.TypeManager.Activate ("VideoPlayerDemo.Media.OutlineTextView, VideoPlayerDemo", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void setTextColor (int p0)
	{
		n_setTextColor (p0);
	}

	private native void n_setTextColor (int p0);


	public void setShadowLayer (float p0, float p1, float p2, int p3)
	{
		n_setShadowLayer (p0, p1, p2, p3);
	}

	private native void n_setShadowLayer (float p0, float p1, float p2, int p3);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);

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

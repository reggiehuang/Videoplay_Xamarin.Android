using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using Java.Lang;

namespace VideoPlayerDemo.Widget
{
    public class CircleImageView : ImageView
    {
        private static ScaleType SCALE_TYPE = ScaleType.CenterCrop;
        private static Bitmap.Config BITMAP_CONFIG = Bitmap.Config.Argb8888;
        private static int COLORDRAWABLE_DIMENSION = 2;
        private static int DEFAULT_BORDER_WIDTH = 0;
        private static Color DEFAULT_BORDER_COLOR = Color.Black;
        private static bool DEFAULT_BORDER_OVERLAY = false;
        private RectF mDrawableRect = new RectF();
        private RectF mBorderRect = new RectF();
        private Matrix mShaderMatrix = new Matrix();
        private Paint mBitmapPaint = new Paint();
        private Paint mBorderPaint = new Paint();
        private Color mBorderColor = DEFAULT_BORDER_COLOR;
        private int mBorderWidth = DEFAULT_BORDER_WIDTH;
        private Bitmap mBitmap;
        private BitmapShader mBitmapShader;
        private int mBitmapWidth;
        private int mBitmapHeight;
        private float mDrawableRadius;
        private float mBorderRadius;
        private ColorFilter mColorFilter;
        private bool mReady;
        private bool mSetupPending;
        private bool mBorderOverlay;
        private Context mContext;
        public CircleImageView(Context context)
            : base(context)
        {
            mContext = context;
            Init();
        }

        public CircleImageView(Context context, IAttributeSet attrs)
            : base(context, attrs, 0)
        {
            mContext = context;
            GetAttributes(context, attrs);
        }

        public CircleImageView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            mContext = context;
            TypedArray a = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircleImageView, defStyle, 0);
            mBorderWidth = a.GetDimensionPixelSize(Resource.Styleable.CircleImageView_border_width, DEFAULT_BORDER_WIDTH);
            mBorderColor = a.GetColor(Resource.Styleable.CircleImageView_border_color, DEFAULT_BORDER_COLOR);
            mBorderOverlay = a.GetBoolean(Resource.Styleable.CircleImageView_border_overlay, DEFAULT_BORDER_OVERLAY);
            a.Recycle();
            Init();
        }

        /// <summary>
        /// 获取自定义属性
        /// </summary>
        /// <param name="context"></param>
        /// <param name="attrs"></param>
        private void GetAttributes(Context context, IAttributeSet attrs)
        {
            TypedArray a = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircleImageView);
            mBorderWidth = a.GetDimensionPixelSize(Resource.Styleable.CircleImageView_border_width, DEFAULT_BORDER_WIDTH);
            mBorderColor = a.GetColor(Resource.Styleable.CircleImageView_border_color, DEFAULT_BORDER_COLOR);
            mBorderOverlay = a.GetBoolean(Resource.Styleable.CircleImageView_border_overlay, DEFAULT_BORDER_OVERLAY);
            a.Recycle();
        }

        private void Init()
        {
            base.SetScaleType(SCALE_TYPE);
            mReady = true;
            if (mSetupPending)
            {
                Setup();
                mSetupPending = false;
            }
        }

        public override ScaleType GetScaleType()
        {
            return SCALE_TYPE;
        }

        public override void SetScaleType(ScaleType scaleType)
        {
            if (scaleType != SCALE_TYPE)
            {
                throw new IllegalArgumentException(string.Format("ScaleType %s not supported.", scaleType));
            }
        }

        public override void SetAdjustViewBounds(bool adjustViewBounds)
        {
            if (adjustViewBounds)
            {
                throw new IllegalArgumentException("adjustViewBounds not supported.");
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            Drawable localDrawable = Drawable;
            if (localDrawable == null) return;
            if (localDrawable is NinePatchDrawable) return;


            int width = Width;
            int height = Height;
            canvas.DrawCircle(width / 2, height / 2, mDrawableRadius, mBitmapPaint);

            if (mBorderWidth != 0)
            {
                canvas.DrawCircle(width / 2, height / 2, mBorderRadius, mBorderPaint);
            }
        }


        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            Setup();
        }

        public int getBorderColor()
        {
            return mBorderColor;
        }

        public void SetBorderColor(Color borderColor)
        {
            if (borderColor == mBorderColor)
            {
                return;
            }
            mBorderColor = borderColor;
            mBorderPaint.Color = mBorderColor;// SetColor(mBorderColor);
            Invalidate();
        }

        public void setBorderColorResource(int borderColorRes)
        {
            Color resColor = new Color(borderColorRes);
            SetBorderColor(resColor);// getContext().getResources().getColor(borderColorRes));
        }

        public int GetBorderWidth()
        {
            return mBorderWidth;
        }

        public void SetBorderWidth(int borderWidth)
        {
            if (borderWidth == mBorderWidth)
            {
                return;
            }
            mBorderWidth = borderWidth;
            Setup();
        }

        public bool IsBorderOverlay()
        {
            return mBorderOverlay;
        }

        public void SetBorderOverlay(bool borderOverlay)
        {
            if (borderOverlay == mBorderOverlay)
            {
                return;
            }
            mBorderOverlay = borderOverlay;
            Setup();
        }

        public override void SetImageBitmap(Bitmap bm)
        {
            base.SetImageBitmap(bm);
            mBitmap = bm;
            Setup();
        }

        public override void SetImageDrawable(Drawable drawable)
        {
            base.SetImageDrawable(drawable);
            mBitmap = GetBitmapFromDrawable(drawable);
            Setup();
        }

        public override void SetImageResource(int resId)
        {
            base.SetImageResource(resId);
            Drawable localDrawable = Drawable;
            mBitmap = GetBitmapFromDrawable(localDrawable);
            Setup();
        }

        public override void SetImageURI(Android.Net.Uri uri)
        {
            base.SetImageURI(uri);
            Drawable localDrawable = Drawable;
            mBitmap = GetBitmapFromDrawable(localDrawable);
            //mBitmap = getBitmapFromDrawable(GetDrawable());
            Setup();
        }

        public override void SetColorFilter(ColorFilter cf)
        {
            if (cf == mColorFilter)
            {
                return;
            }
            mColorFilter = cf;
            mBitmapPaint.SetColorFilter(mColorFilter);
            Invalidate();
        }

        private Bitmap GetBitmapFromDrawable(Drawable drawable)
        {
            if (drawable == null)
            {
                return null;
            }
            if (drawable is BitmapDrawable)
            {
                return ((BitmapDrawable)drawable).Bitmap;// GetBitmap();
            }
            try
            {
                Bitmap bitmap;
                if (drawable is ColorDrawable)
                {
                    bitmap = Bitmap.CreateBitmap(COLORDRAWABLE_DIMENSION, COLORDRAWABLE_DIMENSION,
                            BITMAP_CONFIG);
                }
                else
                {
                    bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, BITMAP_CONFIG);
                }
                Canvas canvas = new Canvas(bitmap);
                drawable.SetBounds(0, 0, canvas.Width, canvas.Height);//.getWidth(), canvas.getHeight());
                drawable.Draw(canvas);
                return bitmap;
            }
            catch (OutOfMemoryError e)
            {
                return null;
            }
        }


        private void Setup()
        {
            if (!mReady)
            {
                mSetupPending = true;
                return;
            }
            if (mBitmap == null)
            {
                return;
            }
            mBitmapShader = new BitmapShader(mBitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
            mBitmapPaint.AntiAlias = true;// SetAntiAlias(true);
            mBitmapPaint.SetShader(mBitmapShader);
            mBorderPaint.SetStyle(Paint.Style.Stroke);
            mBorderPaint.AntiAlias = true;//.SetAntiAlias(true);
            mBorderPaint.Color = mBorderColor;//.SetColor(mBorderColor);
            mBorderPaint.StrokeWidth = mBorderWidth;//  .SetStrokeWidth(mBorderWidth);
            mBitmapHeight = mBitmap.Height;// .getHeight();
            mBitmapWidth = mBitmap.Width;//.getWidth();
            mBorderRect.Set(0, 0, Width, Height);//  getWidth(), getHeight());
            mBorderRadius = Java.Lang.Math.Min((mBorderRect.Height() - mBorderWidth) / 2,
                    (mBorderRect.Width() - mBorderWidth) / 2);
            mDrawableRect.Set(mBorderRect);
            if (!mBorderOverlay)
            {
                mDrawableRect.Inset(mBorderWidth, mBorderWidth);
            }
            mDrawableRadius = System.Math.Min(mDrawableRect.Height() / 2, mDrawableRect.Width() / 2);
            UpdateShaderMatrix();
            Invalidate();
        }


        private void UpdateShaderMatrix()
        {
            float scale;
            float dx = 0;
            float dy = 0;
            mShaderMatrix.Set(null);
            if (mBitmapWidth * mDrawableRect.Height() > mDrawableRect.Width() * mBitmapHeight)
            {
                scale = mDrawableRect.Height() / (float)mBitmapHeight;
                dx = (mDrawableRect.Width() - mBitmapWidth * scale) * 0.5f;
            }
            else
            {
                scale = mDrawableRect.Width() / (float)mBitmapWidth;
                dy = (mDrawableRect.Height() - mBitmapHeight * scale) * 0.5f;
            }
            mShaderMatrix.SetScale(scale, scale);
            mShaderMatrix.PostTranslate((int)(dx + 0.5f) + mDrawableRect.Left, (int)(dy + 0.5f) + mDrawableRect.Top);
            mBitmapShader.SetLocalMatrix(mShaderMatrix);
        }
    }
}
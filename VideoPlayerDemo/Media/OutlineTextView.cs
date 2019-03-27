using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using static Android.Resource;
using Color = Android.Graphics.Color;

namespace VideoPlayerDemo.Media
{
    public class OutlineTextView: TextView
    {
        private TextPaint mTextPaint;
        private TextPaint mTextPaintOutline;
        private string mText = "";
        private float mBorderSize;
        private Android.Graphics.Color mBorderColor;
        private Android.Graphics.Color mColor;
        private float mSpacingMult = 1.0f;
        private float mSpacingAdd = 0;
        private bool mIncludePad = true;

        public OutlineTextView(Context context)
            :base(context)
        {
            InitPaint();
        }

        public OutlineTextView(Context context, IAttributeSet attrs)
            :base(context, attrs)
        {
            InitPaint();
        }

        public OutlineTextView(Context context, IAttributeSet attrs, int defStyle)
            :base(context, attrs, defStyle)
        {
            InitPaint();
        }

        private void InitPaint()
        {
            mTextPaint = new TextPaint();
            mTextPaint.AntiAlias = true;// (true);
            mTextPaint.TextSize = TextSize;// (getTextSize());
            mTextPaint.Color = mColor;//  SetColor(mColor);
            mTextPaint.SetStyle(Android.Graphics.Paint.Style.Fill);
            mTextPaint.SetTypeface(Typeface);

            mTextPaintOutline = new TextPaint();
            mTextPaintOutline.AntiAlias = true;// (true);
            mTextPaintOutline.TextSize = TextSize;
            mTextPaintOutline.Color = mBorderColor;
            mTextPaintOutline.SetStyle(Android.Graphics.Paint.Style.Stroke);
            mTextPaintOutline.SetTypeface(Typeface);
            mTextPaintOutline.StrokeWidth = mBorderSize;// SetStrokeWidth(mBorderSize);
        }


        public void SetText(string text)
        {
            base.SetText(text, BufferType.Normal);
            mText = text;
            RequestLayout();
            Invalidate();
        }

        public void SetTextSize(float size)
        {
            base.SetTextSize(ComplexUnitType.Px, size);
            RequestLayout();
            Invalidate();
            InitPaint();
        }

        public override void SetTextColor(Color color)
        {
            base.SetTextColor(color);
            mColor = color;
            Invalidate();
            InitPaint();
        }

        public override void SetShadowLayer(float radius, float dx, float dy, Color color)
        {
            base.SetShadowLayer(radius, dx, dy, color);
            mBorderSize = radius;
            mBorderColor = color;
            RequestLayout();
            Invalidate();
            InitPaint();
        }

        public void SetTypeface(Typeface tf, int style)
        {
            base.SetTypeface(tf, (TypefaceStyle)style);
            RequestLayout();
            Invalidate();
            InitPaint();
        }


        public void SetTypeface(Typeface tf)
        {
            base.SetTypeface(tf, TypefaceStyle.Normal);
            RequestLayout();
            Invalidate();
            InitPaint();
        }

        
    protected override void OnDraw(Canvas canvas)
        {
            Android.Text.Layout layout = new StaticLayout(Text, mTextPaintOutline, 
                Width, Android.Text.Layout.Alignment.AlignCenter, mSpacingMult,
                    mSpacingAdd, mIncludePad);
            layout.Draw(canvas);

            layout = new StaticLayout(Text, mTextPaint, Width, Android.Text.Layout.Alignment.AlignCenter, mSpacingMult,
                    mSpacingAdd, mIncludePad);
            layout.Draw(canvas);
        }

        
 protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            Android.Text.Layout layout = new StaticLayout(Text, mTextPaintOutline,
                    measureWidth(widthMeasureSpec), Android.Text.Layout.Alignment.AlignCenter,
                    mSpacingMult, mSpacingAdd, mIncludePad);
            int ex = (int)(mBorderSize * 2 + 1);
            SetMeasuredDimension(measureWidth(widthMeasureSpec) + ex,
                    measureHeight(heightMeasureSpec) * layout.LineCount + ex);
        }


        private int measureWidth(int measureSpec)
        {
            int result;
            int specMode = Convert.ToInt32(MeasureSpec.GetMode(measureSpec));
            int specSize = MeasureSpec.GetSize(measureSpec);
            if (specMode == (int)MeasureSpecMode.Exactly)
            {
                result = specSize;
            }
            else
            {
                result = (int)mTextPaintOutline.MeasureText(mText)
                        + PaddingLeft + PaddingRight;
                if (specMode == (int)MeasureSpecMode.AtMost)
                {
                    result = Math.Min(result, specSize);
                }
            }
            return result;
        }


        private int measureHeight(int measureSpec)
        {
            int result = 0;
            int specMode = Convert.ToInt32(MeasureSpec.GetMode(measureSpec));
            int specSize = MeasureSpec.GetSize(measureSpec);
            int mAscent = (int)mTextPaintOutline.Ascent();
            if (specMode == (int) MeasureSpecMode.Exactly)
            {
                result = specSize;
            }
            else
            {
                result = (int)(-mAscent + mTextPaintOutline.Descent())
                        + PaddingTop + PaddingBottom;
                if (specMode == (int)MeasureSpecMode.Exactly)
                {
                    result = Math.Min(result, specSize);
                }
            }
            return result;
        }
    }
}
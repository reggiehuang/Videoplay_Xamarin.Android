using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using static Android.Graphics.Paint;

namespace VideoPlayerDemo.Widget
{
    public class CircleProgressView : View
    {
        private static string TAG = "CircleProgressView";
        private int circleRadius = 28;
        private int barWidth = 4;
        private int rimWidth = 4;
        private int barLength = 16;
        private int barMaxLength = 270;
        private bool fillRadius = false;
        private double timeStartGrowing = 0;
        private double barSpinCycleTime = 460;
        private float barExtraLength = 0;
        private bool barGrowingFromFront = true;
        private long pausedTimeWithoutGrowing = 0;
        private long pauseGrowingTime = 200;
        private int barColor = Resource.Color.video_barColor;
        private int rimColor = Resource.Color.video_rimColor;
        private Paint barPaint = new Paint();
        private Paint rimPaint = new Paint();
        private RectF circleBounds = new RectF();
        private float spinSpeed = 230.0f;
        private long lastTimeAnimated = 0;
        private bool linearProgress;
        private float mProgress = 0.0f;
        private float mTargetProgress = 0.0f;
        private bool isSpinning = false;
        private WheelSavedState.ProgressCallback callback;

        /**
         * The constructor for the ProgressWheel
         */
        public CircleProgressView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            ParseAttributes(context.ObtainStyledAttributes(attrs, Resource.Styleable.CircleProgressView));
        }

        /**
         * The constructor for the ProgressWheel
         */
        public CircleProgressView(Context context)
            : base(context)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            int viewWidth = circleRadius + this.PaddingLeft + this.PaddingRight;
            int viewHeight = circleRadius + this.PaddingTop + this.PaddingBottom;
            int widthMode = (int)MeasureSpec.GetMode(widthMeasureSpec);
            int widthSize = MeasureSpec.GetSize(widthMeasureSpec);
            int heightMode = (int)MeasureSpec.GetMode(heightMeasureSpec);
            int heightSize = MeasureSpec.GetSize(heightMeasureSpec);
            int width;
            int height;
            if (widthMode == (int)MeasureSpecMode.Exactly)
            {
                width = widthSize;
            }
            else if (widthMode == (int)MeasureSpecMode.AtMost)
            {
                width = Math.Min(viewWidth, widthSize);
            }
            else
            {
                width = viewWidth;
            }
            if (heightMode == (int)MeasureSpecMode.Exactly || widthMode == (int)MeasureSpecMode.Exactly)
            {
                height = heightSize;
            }
            else if (heightMode == (int)MeasureSpecMode.AtMost)
            {
                height = Math.Min(viewHeight, heightSize);
            }
            else
            {
                height = viewHeight;
            }
            SetMeasuredDimension(width, height);
        }


        /**
         * Use onSizeChanged instead of onAttachedToWindow to get the dimensions of
         * the view, because this method is called after measuring the dimensions of
         * MATCH_PARENT & WRAP_CONTENT. Use this dimensions to setup the bounds and
         * paints.
         */
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            SetupBounds(w, h);
            SetupPaints();
            Invalidate();
        }


        /**
         * Set the properties of the paints we're using to draw the progress wheel
         */
        private void SetupPaints()
        {

            Color barPaint_color = new Color(Resource.Color.video_barColor);
            barPaint.Color = barPaint_color;// Resources.GetColor(Resource.Color.video_barColor);// "#0xAA000000";// barColor;  SetColor(barColor);
            barPaint.AntiAlias = true;// SetAntiAlias(true);
            barPaint.SetStyle(Style.Stroke);
            barPaint.StrokeWidth = barWidth;// SetStrokeWidth(barWidth);
            Color rimPaint_color = new Color(Resource.Color.video_rimColor);
            rimPaint.Color = rimPaint_color;// Resources.GetColor(rimPaint_color); //SetColor(rimColor);
            rimPaint.AntiAlias = true;//SetAntiAlias(true);
            rimPaint.SetStyle(Style.Stroke);
            rimPaint.StrokeWidth = rimWidth;//.SetStrokeWidth(rimWidth);
        }


        /**
         * Set the bounds of the component
         */
        private void SetupBounds(int layout_width, int layout_height)
        {
            int paddingTop = PaddingTop;
            int paddingBottom = PaddingBottom;
            int paddingLeft = PaddingLeft;
            int paddingRight = PaddingRight;
            if (!fillRadius)
            {
                int minValue = Math.Min(layout_width - paddingLeft - paddingRight,
                        layout_height - paddingBottom - paddingTop);
                int circleDiameter = Math.Min(minValue, circleRadius * 2 - barWidth * 2);
                int xOffset = (layout_width - paddingLeft - paddingRight - circleDiameter) / 2 + paddingLeft;
                int yOffset = (layout_height - paddingTop - paddingBottom - circleDiameter) / 2 + paddingTop;
                circleBounds = new RectF(xOffset + barWidth, yOffset + barWidth,
                        xOffset + circleDiameter - barWidth, yOffset + circleDiameter - barWidth);
            }
            else
            {
                circleBounds = new RectF(paddingLeft + barWidth, paddingTop + barWidth,
                        layout_width - paddingRight - barWidth, layout_height - paddingBottom - barWidth);
            }
        }


        /**
         * Parse the attributes passed to the view from the XML
         *
         * @param a the attributes to parse
         */
        private void ParseAttributes(TypedArray a)
        {
            DisplayMetrics metrics = Context.Resources.DisplayMetrics;// GetContext().getResources().getDisplayMetrics();
            barWidth = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, barWidth, metrics);
            rimWidth = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, rimWidth, metrics);
            circleRadius = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, circleRadius,
                    metrics);
            circleRadius = (int)a.GetDimension(Resource.Styleable.CircleProgressView_matProg_circleRadius,
                    circleRadius);
            fillRadius = a.GetBoolean(Resource.Styleable.CircleProgressView_matProg_fillRadius, false);
            barWidth = (int)a.GetDimension(Resource.Styleable.CircleProgressView_matProg_barWidth, barWidth);
            rimWidth = (int)a.GetDimension(Resource.Styleable.CircleProgressView_matProg_rimWidth, rimWidth);
            float baseSpinSpeed = a.GetFloat(Resource.Styleable.CircleProgressView_matProg_spinSpeed, spinSpeed / 360.0f);
            spinSpeed = baseSpinSpeed * 360;
            barSpinCycleTime = a.GetInt(Resource.Styleable.CircleProgressView_matProg_barSpinCycleTime,
                    (int)barSpinCycleTime);
            barColor = a.GetColor(Resource.Styleable.CircleProgressView_matProg_barColor, barColor);
            rimColor = a.GetColor(Resource.Styleable.CircleProgressView_matProg_rimColor, rimColor);
            linearProgress = a.GetBoolean(Resource.Styleable.CircleProgressView_matProg_linearProgress, false);
            if (a.GetBoolean(Resource.Styleable.CircleProgressView_matProg_progressIndeterminate, false))
            {
                Spin();
            }
            a.Recycle();
        }


        public void SetCallback(WheelSavedState.ProgressCallback progressCallback)
        {
            callback = progressCallback;
            if (!IsSpinning())
            {
                RunCallback();
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawArc(circleBounds, 360, 360, false, rimPaint);
            bool mustInvalidate = false;
            if (IsSpinning())
            {
                mustInvalidate = true;
                long deltaTime = (SystemClock.UptimeMillis() - lastTimeAnimated);
                float deltaNormalized = deltaTime * spinSpeed / 1000.0f;
                UpdateBarLength(deltaTime);
                mProgress += deltaNormalized;
                if (mProgress > 360)
                {
                    mProgress -= 360f;
                    RunCallback(-1.0f);
                }
                lastTimeAnimated = SystemClock.UptimeMillis();
                float from = mProgress - 90;
                float length = barLength + barExtraLength;
                if (IsInEditMode)
                {
                    from = 0;
                    length = 135;
                }
                canvas.DrawArc(circleBounds, from, length, false, barPaint);
            }
            else
            {
                float oldProgress = mProgress;
                if (mProgress != mTargetProgress)
                {
                    mustInvalidate = true;
                    float deltaTime = (float)(SystemClock.UptimeMillis() - lastTimeAnimated) / 1000;
                    float deltaNormalized = deltaTime * spinSpeed;
                    mProgress = Math.Min(mProgress + deltaNormalized, mTargetProgress);
                    lastTimeAnimated = SystemClock.UptimeMillis();
                }
                if (oldProgress != mProgress)
                {
                    RunCallback();
                }
                float offset = 0.0f;
                float progress = mProgress;
                if (!linearProgress)
                {
                    float factor = 2.0f;
                    offset = (float)(1.0f - Math.Pow(1.0f - mProgress / 360.0f, 2.0f * factor)) * 360.0f;
                    progress = (float)(1.0f - Math.Pow(1.0f - mProgress / 360.0f, factor)) * 360.0f;
                }
                if (IsInEditMode)
                {
                    progress = 360;
                }
                canvas.DrawArc(circleBounds, offset - 90, progress, false, barPaint);
            }
            if (mustInvalidate)
            {
                Invalidate();
            }
        }

        protected void OnVisibilityChanged(View changedView, int visibility)
        {
            base.OnVisibilityChanged(changedView, (ViewStates)visibility);
            if (visibility == (int)ViewStates.Visible)
            {
                lastTimeAnimated = SystemClock.UptimeMillis();
            }
        }

        private void UpdateBarLength(long deltaTimeInMilliSeconds)
        {
            if (pausedTimeWithoutGrowing >= pauseGrowingTime)
            {
                timeStartGrowing += deltaTimeInMilliSeconds;
                if (timeStartGrowing > barSpinCycleTime)
                {
                    timeStartGrowing -= barSpinCycleTime;
                    pausedTimeWithoutGrowing = 0;
                    barGrowingFromFront = !barGrowingFromFront;
                }
                float distance = (float)Math.Cos((timeStartGrowing / barSpinCycleTime + 1) * Math.PI) / 2 + 0.5f;
                float destLength = (barMaxLength - barLength);
                if (barGrowingFromFront)
                {
                    barExtraLength = distance * destLength;
                }
                else
                {
                    float newLength = destLength * (1 - distance);
                    mProgress += (barExtraLength - newLength);
                    barExtraLength = newLength;
                }
            }
            else
            {
                pausedTimeWithoutGrowing += deltaTimeInMilliSeconds;
            }
        }

        /**
         * Check if the wheel is currently spinning
         */

        public bool IsSpinning()
        {
            return isSpinning;
        }

        /**
         * Reset the count (in increment mode)
         */
        public void ResetCount()
        {
            mProgress = 0.0f;
            mTargetProgress = 0.0f;
            Invalidate();
        }

        /**
         * Turn off spin mode
         */
        public void StopSpinning()
        {
            isSpinning = false;
            mProgress = 0.0f;
            mTargetProgress = 0.0f;
            Invalidate();
        }

        /**
         * Puts the view on spin mode
         */
        public void Spin()
        {
            lastTimeAnimated = SystemClock.UptimeMillis();
            isSpinning = true;
            Invalidate();
        }

        private void RunCallback(float value)
        {
            if (callback != null)
            {
                callback.OnProgressUpdate(value);
            }
        }

        private void RunCallback()
        {
            if (callback != null)
            {
                float normalizedProgress = (float)Math.Round(mProgress * 100 / 360.0f) / 100;
                callback.OnProgressUpdate(normalizedProgress);
            }
        }


        /**
         * Set the progress to a specific value, the bar will smoothly animate until
         * that value
         *
         * @param progress the progress between 0 and 1
         */
        public void SetProgress(float progress)
        {
            if (isSpinning)
            {
                mProgress = 0.0f;
                isSpinning = false;
                RunCallback();
            }
            if (progress > 1.0f)
            {
                progress -= 1.0f;
            }
            else if (progress < 0)
            {
                progress = 0;
            }
            if (progress == mTargetProgress)
            {
                return;
            }
            if (mProgress == mTargetProgress)
            {
                lastTimeAnimated = SystemClock.UptimeMillis();
            }
            mTargetProgress = Math.Min(progress * 360.0f, 360.0f);
            Invalidate();
        }


        /**
         * Set the progress to a specific value, the bar will be set instantly to
         * that value
         *
         * @param progress the progress between 0 and 1
         */
        public void SetInstantProgress(float progress)
        {
            if (isSpinning)
            {
                mProgress = 0.0f;
                isSpinning = false;
            }
            if (progress > 1.0f)
            {
                progress -= 1.0f;
            }
            else if (progress < 0)
            {
                progress = 0;
            }
            if (progress == mTargetProgress)
            {
                return;
            }
            mTargetProgress = Math.Min(progress * 360.0f, 360.0f);
            mProgress = mTargetProgress;
            lastTimeAnimated = SystemClock.UptimeMillis();
            Invalidate();
        }

        protected override IParcelable OnSaveInstanceState()
        {
            IParcelable superState = base.OnSaveInstanceState();
            WheelSavedState ss = new WheelSavedState(superState);
            ss.mProgress = this.mProgress;
            ss.mTargetProgress = this.mTargetProgress;
            ss.isSpinning = this.isSpinning;
            ss.spinSpeed = this.spinSpeed;
            ss.barWidth = this.barWidth;
            ss.barColor = this.barColor;
            ss.rimWidth = this.rimWidth;
            ss.rimColor = this.rimColor;
            ss.circleRadius = this.circleRadius;
            ss.linearProgress = this.linearProgress;
            ss.fillRadius = this.fillRadius;
            return ss;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (!(state is WheelSavedState))
            {
                base.OnRestoreInstanceState(state);
                return;
            }
            WheelSavedState ss = (WheelSavedState)state;
            base.OnRestoreInstanceState(ss.SuperState);
            this.mProgress = ss.mProgress;
            this.mTargetProgress = ss.mTargetProgress;
            this.isSpinning = ss.isSpinning;
            this.spinSpeed = ss.spinSpeed;
            this.barWidth = ss.barWidth;
            this.barColor = ss.barColor;
            this.rimWidth = ss.rimWidth;
            this.rimColor = ss.rimColor;
            this.circleRadius = ss.circleRadius;
            this.linearProgress = ss.linearProgress;
            this.fillRadius = ss.fillRadius;
            this.lastTimeAnimated = SystemClock.UptimeMillis();
        }


        /**
         * @return the current progress between 0.0 and 1.0, if the wheel is
         * indeterminate, then the result is -1
         */
        public float GetProgress()
        {
            return isSpinning ? -1 : mProgress / 360.0f;
        }


        /**
         * Sets the determinate progress mode
         *
         * @param isLinear if the progress should increase linearly
         */
        public void SetLinearProgress(bool isLinear)
        {
            linearProgress = isLinear;
            if (!isSpinning)
            {
                Invalidate();
            }
        }


        /**
         * @return the radius of the wheel in pixels
         */
        public int GetCircleRadius()
        {
            return circleRadius;
        }


        /**
         * Sets the radius of the wheel
         *
         * @param circleRadius the expected radius, in pixels
         */
        public void SetCircleRadius(int circleRadius)
        {
            this.circleRadius = circleRadius;
            if (!isSpinning)
            {
                Invalidate();
            }
        }


        /**
         * @return the width of the spinning bar
         */
        public int GetBarWidth()
        {
            return barWidth;
        }


        /**
         * Sets the width of the spinning bar
         *
         * @param barWidth the spinning bar width in pixels
         */
        public void SetBarWidth(int barWidth)
        {
            this.barWidth = barWidth;
            if (!isSpinning)
            {
                Invalidate();
            }
        }

        /**
         * @return the color of the spinning bar
         */
        public int GetBarColor()
        {
            return barColor;
        }


        /**
         * Sets the color of the spinning bar
         *
         * @param barColor The spinning bar color
         */
        public void SetBarColor(int barColor)
        {
            this.barColor = barColor;
            SetupPaints();
            if (!isSpinning)
            {
                Invalidate();
            }
        }


        /**
         * @return the color of the wheel's contour
         */
        public int GetRimColor()
        {
            return rimColor;
        }


        /**
         * Sets the color of the wheel's contour
         *
         * @param rimColor the color for the wheel
         */
        public void SetRimColor(int rimColor)
        {
            this.rimColor = rimColor;
            SetupPaints();
            if (!isSpinning)
            {
                Invalidate();
            }
        }


        /**
         * @return the base spinning speed, in full circle turns per second (1.0
         * equals on full turn in one second), this value also is applied
         * for the smoothness when setting a progress
         */
        public float GetSpinSpeed()
        {
            return spinSpeed / 360.0f;
        }


        /**
         * Sets the base spinning speed, in full circle turns per second (1.0 equals
         * on full turn in one second), this value also is applied for the
         * smoothness when setting a progress
         *
         * @param spinSpeed the desired base speed in full turns per second
         */
        public void SetSpinSpeed(float spinSpeed)
        {
            this.spinSpeed = spinSpeed * 360.0f;
        }


        /**
         * @return the width of the wheel's contour in pixels
         */
        public int GetRimWidth()
        {
            return rimWidth;
        }


        /**
         * Sets the width of the wheel's contour
         *
         * @param rimWidth the width in pixels
         */
        public void SetRimWidth(int rimWidth)
        {
            this.rimWidth = rimWidth;
            if (!isSpinning)
            {
                Invalidate();
            }
        }


        public class WheelSavedState : BaseSavedState
        {
            public float mProgress;
            public float mTargetProgress;
            public bool isSpinning;
            public float spinSpeed;
            public int barWidth;
            public int barColor;
            public int rimWidth;
            public int rimColor;
            public int circleRadius;
            public bool linearProgress;
            public bool fillRadius;

            public WheelSavedState(IParcelable superState)
                 : base(superState)
            {
            }

            public WheelSavedState(Parcel pin)
                    : base(pin)
            {
                this.mProgress = pin.ReadFloat();
                this.mTargetProgress = pin.ReadFloat();
                this.isSpinning = pin.ReadByte() != 0;
                this.spinSpeed = pin.ReadFloat();
                this.barWidth = pin.ReadInt();
                this.barColor = pin.ReadInt();
                this.rimWidth = pin.ReadInt();
                this.rimColor = pin.ReadInt();
                this.circleRadius = pin.ReadInt();
                this.linearProgress = pin.ReadByte() != 0;
                this.fillRadius = pin.ReadByte() != 0;
            }

            public void WriteToParcel(Parcel pout, int flags)
            {
                base.WriteToParcel(pout, (ParcelableWriteFlags)flags);

                pout.WriteFloat(this.mProgress);
                pout.WriteFloat(this.mTargetProgress);
                pout.WriteByte((sbyte)(isSpinning ? 1 : 0));
                pout.WriteFloat(this.spinSpeed);
                pout.WriteInt(this.barWidth);
                pout.WriteInt(this.barColor);
                pout.WriteInt(this.rimWidth);
                pout.WriteInt(this.rimColor);
                pout.WriteInt(this.circleRadius);
                pout.WriteByte((sbyte)(linearProgress ? 1 : 0));
                pout.WriteByte((sbyte)(fillRadius ? 1 : 0));
            }

            public interface ProgressCallback
            {
                /**
                 * Method to call when the progress reaches a value in order to avoid
                 * float precision issues, the progress is rounded to a float with two
                 * decimals.
                 * <p/>
                 * In indeterminate mode, the callback is called each time the wheel
                 * completes an animation cycle, with, the progress value is -1.0f
                 *
                 * @param progress a double value between 0.00 and 1.00 both included
                 */
                void OnProgressUpdate(float progress);
            }

            #region 实现IParcelableCreator接口
            private static readonly WheelSavedStateCreator _creator = new WheelSavedStateCreator();
            [ExportField("CREATOR")]
            //必须使用CREATOR这个固定的名称       
            public static WheelSavedStateCreator GetCreator()
            {
                return _creator;
            }

            public class WheelSavedStateCreator : Java.Lang.Object, IParcelableCreator
            {
                public Java.Lang.Object CreateFromParcel(Parcel source)
                {
                    return new WheelSavedState(source);
                }

                public Java.Lang.Object[] NewArray(int size)
                {
                    return new WheelSavedState[size];
                }
            }
            #endregion

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Flyco.Tablayout.Listener;
using Com.Flyco.Tablayout.Utils;
using Com.Flyco.Tablayout.Widget;
using Java.Lang;
using Java.Util;

namespace VideoPlayerDemo.Widget
{
    public class SlidingTabLayoutPlus : HorizontalScrollView, ViewPager.IOnPageChangeListener
    {
        private Context mContext;
        private ViewPager mViewPager;
        private List<string> mTitles;
        private LinearLayout mTabsContainer;
        private int mCurrentTab;
        private IOnTabSelectListener mListener;

        private float mCurrentPositionOffset;
        private int mTabCount;
        /** 用于绘制显示器 */
        private Rect mIndicatorRect = new Rect();
        /** 用于实现滚动居中 */
        private Rect mTabRect = new Rect();
        private GradientDrawable mIndicatorDrawable = new GradientDrawable();

        private Paint mRectPaint = new Paint(PaintFlags.AntiAlias);
        private Paint mDividerPaint = new Paint(PaintFlags.AntiAlias);
        private Paint mTrianglePaint = new Paint(PaintFlags.AntiAlias);
        private Path mTrianglePath = new Path();
        private static int STYLE_NORMAL = 0;
        private static int STYLE_TRIANGLE = 1;
        private static int STYLE_BLOCK = 2;
        private int mIndicatorStyle = STYLE_NORMAL;

        private float mTabPadding;
        private bool mTabSpaceEqual;
        private float mTabWidth;

        /** indicator */
        private Color mIndicatorColor;
        private float mIndicatorHeight;
        private float mIndicatorWidth;
        private float mIndicatorCornerRadius;
        private float mIndicatorMarginLeft;
        private float mIndicatorMarginTop;
        private float mIndicatorMarginRight;
        private float mIndicatorMarginBottom;
        private int mIndicatorGravity;
        private bool mIndicatorWidthEqualTitle;

        /** underline */
        private Color mUnderlineColor;
        private float mUnderlineHeight;
        private int mUnderlineGravity;

        /** divider */
        private Color mDividerColor;
        private float mDividerWidth;
        private float mDividerPadding;

        /** title */
        private static int TEXT_BOLD_NONE = 0;
        private static int TEXT_BOLD_WHEN_SELECT = 1;
        private static int TEXT_BOLD_BOTH = 2;
        private float mTextsize;
        private Color mTextSelectColor;
        private Color mTextUnselectColor;
        private int mTextBold;
        private bool mTextAllCaps;

        private int mLastScrollX;
        private int mHeight;
        private bool mSnapOnTabClick;


        public SlidingTabLayoutPlus(Context context)
                : base(context, null, 0)
        {
            this.mContext = context;
        }

        public SlidingTabLayoutPlus(Context context, IAttributeSet attrs)
                 : base(context, attrs, 0)
        {
            this.mContext = context;
            SetFitsSystemWindows(true);
            SetWillNotDraw(false);//重写onDraw方法,需要调用这个方法来清除flag
            SetClipChildren(false);
            SetClipToPadding(false);

            this.mContext = context;
            mTabsContainer = new LinearLayout(context);
            AddView(mTabsContainer);

            obtainAttributes(context, attrs);
            
            var height = attrs.GetAttributeValue("http://schemas.android.com/apk/res/android", "layout_height");// model.GetValue("layout_height");//  .GetAttributeValue("http://schemas.android.com/apk/res/android", "layout_height");

            if (height.Equals(ViewGroup.LayoutParams.MatchParent + ""))
            {
            }
            else if (height.Equals(ViewGroup.LayoutParams.WrapContent + ""))
            {
            }
            else
            {
                int[] systemAttrs = { Android.Resource.Attribute.LayoutHeight };
                TypedArray a = context.ObtainStyledAttributes(attrs, systemAttrs);
                mHeight = a.GetDimensionPixelSize(0, ViewGroup.LayoutParams.WrapContent);
                a.Recycle();
            }
        }

        public SlidingTabLayoutPlus(Context context, IAttributeSet attrs, int defStyleAttr)
                : base(context, attrs, defStyleAttr)
        {
            //SetFillViewport(true);//设置滚动视图是否可以伸缩其内容以填充视口
            SetFitsSystemWindows(true);
            SetWillNotDraw(false);//重写onDraw方法,需要调用这个方法来清除flag
            SetClipChildren(false);
            SetClipToPadding(false);

            this.mContext = context;
            mTabsContainer = new LinearLayout(context);
            AddView(mTabsContainer);

            obtainAttributes(context, attrs);
            //Attributes model = new Attributes();
            //model = (Attributes)attrs;
            //get layout_height
            var height = attrs.GetAttributeValue("http://schemas.android.com/apk/res/android", "layout_height");// model.GetValue("layout_height");//  .GetAttributeValue("http://schemas.android.com/apk/res/android", "layout_height");

            if (height.Equals(ViewGroup.LayoutParams.MatchParent + ""))
            {
            }
            else if (height.Equals(ViewGroup.LayoutParams.WrapContent + ""))
            {
            }
            else
            {
                int[] systemAttrs = { Android.Resource.Attribute.LayoutHeight };
                TypedArray a = context.ObtainStyledAttributes(attrs, systemAttrs);
                mHeight = a.GetDimensionPixelSize(0, ViewGroup.LayoutParams.WrapContent);
                a.Recycle();
            }
        }

        private void obtainAttributes(Context context, IAttributeSet attrs)
        {
            TypedArray ta = context.ObtainStyledAttributes(attrs, Resource.Styleable.SlidingTabLayout);

            mIndicatorStyle = ta.GetInt(Resource.Styleable.SlidingTabLayout_tl_indicator_style, STYLE_NORMAL);
            mIndicatorColor = ta.GetColor(Resource.Styleable.SlidingTabLayout_tl_indicator_color, Color.ParseColor(mIndicatorStyle == STYLE_BLOCK ? "#4B6A87" : "#ffffff"));
            mIndicatorHeight = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_height,
                    dp2px(mIndicatorStyle == STYLE_TRIANGLE ? 4 : (mIndicatorStyle == STYLE_BLOCK ? -1 : 2)));
            mIndicatorWidth = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_width, dp2px(mIndicatorStyle == STYLE_TRIANGLE ? 10 : -1));
            mIndicatorCornerRadius = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_corner_radius, dp2px(mIndicatorStyle == STYLE_BLOCK ? -1 : 0));
            mIndicatorMarginLeft = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_margin_left, dp2px(0));
            mIndicatorMarginTop = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_margin_top, dp2px(mIndicatorStyle == STYLE_BLOCK ? 7 : 0));
            mIndicatorMarginRight = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_margin_right, dp2px(0));
            mIndicatorMarginBottom = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_indicator_margin_bottom, dp2px(mIndicatorStyle == STYLE_BLOCK ? 7 : 0));
            mIndicatorGravity = ta.GetInt(Resource.Styleable.SlidingTabLayout_tl_indicator_gravity, (int)GravityFlags.Bottom);
            mIndicatorWidthEqualTitle = ta.GetBoolean(Resource.Styleable.SlidingTabLayout_tl_indicator_width_equal_title, false);

            mUnderlineColor = ta.GetColor(Resource.Styleable.SlidingTabLayout_tl_underline_color, Color.ParseColor("#ffffff"));
            mUnderlineHeight = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_underline_height, dp2px(0));
            mUnderlineGravity = ta.GetInt(Resource.Styleable.SlidingTabLayout_tl_underline_gravity, (int)GravityFlags.Bottom);

            mDividerColor = ta.GetColor(Resource.Styleable.SlidingTabLayout_tl_divider_color, Color.ParseColor("#ffffff"));
            mDividerWidth = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_divider_width, dp2px(0));
            mDividerPadding = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_divider_padding, dp2px(12));

            mTextsize = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_textsize, sp2px(14));
            mTextSelectColor = ta.GetColor(Resource.Styleable.SlidingTabLayout_tl_textSelectColor, Color.ParseColor("#ffffff"));
            mTextUnselectColor = ta.GetColor(Resource.Styleable.SlidingTabLayout_tl_textUnselectColor, Color.ParseColor("#AAffffff"));
            mTextBold = ta.GetInt(Resource.Styleable.SlidingTabLayout_tl_textBold, TEXT_BOLD_NONE);
            mTextAllCaps = ta.GetBoolean(Resource.Styleable.SlidingTabLayout_tl_textAllCaps, false);

            mTabSpaceEqual = ta.GetBoolean(Resource.Styleable.SlidingTabLayout_tl_tab_space_equal, false);
            mTabWidth = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_tab_width, dp2px(-1));
            mTabPadding = ta.GetDimension(Resource.Styleable.SlidingTabLayout_tl_tab_padding, mTabSpaceEqual || mTabWidth > 0 ? dp2px(0) : dp2px(20));

            ta.Recycle();
        }

        /** 关联ViewPager */
        public void SetViewPager(ViewPager vp)
        {
            if (vp == null || vp.Adapter == null)
            {
                throw new IllegalStateException("ViewPager or ViewPager adapter can not be NULL !");
            }

            this.mViewPager = vp;

            this.mViewPager.RemoveOnPageChangeListener(this);
            this.mViewPager.AddOnPageChangeListener(this);
            notifyDataSetChanged();
        }

        /** 关联ViewPager,用于不想在ViewPager适配器中设置titles数据的情况 */
        public void SetViewPager(ViewPager vp, List<string> titles)
        {
            if (vp == null || vp.Adapter == null) 
            {
                throw new IllegalStateException("ViewPager or ViewPager adapter can not be NULL !");
            }

            if (titles == null || titles.Count == 0)
            {
                throw new IllegalStateException("Titles can not be EMPTY !");
            }

            if (titles.Count != vp.Adapter.Count)
            {
                throw new IllegalStateException("Titles length must be the same as the page count !");
            }

            this.mViewPager = vp;
            mTitles = new List<string>();
            mTitles = titles;
            
            //Collections.AddAll(mTitles, titles);

            this.mViewPager.RemoveOnPageChangeListener(this);
            this.mViewPager.AddOnPageChangeListener(this);
            notifyDataSetChanged();
        }

        /** 关联ViewPager,用于连适配器都不想自己实例化的情况 */
        public void setViewPager(ViewPager vp, Java.Lang.String[] titles, FragmentActivity fa, List<Android.Support.V4.App.Fragment> fragments)
        {
            if (vp == null)
            {
                throw new IllegalStateException("ViewPager can not be NULL !");
            }

            if (titles == null || titles.Length == 0)
            {
                throw new IllegalStateException("Titles can not be EMPTY !");
            }

            this.mViewPager = vp;
            this.mViewPager.Adapter = new InnerPagerAdapter(fa.SupportFragmentManager, fragments, titles);//.SetAdapter(new InnerPagerAdapter(fa.SupportFragmentManager, fragments, titles));

            this.mViewPager.RemoveOnPageChangeListener(this);
            this.mViewPager.AddOnPageChangeListener(this);
            notifyDataSetChanged();
        }

        /** 更新数据 */
        public void notifyDataSetChanged()
        {
            if (mTabsContainer != null)
            {
                mTabsContainer.RemoveAllViews();
            }
            
            this.mTabCount = mTitles == null ? mViewPager.Adapter.Count : mTitles.Count;
            View tabView;
            for (int i = 0; i < mTabCount; i++)
            {
                tabView = View.Inflate(mContext, Resource.Layout.layout_tab, null);
                string pageTitle = mTitles == null ? mViewPager.Adapter.GetPageTitle(i) : mTitles[i];
                addTab(i, pageTitle.ToString(), tabView);
            }

            updateTabStyles();
        }

        public void addNewTab(string title)
        {
            View tabView = View.Inflate(mContext, Resource.Layout.layout_tab, null);
            if (mTitles != null)
            {
                mTitles.Add(title);
            }

            string pageTitle = mTitles == null ? mViewPager.Adapter.GetPageTitle(mTabCount) : mTitles[mTabCount];
            addTab(mTabCount, pageTitle.ToString(), tabView);

            this.mTabCount = mTitles == null ? mViewPager.Adapter.Count : mTitles.Count;

            updateTabStyles();
        }

        /** 创建并添加tab */
        private void addTab(int position, string title, View tabView)
        {
            TextView tv_tab_title = (TextView)tabView.FindViewById(Resource.Id.tv_tab_title);
            if (tv_tab_title != null)
            {
                if (title != null) tv_tab_title.SetText(title, TextView.BufferType.Normal);
            }

            #region TODO
            IOnClickListener onClickListener = new V_OnClickListener(mViewPager, mTabsContainer, mListener, mSnapOnTabClick);
            tabView.SetOnClickListener(onClickListener);
            #endregion 
            /** 每一个Tab的布局参数 */
            LinearLayout.LayoutParams lp_tab = mTabSpaceEqual ?
                    new LinearLayout.LayoutParams(0, LayoutParams.MatchParent, 1.0f) :
                    new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent);
            if (mTabWidth > 0)
            {
                lp_tab = new LinearLayout.LayoutParams((int)mTabWidth, LayoutParams.MatchParent);
            }

            mTabsContainer.AddView(tabView, position, lp_tab);
        }

        public class V_OnClickListener : Java.Lang.Object, IOnClickListener
        {

            private ViewPager v_mViewPager;
            private LinearLayout v_mTabsContainer;
            private IOnTabSelectListener v_mListener;
            private bool v_mSnapOnTabClick;
            public V_OnClickListener(ViewPager mViewPager, LinearLayout mTabsContainer, IOnTabSelectListener mListener, bool mSnapOnTabClick)
            {
                v_mViewPager = mViewPager;
                v_mTabsContainer = mTabsContainer;
                v_mListener = mListener;
                v_mSnapOnTabClick = mSnapOnTabClick;
            }
            public void OnClick(View v)
            {
                int position = v_mTabsContainer.IndexOfChild(v);
                if (position != -1)
                {
                    if (v_mViewPager.CurrentItem != position)
                    {
                        if (v_mSnapOnTabClick)
                        {
                            v_mViewPager.SetCurrentItem(position, false);
                        }
                        else
                        {
                            v_mViewPager.CurrentItem = position;// (position);
                        }

                        if (v_mListener != null)
                        {
                            v_mListener.OnTabSelect(position);
                        }
                    }
                    else
                    {
                        if (v_mListener != null)
                        {
                            v_mListener.OnTabReselect(position);
                        }
                    }
                }
            }
        }

        private void updateTabStyles()
        {
            for (int i = 0; i < mTabCount; i++)
            {
                View v = mTabsContainer.GetChildAt(i);
                //            v.setPadding((int) mTabPadding, v.getPaddingTop(), (int) mTabPadding, v.getPaddingBottom());
                TextView tv_tab_title = (TextView)v.FindViewById(Resource.Id.tv_tab_title);
                if (tv_tab_title != null)
                {
                    tv_tab_title.SetTextColor(i == mCurrentTab ? mTextSelectColor : mTextUnselectColor);

                    tv_tab_title.SetTextSize(ComplexUnitType.Px, mTextsize);
                    tv_tab_title.SetPadding((int)mTabPadding, 0, (int)mTabPadding, 0);
                    if (mTextAllCaps)
                    {
                        tv_tab_title.SetText(tv_tab_title.Text.ToString().ToUpper(), TextView.BufferType.Normal);
                    }

                    if (mTextBold == TEXT_BOLD_BOTH)
                    {
                        tv_tab_title.Paint.FakeBoldText = true;//.GetPaint().setFakeBoldText(true);
                    }
                    else if (mTextBold == TEXT_BOLD_NONE)
                    {
                        tv_tab_title.Paint.FakeBoldText = false;//.getPaint().setFakeBoldText(false);
                    }
                }
            }
        }

        #region  IOnPageChangeListener

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            /**
             * position:当前View的位置
             * mCurrentPositionOffset:当前View的偏移量比例.[0,1)
             */
            this.mCurrentTab = position;
            this.mCurrentPositionOffset = positionOffset;
            scrollToCurrentTab();
            Invalidate();
        }

        public void OnPageSelected(int position)
        {
            updateTabSelection(position);
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        #endregion
        /** HorizontalScrollView滚到当前tab,并且居中显示 */
        private void scrollToCurrentTab()
        {
            if (mTabCount <= 0)
            {
                return;
            }

            int offset = (int)(mCurrentPositionOffset * mTabsContainer.GetChildAt(mCurrentTab).Width);
            /**当前Tab的left+当前Tab的Width乘以positionOffset*/
            int newScrollX = mTabsContainer.GetChildAt(mCurrentTab).Left + offset;

            if (mCurrentTab > 0 || offset > 0)
            {
                /**HorizontalScrollView移动到当前tab,并居中*/
                newScrollX -= Width / 2 - PaddingLeft;//   getWidth() / 2 - getPaddingLeft();
                calcIndicatorRect();
                newScrollX += ((mTabRect.Right - mTabRect.Left) / 2);
            }

            if (newScrollX != mLastScrollX)
            {
                mLastScrollX = newScrollX;
                /** scrollTo（int x,int y）:x,y代表的不是坐标点,而是偏移量
                 *  x:表示离起始位置的x水平方向的偏移量
                 *  y:表示离起始位置的y垂直方向的偏移量
                 */
                ScrollTo(newScrollX, 0);
            }
        }

        private void updateTabSelection(int position)
        {
            for (int i = 0; i < mTabCount; ++i)
            {
                View tabView = mTabsContainer.GetChildAt(i);
                bool isSelect = i == position;
                TextView tab_title = (TextView)tabView.FindViewById(Resource.Id.tv_tab_title);

                if (tab_title != null)
                {
                    tab_title.SetTextColor(isSelect ? mTextSelectColor : mTextUnselectColor);

                    if (mTextBold == TEXT_BOLD_WHEN_SELECT)
                    {
                        tab_title.Paint.FakeBoldText = isSelect;//.getPaint().setFakeBoldText(isSelect);
                    }
                }
            }
        }

        private float margin;

        private void calcIndicatorRect()
        {
            View currentTabView = mTabsContainer.GetChildAt(this.mCurrentTab);
            float left = currentTabView.Left;//.getLeft();
            float right = currentTabView.Right;//.getRight();

            //for mIndicatorWidthEqualTitle
            if (mIndicatorStyle == STYLE_NORMAL && mIndicatorWidthEqualTitle)
            {
                TextView tab_title = (TextView)currentTabView.FindViewById(Resource.Id.tv_tab_title);
                mTextPaint.TextSize = mTextsize;//.SetTextSize(mTextsize);
                float textWidth = mTextPaint.MeasureText(tab_title.Text.ToString());
                margin = (right - left - textWidth) / 2;
            }

            if (this.mCurrentTab < mTabCount - 1)
            {
                View nextTabView = mTabsContainer.GetChildAt(this.mCurrentTab + 1);
                float nextTabLeft = nextTabView.Left;//.getLeft();
                float nextTabRight = nextTabView.Right;//.getRight();

                left = left + mCurrentPositionOffset * (nextTabLeft - left);
                right = right + mCurrentPositionOffset * (nextTabRight - right);

                //for mIndicatorWidthEqualTitle
                if (mIndicatorStyle == STYLE_NORMAL && mIndicatorWidthEqualTitle)
                {
                    TextView next_tab_title = (TextView)nextTabView.FindViewById(Resource.Id.tv_tab_title);
                    mTextPaint.TextSize = mTextsize;// SetTextSize(mTextsize);
                    float nextTextWidth = mTextPaint.MeasureText(next_tab_title.Text.ToString());
                    float nextMargin = (nextTabRight - nextTabLeft - nextTextWidth) / 2;
                    margin = margin + mCurrentPositionOffset * (nextMargin - margin);
                }
            }

            mIndicatorRect.Left = (int)left;
            mIndicatorRect.Right = (int)right;
            //for mIndicatorWidthEqualTitle
            if (mIndicatorStyle == STYLE_NORMAL && mIndicatorWidthEqualTitle)
            {
                mIndicatorRect.Left = (int)(left + margin - 1);
                mIndicatorRect.Right = (int)(right - margin - 1);
            }

            mTabRect.Left = (int)left;
            mTabRect.Right = (int)right;

            if (mIndicatorWidth < 0)
            {   //indicatorWidth小于0时,原jpardogo's PagerSlidingTabStrip

            }
            else
            {//indicatorWidth大于0时,圆角矩形以及三角形
                float indicatorLeft = currentTabView.Left + (currentTabView.Width - mIndicatorWidth) / 2;

                if (this.mCurrentTab < mTabCount - 1)
                {
                    View nextTab = mTabsContainer.GetChildAt(this.mCurrentTab + 1);
                    indicatorLeft = indicatorLeft + mCurrentPositionOffset * (currentTabView.Width / 2 + nextTab.Width / 2);
                }

                mIndicatorRect.Left = (int)indicatorLeft;
                mIndicatorRect.Right = (int)(mIndicatorRect.Left + mIndicatorWidth);
            }
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            if (IsInEditMode || mTabCount <= 0)
            {
                return;
            }

            int height = Height;//  getHeight();
            int paddingLeft = PaddingLeft;// getPaddingLeft();
            // draw divider
            if (mDividerWidth > 0)
            {
                mDividerPaint.StrokeWidth = mDividerWidth;// .SetStrokeWidth(mDividerWidth);
                mDividerPaint.Color = mDividerColor;//  .SetColor(mDividerColor);
                for (int i = 0; i < mTabCount - 1; i++)
                {
                    View tab = mTabsContainer.GetChildAt(i);
                    canvas.DrawLine(paddingLeft + tab.Right, mDividerPadding, paddingLeft + tab.Right, height - mDividerPadding, mDividerPaint);//.drawLine(paddingLeft + tab.getRight(), mDividerPadding, paddingLeft + tab.getRight(), height - mDividerPadding, mDividerPaint);
                }
            }

            // draw underline
            if (mUnderlineHeight > 0)
            {
                mRectPaint.Color = mUnderlineColor;//.setColor(mUnderlineColor);
                if (mUnderlineGravity == (int)GravityFlags.Bottom)
                {
                    canvas.DrawRect(paddingLeft, height - mUnderlineHeight, mTabsContainer.Width + paddingLeft, height, mRectPaint);
                }
                else
                {
                    canvas.DrawRect(paddingLeft, 0, mTabsContainer.Width + paddingLeft, mUnderlineHeight, mRectPaint);
                }
            }

            //draw indicator line

            calcIndicatorRect();
            if (mIndicatorStyle == STYLE_TRIANGLE)
            {
                if (mIndicatorHeight > 0)
                {
                    mTrianglePaint.Color = mIndicatorColor;// SetColor(mIndicatorColor);
                    mTrianglePath.Reset();
                    mTrianglePath.MoveTo(paddingLeft + mIndicatorRect.Left, height);
                    mTrianglePath.LineTo(paddingLeft + mIndicatorRect.Left / 2 + mIndicatorRect.Right / 2, height - mIndicatorHeight);
                    mTrianglePath.LineTo(paddingLeft + mIndicatorRect.Right, height);
                    mTrianglePath.Close();
                    canvas.DrawPath(mTrianglePath, mTrianglePaint);
                }
            }
            else if (mIndicatorStyle == STYLE_BLOCK)
            {
                if (mIndicatorHeight < 0)
                {
                    mIndicatorHeight = height - mIndicatorMarginTop - mIndicatorMarginBottom;
                }
                else
                {

                }

                if (mIndicatorHeight > 0)
                {
                    if (mIndicatorCornerRadius < 0 || mIndicatorCornerRadius > mIndicatorHeight / 2)
                    {
                        mIndicatorCornerRadius = mIndicatorHeight / 2;
                    }

                    mIndicatorDrawable.SetColor(mIndicatorColor);//= .setColor(mIndicatorColor);
                    mIndicatorDrawable.SetBounds(paddingLeft + (int)mIndicatorMarginLeft + mIndicatorRect.Left,
                            (int)mIndicatorMarginTop, (int)(paddingLeft + mIndicatorRect.Right - mIndicatorMarginRight),
                            (int)(mIndicatorMarginTop + mIndicatorHeight));
                    mIndicatorDrawable.SetCornerRadius(mIndicatorCornerRadius);
                    mIndicatorDrawable.Draw(canvas);
                }
            }
            else
            {
                /* mRectPaint.setColor(mIndicatorColor);
                 calcIndicatorRect();
                 canvas.drawRect(getPaddingLeft() + mIndicatorRect.left, getHeight() - mIndicatorHeight,
                         mIndicatorRect.right + getPaddingLeft(), getHeight(), mRectPaint);*/

                if (mIndicatorHeight > 0)
                {
                    mIndicatorDrawable.SetColor(mIndicatorColor);

                    if (mIndicatorGravity == (int)GravityFlags.Bottom)
                    {
                        mIndicatorDrawable.SetBounds(paddingLeft + (int)mIndicatorMarginLeft + mIndicatorRect.Left,
                                height - (int)mIndicatorHeight - (int)mIndicatorMarginBottom,
                                paddingLeft + mIndicatorRect.Right - (int)mIndicatorMarginRight,
                                height - (int)mIndicatorMarginBottom);
                    }
                    else
                    {
                        mIndicatorDrawable.SetBounds(paddingLeft + (int)mIndicatorMarginLeft + mIndicatorRect.Left,
                                (int)mIndicatorMarginTop,
                                paddingLeft + mIndicatorRect.Right - (int)mIndicatorMarginRight,
                                (int)mIndicatorHeight + (int)mIndicatorMarginTop);
                    }
                    mIndicatorDrawable.SetCornerRadius(mIndicatorCornerRadius);
                    mIndicatorDrawable.Draw(canvas);
                }
            }
        }

        //setter and getter
        public void SetCurrentTab(int currentTab)
        {
            this.mCurrentTab = currentTab;
            mViewPager.CurrentItem = currentTab;//  SetCurrentItem(currentTab);

        }

        public void SetCurrentTab(int currentTab, bool smoothScroll)
        {
            this.mCurrentTab = currentTab;
            mViewPager.SetCurrentItem(currentTab, smoothScroll);//  .setCurrentItem(currentTab, smoothScroll);
        }

        public void SetIndicatorStyle(int indicatorStyle)
        {
            this.mIndicatorStyle = indicatorStyle;

            Invalidate();
        }

        public void SetTabPadding(float tabPadding)
        {
            this.mTabPadding = dp2px(tabPadding);
            updateTabStyles();
        }

        public void SetTabSpaceEqual(bool tabSpaceEqual)
        {
            this.mTabSpaceEqual = tabSpaceEqual;
            updateTabStyles();
        }

        public void SetTabWidth(float tabWidth)
        {
            this.mTabWidth = dp2px(tabWidth);
            updateTabStyles();
        }

        public void SetIndicatorColor(Color indicatorColor)
        {
            this.mIndicatorColor = indicatorColor;
            Invalidate();
        }

        public void SetIndicatorHeight(float indicatorHeight)
        {
            this.mIndicatorHeight = dp2px(indicatorHeight);
            Invalidate();
        }

        public void SetIndicatorWidth(float indicatorWidth)
        {
            this.mIndicatorWidth = dp2px(indicatorWidth);
            Invalidate();
        }

        public void SetIndicatorCornerRadius(float indicatorCornerRadius)
        {
            this.mIndicatorCornerRadius = dp2px(indicatorCornerRadius);
            Invalidate();
        }

        public void SetIndicatorGravity(int indicatorGravity)
        {
            this.mIndicatorGravity = indicatorGravity;
            Invalidate();
        }

        public void SetIndicatorMargin(float indicatorMarginLeft, float indicatorMarginTop,
                                       float indicatorMarginRight, float indicatorMarginBottom)
        {
            this.mIndicatorMarginLeft = dp2px(indicatorMarginLeft);
            this.mIndicatorMarginTop = dp2px(indicatorMarginTop);
            this.mIndicatorMarginRight = dp2px(indicatorMarginRight);
            this.mIndicatorMarginBottom = dp2px(indicatorMarginBottom);
            Invalidate();
        }

        public void SetIndicatorWidthEqualTitle(bool indicatorWidthEqualTitle)
        {
            this.mIndicatorWidthEqualTitle = indicatorWidthEqualTitle;
            Invalidate();
        }

        public void SetUnderlineColor(Color underlineColor)
        {
            this.mUnderlineColor = underlineColor;
            Invalidate();
        }

        public void SetUnderlineHeight(float underlineHeight)
        {
            this.mUnderlineHeight = dp2px(underlineHeight);
            Invalidate();
        }

        public void SetUnderlineGravity(int underlineGravity)
        {
            this.mUnderlineGravity = underlineGravity;
            Invalidate();
        }

        public void SetDividerColor(Color dividerColor)
        {
            this.mDividerColor = dividerColor;
            Invalidate();
        }

        public void SetDividerWidth(float dividerWidth)
        {
            this.mDividerWidth = dp2px(dividerWidth);
            Invalidate();
        }

        public void SetDividerPadding(float dividerPadding)
        {
            this.mDividerPadding = dp2px(dividerPadding);
            Invalidate();
        }

        public void SetTextsize(float textsize)
        {
            this.mTextsize = sp2px(textsize);
            updateTabStyles();
        }

        public void SetTextSelectColor(Color textSelectColor)
        {
            this.mTextSelectColor = textSelectColor;
            updateTabStyles();
        }

        public void SetTextUnselectColor(Color textUnselectColor)
        {
            this.mTextUnselectColor = textUnselectColor;
            updateTabStyles();
        }

        public void SetTextBold(int textBold)
        {
            this.mTextBold = textBold;
            updateTabStyles();
        }

        public void SetTextAllCaps(bool textAllCaps)
        {
            this.mTextAllCaps = textAllCaps;
            updateTabStyles();
        }

        public void SetSnapOnTabClick(bool snapOnTabClick)
        {
            mSnapOnTabClick = snapOnTabClick;
        }


        public int GetTabCount()
        {
            return mTabCount;
        }

        public int GetCurrentTab()
        {
            return mCurrentTab;
        }

        public int GetIndicatorStyle()
        {
            return mIndicatorStyle;
        }

        public float GetTabPadding()
        {
            return mTabPadding;
        }

        public bool IsTabSpaceEqual()
        {
            return mTabSpaceEqual;
        }

        public float GetTabWidth()
        {
            return mTabWidth;
        }

        public int GetIndicatorColor()
        {
            return mIndicatorColor;
        }

        public float GetIndicatorHeight()
        {
            return mIndicatorHeight;
        }

        public float GetIndicatorWidth()
        {
            return mIndicatorWidth;
        }

        public float GetIndicatorCornerRadius()
        {
            return mIndicatorCornerRadius;
        }

        public float GetIndicatorMarginLeft()
        {
            return mIndicatorMarginLeft;
        }

        public float GetIndicatorMarginTop()
        {
            return mIndicatorMarginTop;
        }

        public float GetIndicatorMarginRight()
        {
            return mIndicatorMarginRight;
        }

        public float GetIndicatorMarginBottom()
        {
            return mIndicatorMarginBottom;
        }

        public int GetUnderlineColor()
        {
            return mUnderlineColor;
        }

        public float GetUnderlineHeight()
        {
            return mUnderlineHeight;
        }

        public int GetDividerColor()
        {
            return mDividerColor;
        }

        public float GetDividerWidth()
        {
            return mDividerWidth;
        }

        public float GetDividerPadding()
        {
            return mDividerPadding;
        }

        public float GetTextsize()
        {
            return mTextsize;
        }

        public int GetTextSelectColor()
        {
            return mTextSelectColor;
        }

        public int GetTextUnselectColor()
        {
            return mTextUnselectColor;
        }

        public int GetTextBold()
        {
            return mTextBold;
        }

        public bool IsTextAllCaps()
        {
            return mTextAllCaps;
        }

        public TextView GetTitleView(int tab)
        {
            View tabView = mTabsContainer.GetChildAt(tab);
            TextView tv_tab_title = (TextView)tabView.FindViewById(Resource.Id.tv_tab_title);
            return tv_tab_title;
        }

        //setter and getter

        // show MsgTipView
        private Paint mTextPaint = new Paint(PaintFlags.AntiAlias);
        private SparseArray<bool> mInitSetMap = new SparseArray<bool>();

        /**
         * 显示未读消息
         *
         * @param position 显示tab位置
         * @param num      num小于等于0显示红点,num大于0显示数字
         */
        public void ShowMsg(int position, int num)
        {
            if (position >= mTabCount)
            {
                position = mTabCount - 1;
            }

            View tabView = mTabsContainer.GetChildAt(position);
            MsgView tipView = (MsgView)tabView.FindViewById(Resource.Id.rtv_msg_tip);
            if (tipView != null)
            {
                UnreadMsgUtils.Show(tipView, num);

                if (mInitSetMap.Get(position) && mInitSetMap.Get(position))
                {
                    return;
                }

                SetMsgMargin(position, 4, 2);
                mInitSetMap.Put(position, true);
            }
        }

        /**
         * 显示未读红点
         *
         * @param position 显示tab位置
         */
        public void ShowDot(int position)
        {
            if (position >= mTabCount)
            {
                position = mTabCount - 1;
            }
            ShowMsg(position, 0);
        }

        /** 隐藏未读消息 */
        public void HideMsg(int position)
        {
            if (position >= mTabCount)
            {
                position = mTabCount - 1;
            }

            View tabView = mTabsContainer.GetChildAt(position);
            MsgView tipView = (MsgView)tabView.FindViewById(Resource.Id.rtv_msg_tip);//.findViewById(R.id.rtv_msg_tip);
            if (tipView != null)
            {
                tipView.Visibility = ViewStates.Gone;// .SetVisibility(ViewStates.Gone);
            }
        }

        /** 设置未读消息偏移,原点为文字的右上角.当控件高度固定,消息提示位置易控制,显示效果佳 */
        public void SetMsgMargin(int position, float leftPadding, float bottomPadding)
        {
            if (position >= mTabCount)
            {
                position = mTabCount - 1;
            }
            View tabView = mTabsContainer.GetChildAt(position);
            MsgView tipView = (MsgView)tabView.FindViewById(Resource.Id.rtv_msg_tip);
            if (tipView != null)
            {
                TextView tv_tab_title = (TextView)tabView.FindViewById(Resource.Id.tv_tab_title);
                mTextPaint.TextSize = mTextsize;// SetTextSize(mTextsize);
                float textWidth = mTextPaint.MeasureText(tv_tab_title.Text.ToString());
                float textHeight = mTextPaint.Descent() - mTextPaint.Ascent();
                MarginLayoutParams lp = (MarginLayoutParams)tipView.LayoutParameters;//.getLayoutParams();
                lp.LeftMargin = mTabWidth >= 0 ? (int)(mTabWidth / 2 + textWidth / 2 + dp2px(leftPadding)) : (int)(mTabPadding + textWidth + dp2px(leftPadding));
                lp.TopMargin = mHeight > 0 ? (int)(mHeight - textHeight) / 2 - dp2px(bottomPadding) : 0;
                tipView.LayoutParameters = lp;//.setLayoutParams(lp);
            }
        }

        /** 当前类只提供了少许设置未读消息属性的方法,可以通过该方法获取MsgView对象从而各种设置 */
        public MsgView GetMsgView(int position)
        {
            if (position >= mTabCount)
            {
                position = mTabCount - 1;
            }
            View tabView = mTabsContainer.GetChildAt(position);
            MsgView tipView = (MsgView)tabView.FindViewById(Resource.Id.rtv_msg_tip);
            return tipView;
        }
        public void SetOnTabSelectListener(IOnTabSelectListener listener)
        {
            this.mListener = listener;
        }

        protected override IParcelable OnSaveInstanceState()
        {
            Bundle bundle = new Bundle();
            bundle.PutParcelable("instanceState", base.OnSaveInstanceState());
            bundle.PutInt("mCurrentTab", mCurrentTab);
            return bundle;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (state is Bundle)
            {
                Bundle bundle = (Bundle)state;
                mCurrentTab = bundle.GetInt("mCurrentTab");
                state = bundle.GetParcelableArray("instanceState").FirstOrDefault();//  .GetParcelable("instanceState");
                if (mCurrentTab != 0 && mTabsContainer.ChildCount > 0)
                {
                    updateTabSelection(mCurrentTab);
                    scrollToCurrentTab();
                }
            }
            base.OnRestoreInstanceState(state);
        }

        protected int dp2px(float dp)
        {
            float scale = mContext.Resources.DisplayMetrics.Density;//.getResources().getDisplayMetrics().density;
            return (int)(dp * scale + 0.5f);
        }

        protected int sp2px(float sp)
        {
            float scale = this.mContext.Resources.DisplayMetrics.ScaledDensity;//.getResources().getDisplayMetrics().scaledDensity;
            return (int)(sp * scale + 0.5f);
        }


        public class InnerPagerAdapter : FragmentPagerAdapter
        {
            private List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();
            private Java.Lang.String[] titles;

            public InnerPagerAdapter(Android.Support.V4.App.FragmentManager fm, List<Android.Support.V4.App.Fragment> fragments, Java.Lang.String[] titles)
                : base(fm)
            {
                this.fragments = fragments;
                this.titles = titles;
            }

            public override int Count
            {
                get
                {

                    return fragments.Count();
                }
            }
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return titles[position];
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return fragments[position];
            }

            //public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object object)

            //{
            //    // 覆写destroyItem并且空实现,这样每个Fragment中的视图就不会被销毁
            //   base.destroyItem(container, position, object);
            //}

            //public override int getItemPosition(Object object)
            //{
            //    return PagerAdapter.POSITION_NONE;
            //}

        }


    }
}
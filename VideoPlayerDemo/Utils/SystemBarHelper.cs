using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Utils
{
    /**
 * 状态栏工具类
 * 状态栏两种模式(Android 4.4以上)
 * 1.沉浸式全屏模式
 * 2.状态栏着色模式
 */
    public class SystemBarHelper
    {
        private static float DEFAULT_ALPHA = Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop ? 0.2f : 0.3f;

        /**
         * Android4.4以上的状态栏着色
         *
         * @param activity       Activity对象
         * @param statusBarColor 状态栏颜色
         */
        public static void tintStatusBar(Activity activity, int statusBarColor)
        {
            TintStatusBar(activity, statusBarColor, DEFAULT_ALPHA);
        }


        /**
         * Android4.4以上的状态栏着色
         *
         * @param activity       Activity对象
         * @param statusBarColor 状态栏颜色
         * @param alpha          透明栏透明度[0.0-1.0]
         */
        public static void TintStatusBar(Activity activity, int statusBarColor, float alpha)
        {
            TintStatusBar(activity.Window, statusBarColor, alpha);
        }


        /**
         * Android4.4以上的状态栏着色
         *
         * @param window         一般都是用于Activity的window,也可以是其他的例如Dialog,DialogFragment
         * @param statusBarColor 状态栏颜色
         */
        public static void TintStatusBar(Window window, int statusBarColor)
        {
            TintStatusBar(window, statusBarColor, DEFAULT_ALPHA);
        }


        /**
         * Android4.4以上的状态栏着色
         *
         * @param window         一般都是用于Activity的window,也可以是其他的例如Dialog,DialogFragment
         * @param statusBarColor 状态栏颜色
         * @param alpha          透明栏透明度[0.0-1.0]
         */
        public static void TintStatusBar(Window window, int statusBarColor, float alpha)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Kitkat)
            {
                return;
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);// WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
                window.SetStatusBarColor(Color.Transparent);
            }
            else
            {
                window.AddFlags(WindowManagerFlags.TranslucentStatus);// WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
            }
            ViewGroup decorView = (ViewGroup)window.DecorView;// GetDecorView();
            ViewGroup contentView = (ViewGroup)window.DecorView.FindViewById(Window.IdAndroidContent);// GetDecorView().findViewById(Window.ID_ANDROID_CONTENT);
            View rootView = contentView.GetChildAt(0);
            if (rootView != null)
            {
                rootView.SetFitsSystemWindows(true);
                //ViewCompat.SetFitsSystemWindows(rootView, true);
            }
            SetStatusBar(decorView, statusBarColor, true);
            SetTranslucentView(decorView, alpha);
        }


        /**
         * Android4.4以上的状态栏着色(针对于DrawerLayout)
         * 注:
         * 1.如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性,尤其是DrawerLayout的fitsSystemWindows属性
         * 2.可以版本判断在5.0以上不调用该方法,使用系统自带
         *
         * @param activity       Activity对象
         * @param drawerLayout   DrawerLayout对象
         * @param statusBarColor 状态栏颜色
         */
        public static void TintStatusBarForDrawer(Activity activity, DrawerLayout drawerLayout, int statusBarColor)
        {
            TintStatusBarForDrawer(activity, drawerLayout, statusBarColor, DEFAULT_ALPHA);
        }


        /**
         * Android4.4以上的状态栏着色(针对于DrawerLayout)
         * 注:
         * 1.如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性,尤其是DrawerLayout的fitsSystemWindows属性
         * 2.可以版本判断在5.0以上不调用该方法,使用系统自带
         *
         * @param activity       Activity对象
         * @param drawerLayout   DrawerLayout对象
         * @param statusBarColor 状态栏颜色
         * @param alpha          透明栏透明度[0.0-1.0]
         */
        public static void TintStatusBarForDrawer(Activity activity, DrawerLayout drawerLayout, int statusBarColor, float alpha)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Kitkat)
            {
                return;
            }

            Window window = activity.Window;//.getWindow();
            ViewGroup decorView = (ViewGroup)window.DecorView;// ();
            ViewGroup drawContent = (ViewGroup)drawerLayout.GetChildAt(0);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                window.ClearFlags(WindowManagerFlags.TranslucentStatus);// WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
                window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);// WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
                window.SetStatusBarColor(Color.Transparent);
                drawerLayout.SetStatusBarBackgroundColor(statusBarColor);
                int systemUiVisibility = (int)window.DecorView.SystemUiVisibility;// getDecorView().getSystemUiVisibility();

                systemUiVisibility |= (int)SystemUiFlags.Fullscreen;//  View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN;
                systemUiVisibility |= (int)SystemUiFlags.LayoutStable;// View.SYSTEM_UI_FLAG_LAYOUT_STABLE;

                window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;// getDecorView().setSystemUiVisibility(systemUiVisibility);
            }
            else
            {
                window.AddFlags(WindowManagerFlags.TranslucentStatus);// WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
            }
            SetStatusBar(decorView, statusBarColor, true, true);
            SetTranslucentView(decorView, alpha);
            drawerLayout.SetFitsSystemWindows(false);
            drawContent.SetFitsSystemWindows(true);
            ViewGroup drawer = (ViewGroup)drawerLayout.GetChildAt(1);
            drawer.SetFitsSystemWindows(false);
        }


        /**
         * Android4.4以上的沉浸式全屏模式
         * 注:
         * 1.删除fitsSystemWindows属性:Android5.0以上使用该方法如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性
         * 或者调用forceFitsSystemWindows方法
         * 2.不删除fitsSystemWindows属性:也可以区别处理,Android5.0以上使用自己的方式实现,不调用该方法
         *
         * @param activity Activity对象
         */
        public static void ImmersiveStatusBar(Activity activity)
        {
            ImmersiveStatusBar(activity, DEFAULT_ALPHA);
        }


        /**
         * Android4.4以上的沉浸式全屏模式
         * 注:
         * 1.删除fitsSystemWindows属性:Android5.0以上使用该方法如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性
         * 或者调用forceFitsSystemWindows方法
         * 2.不删除fitsSystemWindows属性:也可以区别处理,Android5.0以上使用自己的方式实现,不调用该方法
         *
         * @param activity Activity对象
         * @param alpha    透明栏透明度[0.0-1.0]
         */
        public static void ImmersiveStatusBar(Activity activity, float alpha)
        {
            ImmersiveStatusBar(activity.Window, alpha);
        }


        /**
         * Android4.4以上的沉浸式全屏模式
         * 注:
         * 1.删除fitsSystemWindows属性:Android5.0以上使用该方法如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性
         * 或者调用forceFitsSystemWindows方法
         * 2.不删除fitsSystemWindows属性:也可以区别处理,Android5.0以上使用自己的方式实现,不调用该方法
         *
         * @param window 一般都是用于Activity的window,也可以是其他的例如Dialog,DialogFragment
         */
        public static void ImmersiveStatusBar(Window window)
        {
            ImmersiveStatusBar(window, DEFAULT_ALPHA);
        }


        /**
         * Android4.4以上的沉浸式全屏模式
         * 注:
         * 1.删除fitsSystemWindows属性:Android5.0以上使用该方法如果出现界面展示不正确,删除布局中所有fitsSystemWindows属性
         * 或者调用forceFitsSystemWindows方法
         * 2.不删除fitsSystemWindows属性:也可以区别处理,Android5.0以上使用自己的方式实现,不调用该方法
         *
         * @param window 一般都是用于Activity的window,也可以是其他的例如Dialog,DialogFragment
         * @param alpha  透明栏透明度[0.0-1.0]
         */
        public static void ImmersiveStatusBar(Window window, float alpha)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Kitkat)
            {
                return;
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                window.ClearFlags(WindowManagerFlags.TranslucentStatus); //WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
                window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds); //WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
                window.SetStatusBarColor(Color.Transparent);
                int systemUiVisibility = (int)window.DecorView.SystemUiVisibility;// getDecorView().getSystemUiVisibility();


                systemUiVisibility |= (int)SystemUiFlags.Fullscreen;//  View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN;
                systemUiVisibility |= (int)SystemUiFlags.LayoutStable;// View.SYSTEM_UI_FLAG_LAYOUT_STABLE;

                //systemUiVisibility |= View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN;
                //systemUiVisibility |= View.SYSTEM_UI_FLAG_LAYOUT_STABLE;
                window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;// sGetDecorView().setSystemUiVisibility(systemUiVisibility);
            }
            else
            {
                window.AddFlags(WindowManagerFlags.TranslucentStatus); //WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
            }
            ViewGroup decorView = (ViewGroup)window.DecorView;// getDecorView();
            ViewGroup contentView = (ViewGroup)window.DecorView.FindViewById(Window.IdAndroidContent);// getDecorView().findViewById(Window.ID_ANDROID_CONTENT);
            View rootView = contentView.GetChildAt(0);
            int statusBarHeight = GetStatusBarHeight(window.Context);// getContext());
            if (rootView != null)
            {
                FrameLayout.LayoutParams lp = (FrameLayout.LayoutParams)rootView.LayoutParameters;//.GetLayoutParams();
                rootView.SetFitsSystemWindows(true);
                //ViewCompat.SetFitsSystemWindows(rootView, true);
                lp.TopMargin = -statusBarHeight;
                rootView.LayoutParameters = lp;// SetLayoutParams(lp);
            }

            SetTranslucentView(decorView, alpha);
        }


        /**
         * 设置状态栏darkMode,字体颜色及icon变黑(目前支持MIUI6以上,Flyme4以上,Android M以上)
         */
        public static void SetStatusBarDarkMode(Activity activity)
        {
            SetStatusBarDarkMode(activity.Window);//.getWindow());
        }


        /**
         * 设置状态栏darkMode,字体颜色及icon变黑(目前支持MIUI6以上,Flyme4以上,Android M以上)
         */
        public static void SetStatusBarDarkMode(Window window)
        {
            SetStatusBarDarkModeForM(window);
            return;
            //if (IsFlyme4Later())
            //{
            //    SetStatusBarDarkModeForFlyme4(window, true);
            //}
            //else if (IsMIUI6Later())
            //{
            //    SetStatusBarDarkModeForMIUI6(window, true);
            //}
            //else if (Build.VERSION.SdkInt < BuildVersionCodes.M)//SDK_INT >= Build.VERSION_CODES.M)
            //{
            //    SetStatusBarDarkModeForM(window);
            //}
        }


        /**
         * android 6.0设置字体颜色
         */

        public static void SetStatusBarDarkModeForM(Window window)
        {
            window.ClearFlags(WindowManagerFlags.TranslucentStatus); // WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);// WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
            window.SetStatusBarColor(Color.Transparent);
            int systemUiVisibility = (int)window.DecorView.SystemUiVisibility;
            systemUiVisibility |= (int)SystemUiFlags.LightStatusBar;//(int )iView.SYSTEM_UI_FLAG_LIGHT_STATUS_BAR;
            window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;// getDecorView().setSystemUiVisibility(systemUiVisibility);
        }


        /**
         * 设置Flyme4+的darkMode,darkMode时候字体颜色及icon变黑
         * http://open-wiki.flyme.cn/index.php?title=Flyme%E7%B3%BB%E7%BB%9FAPI
         */
        public static bool SetStatusBarDarkModeForFlyme4(Window window, bool dark)
        {
            return false;
            //bool result = false;
            //            if (window != null)
            //            {
            //                try
            //                {
            //                    window.LayoutParams e = window.GetAttributes();
            //                    Field darkFlag = WindowManager.LayoutParams.class.getDeclaredField("MEIZU_FLAG_DARK_STATUS_BAR_ICON");
            //        Field meizuFlags = WindowManager.LayoutParams.class.getDeclaredField("meizuFlags");
            //        darkFlag.setAccessible(true);
            //                meizuFlags.setAccessible(true);
            //                int bit = darkFlag.getInt(null);
            //        int value = meizuFlags.getInt(e);
            //                if (dark) {
            //                    value |= bit;
            //                } else {
            //                    value &= ~bit;
            //}
            //meizuFlags.setInt(e, value);
            //                window.setAttributes(e);
            //                result = true;
            //            } catch (Exception var8) {
            //                Log.e("StatusBar", "setStatusBarDarkIcon: failed");
            //            }
            //        }
            //        return result;
        }


        /**
         * 设置MIUI6+的状态栏是否为darkMode,darkMode时候字体颜色及icon变黑
         * http://dev.xiaomi.com/doc/p=4769/
         */
        public static void setStatusBarDarkModeForMIUI6(Window window, bool darkmode)
        {
            return;
            //Class <? extends Window > clazz = window.getClass();
            //try
            //{
            //    int darkModeFlag = 0;
            //    Class <?> layoutParams = Class.forName("android.view.MiuiWindowManager$LayoutParams");
            //    Field field = layoutParams.getField("EXTRA_FLAG_STATUS_BAR_DARK_MODE");
            //    darkModeFlag = field.getInt(layoutParams);
            //    Method extraFlagField = clazz.getMethod("setExtraFlags", int.class, int.class);
            //        extraFlagField.invoke(window, darkmode? darkModeFlag : 0, darkModeFlag);
            //    } catch (Exception e) {
            //        e.printStackTrace();
            //    }
        }


        /**
         * 创建假的状态栏View
         */
        private static void SetStatusBar(ViewGroup container, int statusBarColor, bool visible, bool addToFirst)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                View statusBarView = container.FindViewById(Resource.Id.statusbar_view);// findViewById(R.id.statusbar_view);
                if (statusBarView == null)
                {
                    statusBarView = new View(container.Context);//.getContext());
                    statusBarView.Id = Resource.Id.statusbar_view;// SetId(R.id.statusbar_view);
                    ViewGroup.LayoutParams lp = new ViewGroup.LayoutParams(
                            ViewGroup.LayoutParams.MatchParent, GetStatusBarHeight(container.Context));
                    if (addToFirst)
                    {
                        container.AddView(statusBarView, 0, lp);
                    }
                    else
                    {
                        container.AddView(statusBarView, lp);
                    }
                }
                Color statusbarColor = new Color(statusBarColor);
                statusBarView.SetBackgroundColor(statusbarColor);
                statusBarView.Visibility = visible ? ViewStates.Visible : ViewStates.Gone;//.SetVisibility(visible ? View.VISIBLE : View.GONE);
            }
        }


        /**
         * 创建假的状态栏View
         */
        private static void SetStatusBar(ViewGroup container, int statusBarColor, bool visible)
        {
            SetStatusBar(container, statusBarColor, visible, false);
        }


        /**
         * 创建假的透明栏
         */
        private static void SetTranslucentView(ViewGroup container, float alpha)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                View translucentView = container.FindViewById(Resource.Id.translucent_view);
                if (translucentView == null)
                {
                    translucentView = new View(container.Context);// getContext());
                    translucentView.Id = Resource.Id.translucent_view;//.setId(R.id.translucent_view);
                    ViewGroup.LayoutParams lp = new ViewGroup.LayoutParams(
                            ViewGroup.LayoutParams.MatchParent, GetStatusBarHeight(container.Context));
                    container.AddView(translucentView, lp);
                }
                translucentView.SetBackgroundColor(Color.Argb((int)(alpha * 255), 0, 0, 0));
            }
        }


        /**
         * 获取状态栏高度
         */
        public static int GetStatusBarHeight(Context context)
        {
            int result = 0;
            int resId = context.Resources.GetIdentifier("status_bar_height", "dimen", "android");//.getResources().getIdentifier("status_bar_height", "dimen", "android");
            if (resId > 0)
            {
                result = context.Resources.GetDimensionPixelSize(resId);
            }
            return result;
        }


        /**
         * 判断是否Flyme4以上
         */
        public static bool IsFlyme4Later()
        {
            //return false;
            return Build.Fingerprint.Contains("Flyme_OS_4") || Build.VERSION.Incremental.Contains("Flyme_OS_4");
            //||
            //    Regx
            //        Pattern.Compile("Flyme OS [4|5]", Pattern.CASE_INSENSITIVE).Matcher(Build.Display).Find();
        }


        /**
         * 判断是否为MIUI6以上
         */
        public static bool IsMIUI6Later()
        {
            return false;
            //    try
            //    {
            //        Class <?> clz = Class.forName("android.os.SystemProperties");
            //        Method mtd = clz.getMethod("get", String.class);
            //            String val = (String)mtd.invoke(null, "ro.miui.ui.version.name");
            //val = val.replaceAll("[vV]", "");
            //            int version = Integer.parseInt(val);
            //            return version >= 6;
            //        } catch (Exception e) {
            //            return false;
            //        }
        }


        /**
         * 增加View的高度以及paddingTop,增加的值为状态栏高度.一般是在沉浸式全屏给ToolBar用的
         */
        public static void SetHeightAndPadding(Context context, View view)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                ViewGroup.LayoutParams lp = view.LayoutParameters;// getLayoutParams();
                lp.Height += GetStatusBarHeight(context);//增高
                view.SetPadding(view.PaddingLeft, view.PaddingTop + GetStatusBarHeight(context),
                        view.PaddingRight, view.PaddingBottom);
            }
        }


        /**
         * 增加View的paddingTop,增加的值为状态栏高度
         */
        public static void setPadding(Context context, View view)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                view.SetPadding(view.PaddingLeft, view.PaddingTop + GetStatusBarHeight(context),
                        view.PaddingRight, view.PaddingBottom);
            }
        }


        /**
         * 强制rootView下面的子View的FitsSystemWindows为false
         */
        public static void forceFitsSystemWindows(Activity activity)
        {
            forceFitsSystemWindows(activity.Window);// getWindow());
        }


        /**
         * 强制rootView下面的子View的FitsSystemWindows为false
         */
        public static void forceFitsSystemWindows(Window window)
        {
            forceFitsSystemWindows((ViewGroup)window.DecorView.FindViewById(Window.IdAndroidContent));// .getDecorView().findViewById(Window.ID_ANDROID_CONTENT));
        }


        /**
         * 强制rootView下面的子View的FitsSystemWindows为false
         */
        public static void forceFitsSystemWindows(ViewGroup viewGroup)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                int count = viewGroup.ChildCount;// GetChildCount();
                for (int i = 0; i < count; i++)
                {
                    View view = viewGroup.GetChildAt(i);
                    if (view is ViewGroup)
                    {
                        forceFitsSystemWindows((ViewGroup)view);
                    }
                    else
                    {
                        if (ViewCompat.GetFitsSystemWindows(view))
                        {
                            view.SetFitsSystemWindows(false);
                            //ViewCompat.SetFitsSystemWindows(view, false);
                        }
                    }
                }
            }
        }
    }
}
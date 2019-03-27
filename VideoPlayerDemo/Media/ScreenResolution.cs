using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Lang.Reflect;

namespace VideoPlayerDemo.Media
{
    public class ScreenResolution
    {
        /**
    * Gets the resolution,
    *
    * @return a pair to return the width and height
    */

        public static Dictionary<int, int> GetResolution(Context ctx)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBeanMr1)
            {
                return GetRealResolution(ctx);
            }
            else
            {
                return GetRealResolutionOnOldDevice(ctx);
            }
        }


        /**
         * Gets resolution on old devices.
         * Tries the reflection to get the real resolution first.
         * Fall back to getDisplayMetrics if the above method failed.
         */
        private static Dictionary<int, int> GetRealResolutionOnOldDevice(Context ctx)
        {
            var dic = new Dictionary<int, int>();
            IWindowManager wm = ctx.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            //IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            try
            {
                Display display = wm.DefaultDisplay;

                var javaObj = (Java.Lang.Object)display;
                var javaClass = javaObj.Class;
                Java.Lang.Reflect.Method mGetRawWidth = javaClass.GetDeclaredMethod("Width", new Java.Lang.Class[] { Java.Lang.Boolean.Type });
                Java.Lang.Reflect.Method mGetRawHeight = javaClass.GetDeclaredMethod("Height", new Java.Lang.Class[] { Java.Lang.Boolean.Type });
                mGetRawWidth.Accessible = true;
                mGetRawHeight.Accessible = true;

                int realWidth = (int)mGetRawWidth.Invoke(display, new Java.Lang.Object[] { true });
                int realHeight = (int)mGetRawHeight.Invoke(display, new Java.Lang.Object[] { true });
                dic.Add(realWidth, realHeight);
                //Method mGetRawWidth = Display. .class.getMethod("getRawWidth");
                //Method mGetRawHeight = Display.class.getMethod("getRawHeight");
                //Integer realWidth = (Integer)mGetRawWidth.invoke(display);
                //Integer realHeight = (Integer)mGetRawHeight.invoke(display);

                //    return new Pair<>(realWidth, realHeight);
            }
            catch (Java.Lang.Exception e)
            {
                DisplayMetrics dm = new DisplayMetrics();
                wm.DefaultDisplay.GetMetrics(dm);
                dic.Add(dm.WidthPixels, dm.HeightPixels);
            }
            return dic;
        }


        /**
         * Gets real resolution via the new getRealMetrics API.
         */
        private static Dictionary<int, int> GetRealResolution(Context ctx)
        {
            IWindowManager wm = ctx.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            ///IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            //IWindowManager wm = (IWindowManager)ctx.GetSystemService(Context.WindowService);
            DisplayMetrics dm = new DisplayMetrics();
            //WindowManager.DefaultDisplay.GetMetrics(dm);
            Display display = wm.DefaultDisplay;
            DisplayMetrics metrics = new DisplayMetrics();
            display.GetRealMetrics(metrics);
            var dic = new Dictionary<int, int>();
            dic.Add(metrics.WidthPixels, metrics.HeightPixels);
            return dic;
        }

    }
}
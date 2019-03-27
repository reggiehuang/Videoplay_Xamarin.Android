using Android.Content;
using Android.Util;

namespace VideoPlayerDemo.Utils
{
    public class DisplayUtil
    {
        public static int px2dp(Context context, float pxValue)
        {
            float scale = context.Resources.DisplayMetrics.Density;// getResources().getDisplayMetrics().density;
            return (int)(pxValue / scale + 0.5f);
        }

        public static int dp2px(Context context, float dipValue)
        {
            float scale = context.Resources.DisplayMetrics.Density;// context.getResources().getDisplayMetrics().density;
            return (int)(dipValue * scale + 0.5f);
        }

        public static int px2sp(Context context, float pxValue)
        {
            float fontScale = context.Resources.DisplayMetrics.ScaledDensity;// context.getResources().getDisplayMetrics().scaledDensity;
            return (int)(pxValue / fontScale + 0.5f);
        }

        public static int sp2px(Context context, float spValue)
        {
            float fontScale = context.Resources.DisplayMetrics.ScaledDensity;// context.getResources().getDisplayMetrics().scaledDensity;
            return (int)(spValue * fontScale + 0.5f);
        }

        public static int getScreenWidth(Context context)
        {
            DisplayMetrics dm = context.Resources.DisplayMetrics;// 
            return dm.WidthPixels;// widthPixels;
        }

        public static int getScreenHeight(Context context)
        {
            DisplayMetrics dm = context.Resources.DisplayMetrics;// context.getResources().getDisplayMetrics();
            return dm.HeightPixels;
        }

        public static float getDisplayDensity(Context context)
        {
            if (context == null)
            {
                return -1;
            }
            return context.Resources.DisplayMetrics.Density; //context.getResources().getDisplayMetrics().density;
        }
    }
}
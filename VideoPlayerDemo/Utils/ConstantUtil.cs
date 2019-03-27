using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Utils
{

    public class ConstantUtil
    {
        public static string SHOP_URL = "";
        public static string VIP_URL = "";
        //用户投稿
        public static string USER_CONTRIBUTE = "0";
        //用户收藏夹
        public static string USER_FAVORITES = "1";
        //用户追番
        public static string USER_CHASE_BANGUMI = "2";
        //用户兴趣圈
        public static string USER_INTEREST_QUAN = "3";
        //用户投币
        public static string USER_COINS = "4";
        //用户游戏
        public static string USER_PLAY_GAME = "5";
        //用户直播状态
        public static string USER_LIVE_STATUS = "6";
        //用户mid
        public static string EXTRA_MID = "extra_mid";
        //用户name
        public static string EXTRA_USER_NAME = "user_name";
        //用户头像URL
        public static string EXTRA_AVATAR_URL = "avatar_url";
        //用户详情界面传递数据
        public static string EXTRA_DATA = "extra_data";
        public static string EXTRA_URL = "url";
        public static string EXTRA_TITLE = "title";
        public static string KEY = "login";
        public static string EXTRA_BANGUMI_KEY = "extra_season_id";
        public static string SUNDAY_TYPE = "周日";
        public static string MONDAY_TYPE = "周一";
        public static string TUESDAY_TYPE = "周二";
        public static string WEDNESDAY_TYPE = "周三";
        public static string THURSDAY_TYPE = "周四";
        public static string FRIDAY_TYEP = "周五";
        public static string SATURDAY_TYPE = "周六";
        public static string EXTRA_SPID = "spid";
        public static string EXTRA_SEASON_ID = "season_id";
        public static string EXTRA_KEY = "extra_type";
        public static string EXTRA_ORDER = "extra_order";
        public static string EXTRA_CID = "cid";
        public static string EXTRA_ONLINE = "online";
        public static string EXTRA_FACE = "face";
        public static string EXTRA_NAME = "name";
        public static string EXTRA_PARTITION = "extra_partition";
        public static string TYPE_TOPIC = "weblink";
        public static string TYPE_ACTIVITY_CENTER = "activity";
        public static string STYLE_PIC = "gl_pic";
        public static string EXTRA_CONTENT = "extra_content";
        public static string AID = "aid";
        public static string EXTRA_AV = "extra_av";
        public static string EXTRA_IMG_URL = "extra_img_url";
        public static string EXTRA_INFO = "extra_info";
        public static string VIDEO_TYPE_MP4 = "mp4";
        public static string SWITCH_MODE_KEY = "mode_key";
        public static string EXTRA_RID = "extra_rid";
        public static string EXTRA_POSITION = "extra_pos";
        public static int ADVERTISING_RID = 165;
    }
}
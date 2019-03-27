
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
using Polkovnik.DroidInjector;

namespace VideoPlayerDemo.Acticity
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        [View(Resource.Id.user_account)] private EditText edit_account;
        [View(Resource.Id.user_pwd)] private EditText edit_pwd;
        [View(Resource.Id.user_login)] private Button btn_submit;
        [View(Resource.Id.user_register)] private TextView txt_register;
        [View(Resource.Id.user_forgetpwd)] private TextView txt_forgetpwd;
        [View(Resource.Id.user_login_fb)] private ImageView img_login_fb;
        [View(Resource.Id.user_login_tw)] private ImageView img_login_tw;
        [View(Resource.Id.user_login_gp)] private ImageView img_login_gp;
        [View(Resource.Id.user_login_wc)] private ImageView img_login_wc;
        [View(Resource.Id.user_login_li)] private ImageView img_login_li;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            // Create your application here
            Injector.InjectViews();
            txt_register.Click += delegate
            {
                Toast.MakeText(this.ApplicationContext, "TEST TEST", ToastLength.Short).Show();
            };
        }
    }
}
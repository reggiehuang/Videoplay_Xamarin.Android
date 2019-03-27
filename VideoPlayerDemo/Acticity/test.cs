using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Acticity
{
    [Activity(Label = "test")]
    public class test : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_test);//.test.layout.activity_main2);
            CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout)FindViewById(Resource.Id.collapsing_toolbar_layout);
            ImageView iv = (ImageView)FindViewById(Resource.Id.iv);
            Android.Support.V7.Widget.Toolbar toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            toolbar.SetNavigationIcon(Resource.Mipmap.category);
            collapsingToolbarLayout.Title = "CollapsingToolbarLayout";// setTitle("CollapsingToolbarLayout");
            collapsingToolbarLayout.SetCollapsedTitleTextColor((int)Color.White);  //setCollapsedTitleTextColor(Color.WHITE);
            collapsingToolbarLayout.SetExpandedTitleColor((int)Color.White);
            iv.SetImageResource(Resource.Mipmap.bg_login);
            
            // Create your application here
        }
    }
}
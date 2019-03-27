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
    [Activity(Label = "testActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class testActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_test);//.test.layout.activity_main2);
            CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout)FindViewById(Resource.Id.collapsing_toolbar_layout);
            //ImageView iv = (ImageView)FindViewById(Resource.Id.iv);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            toolbar.SetNavigationIcon(Resource.Mipmap.category);
            collapsingToolbarLayout.Title = "TEST";// setTitle("CollapsingToolbarLayout");
            collapsingToolbarLayout.SetCollapsedTitleTextColor((int)Color.White);  //setCollapsedTitleTextColor(Color.WHITE);
            collapsingToolbarLayout.SetExpandedTitleColor((int)Color.White);
            // Create your application here
        }
    }
}
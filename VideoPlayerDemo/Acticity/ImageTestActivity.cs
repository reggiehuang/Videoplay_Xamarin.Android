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
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request;
using Com.Bumptech.Glide.Load.Engine;

namespace VideoPlayerDemo.Acticity
{
    [Activity(Label = "ImageTestActivity")]
    public class ImageTestActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1_image);//.test.layout.activity_main2);
            string url = "http://img1.dzwww.com:8080/tupian_pl/20150813/16/7858995348613407436.jpg";
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imgView);
            var requestOptions = new RequestOptions();
            requestOptions.Placeholder(Resource.Drawable.I5);
            requestOptions.CenterCrop();
            requestOptions.DontAnimate();
            //requestOptions.SkipMemoryCache(true);
            
            requestOptions.Error(Resource.Drawable.I7);

            //Glide.With(this).Load(ImageUrl).Apply(requestOptions).Into(imageView);
            RequestOptions.DiskCacheStrategyOf(DiskCacheStrategy.None);//磁盘缓存

            Glide.With(imageView.Context)
                .Load(url)
                
                //.Load(Resource.Drawable.I8)
                //.PlaceHolder(R.drawable.place_image)//图片加载出来前，显示的图片
                //.Error(Resource.Drawable.girl)//图片加载失败后，显示的图片
                .Apply(requestOptions)
                .Apply(RequestOptions.CircleCropTransform())
                .Into(imageView);//.Into(imageView);
              //new GlideDrawableImageViewTarget


            // Create your application here
        }
    }
}
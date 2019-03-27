using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Acticity.Adapter
{
    public class SimpleCardFragment : Fragment
    {
        private String mTitle;


        public static SimpleCardFragment getInstance(String title)
        {
            SimpleCardFragment sf = new SimpleCardFragment();
            sf.mTitle = title;
            return sf;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);

            View v = inflater.Inflate(Resource.Layout.fr_simple_card, null);
            TextView card_title_tv = (TextView)v.FindViewById(Resource.Id.card_title_tv);
            card_title_tv.Text = mTitle;//.setText(mTitle);
            return v;
        }
    }
}
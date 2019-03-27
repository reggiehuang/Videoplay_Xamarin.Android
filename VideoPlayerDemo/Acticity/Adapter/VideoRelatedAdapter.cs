using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request;
using Java.Lang;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using VideoPlayerDemo.Event;

namespace VideoPlayerDemo.Acticity.Adapter
{  /**
  * Created by hcc on 16/8/7 21:18
  * 100332338@qq.com
  * <p/>
  * 视频详情界面相关视频adapter
  */
    public class VideoRelatedAdapter : AbsRecyclerViewAdapter
    {
        private List<ArticleComment> relates;

        public override int ItemCount => getItemCount();

        public VideoRelatedAdapter(RecyclerView recyclerView, List<ArticleComment> relates) : base(recyclerView)
        {
            this.relates = relates;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            bindContext(parent.Context);//.getContext());
            return new ItemViewHolder(LayoutInflater.From(getContext()).
                    Inflate(Resource.Layout.item_video_strip, parent, false));
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            if (holder is ItemViewHolder)
            {
                ItemViewHolder itemViewHolder = (ItemViewHolder)holder;
                var relatesBean = relates[position];//.get(position);
                var dd = "http://d.hiphotos.baidu.com/image/pic/item/d000baa1cd11728bc4388fe7c5fcc3cec2fd2cd9.jpg";

                var requestOptions = new RequestOptions();
                requestOptions.Placeholder(Resource.Drawable.I1);
                requestOptions.CenterCrop();
                requestOptions.DontAnimate();
                requestOptions.Error(Resource.Drawable.I7);
                requestOptions.CircleCrop();

                Glide.With(holder.ItemView)
                    .Load(dd)
                    .Apply(requestOptions)
                    .Into(itemViewHolder.mVideoPic);
                    //.i
                    //.with(getContext())
                    //    .load(relatesBean.getPic())
                    //    .centerCrop()
                    //    .diskCacheStrategy(DiskCacheStrategy.ALL)
                    //    .placeholder(R.drawable.bili_default_image_tv)
                    //    .dontAnimate()
                    //    .into(itemViewHolder.mVideoPic);

                itemViewHolder.mVideoTitle.Text = "Test";// relatesBean.getTitle();//.setText(relatesBean.getTitle());
                itemViewHolder.mVideoPlayNum.Text = "10";// relatesBean.getStat().getView().ToString();//.setText(
                                                                                               //NumberUtil.converString(relatesBean.getStat().getView()));
                itemViewHolder.mVideoReviewNum.Text = "0";// relatesBean.getStat().getView().ToString();//setText(
                                                          // NumberUtil.converString(relatesBean.getStat().getDanmaku()));
                itemViewHolder.mUpName.Text = "Someone";// relatesBean.getOwner().getName();// setText(relatesBean.getOwner().getName());
            }

        }


        public int getItemCount()
        {
            return relates.Count;// size();
        }


        public class ItemViewHolder : AbsRecyclerViewAdapter.ClickableViewHolder
        {

            public ImageView mVideoPic;
            public TextView mVideoTitle;
            public TextView mVideoPlayNum;
            public TextView mVideoReviewNum;
            public TextView mUpName;

            public ItemViewHolder(View itemView) : base(itemView)
            {
                mVideoPic = itemView.FindViewById<ImageView>(Resource.Id.item_img);
                mVideoTitle = itemView.FindViewById<TextView>(Resource.Id.item_title);//$(R.id.item_title);
                mVideoPlayNum = itemView.FindViewById<TextView>(Resource.Id.item_play);//$(R.id.item_play);
                mVideoReviewNum = itemView.FindViewById<TextView>(Resource.Id.item_review);//$(R.id.item_review);
                mUpName = itemView.FindViewById<TextView>(Resource.Id.item_user_name);//$(R.id.item_user_name);
            }
        }

        /// <param name="successAction">获取图片成功回调方法</param>
        /// <param name="errorAction">获取失败回调方法</param>
        public void GetStreamAsync(string url, Action successAction, Action<string> errorAction)
        {
            try
            {
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest();
                var result = client.GetAsync(request, (response, handler) => {
                    if (response.StatusCode == 0)
                    {
                        errorAction("网络状况差,请稍后再试");
                        return;
                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var bytes = response.RawBytes;
                        MemoryStream stream = new MemoryStream(bytes);
                        var bitmap = BitmapFactory.DecodeStream(stream);
                        successAction();
                    }
                });
            }
            catch (Java.Lang.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.StackTrace);
                errorAction(ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Square.OkHttp3;
using VideoPlayerDemo.Acticity.Adapter;
using VideoPlayerDemo.Base;
using VideoPlayerDemo.Event;
using VideoPlayerDemo.Utils;
using VideoPlayerDemo.Widget;

namespace VideoPlayerDemo.Acticity
{
    /**
   * Created by hcc on 16/8/4 21:18
   * 100332338@qq.com
   * <p/>
   * 视频简介界面
   */
    public class VideoIntroductionFragment : RxLazyFragment, MyTask.IMyTask
    {
        TextView mTitleText; //  @BindView(R.id.tv_title)
        TextView mPlayTimeText;//@BindView(R.id.tv_play_time)
        TextView mReviewCountText;//  @BindView(R.id.tv_review_count)
        TextView mDescText;// @BindView(R.id.tv_description)
        //UserTagView mAuthorTagView;//  @BindView(R.id.author_tag)
        TextView mShareNum;//   @BindView(R.id.share_num)
        TextView mCoinNum;//  @BindView(R.id.coin_num)
        TextView mFavNum;//  @BindView(R.id.fav_num)
                         //TagFlowLayout mTagFlowLayout;// @BindView(R.id.tags_layout)
        RecyclerView mRecyclerView;//  @BindView(R.id.recycle)
        RelativeLayout mVideoRelatedLayout;//    @BindView(R.id.layout_video_related)

        private int av;
        // private VideoDetailsInfo.DataBean mVideoDetailsInfo;

        private List<VideoModel> list;
        private MyHandler _myHandler;
        List<ArticleComment> comments = new List<ArticleComment>();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return base.OnCreateView(inflater, container, savedInstanceState);
            //return inflater.Inflate(Resource.Layout.fragment_video_introduction, container, false);
        }



        public static VideoIntroductionFragment newInstance(int aid)
        {
            VideoIntroductionFragment fragment = new VideoIntroductionFragment();
            Bundle bundle = new Bundle();
            bundle.PutInt(ConstantUtil.EXTRA_AV, aid);
            //fragment.Arguments = bundle;// SetArguments(bundle);
            return fragment;
        }

        public override int getLayoutResId()
        {
            return Resource.Layout.fragment_video_introduction;//.layout.fragment_video_introduction;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mTitleText = view.FindViewById<TextView>(Resource.Id.tv_title);
            mPlayTimeText = view.FindViewById<TextView>(Resource.Id.tv_play_time);
            mReviewCountText = view.FindViewById<TextView>(Resource.Id.tv_review_count);
            mDescText = view.FindViewById<TextView>(Resource.Id.tv_description);
            mShareNum = view.FindViewById<TextView>(Resource.Id.share_num);
            mCoinNum = view.FindViewById<TextView>(Resource.Id.coin_num);
            mFavNum = view.FindViewById<TextView>(Resource.Id.fav_num);
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycle);
            mVideoRelatedLayout = view.FindViewById<RelativeLayout>(Resource.Id.layout_video_related);

            //finishCreateView(savedInstanceState);

            base.OnViewCreated(view, savedInstanceState);
        }

        public override void finishCreateView(Bundle state)
        {
           
            av = 1;// Arguments.GetInt(ConstantUtil.EXTRA_AV);// getArguments().getInt(ConstantUtil.EXTRA_AV);
            loadData();
        }

        protected void loadData()
        {
            var Endpoint = "http://47.91.249.226:8000/api/Video/GetAllVideos";

            MyTask myTask = new MyTask();
            myTask.SetLitener(this);
            myTask.Execute(Endpoint); //启动异步任务


            //Action action = () =>
            //{
            //    OkHttpClient client = new OkHttpClient();
               

            //    // Create request for remote resource.
            //    Request request = new Request.Builder()
            //        .Url(Endpoint)
            //        .Build();

            //    // Execute the request and retrieve the response.
            //    Response response = client.NewCall(request).ExecuteAsync().Result;

            //    // Deserialize HTTP response to concrete type.
            //    string body = response.Body().StringAsync().Result;
            //    list = new List<VideoModel>();
            //    list = JsonConvert.DeserializeObject<List<VideoModel>>(body);
            //};


            _myHandler = new MyHandler(GetValue); //在主线程实例化一个Handler对象

            //RetrofitHelper.getBiliAppAPI()
            //        .getVideoDetails(av)
            //        .compose(this.bindToLifecycle())
            //        .subscribeOn(Schedulers.io())
            //        .observeOn(AndroidSchedulers.mainThread())
            //        .subscribe(videoDetails-> {
            //    mVideoDetailsInfo = videoDetails.getData();
            //    finishTask();
            //}, throwable-> {
            //});
            finishTask();
        }

        public class MyHandler : Handler
        {
            private Action<Message> _action;//指向一个回调方法的委托
            public MyHandler(Action<Message> action)
            {
                _action = action;//构造方法中传入处理消息的回调方法
            }
            //重写父类的HandleMessage方法
            public override void HandleMessage(Message msg)
            {
                //if (_action != null)
                //{
                //    _action.Invoke(msg);
                //}
                _action?.Invoke(msg); //C#6.0新增判断空值的方式
            }
        }

        public class ReadDataTask : Java.Lang.Object, Java.Lang.IRunnable
        {
            private Handler _handler;

            public ReadDataTask(Handler handler)
            {
                _handler = handler;
            }

            public void Run()//子线程要运行的任务
            {
                try
                {
                    Java.Lang.Thread.Sleep(4000);// 模拟任务，比如从远程服务器读取数据

                    Message msg = _handler.ObtainMessage();//创建一个消息对象
                    msg.What = 123; //设置消息对象的标识
                    msg.Obj = "已读取到数据";//消息对象携带一个字符串数据

                    _handler.SendMessage(msg);// 将消息对象发送到主线程的消息队列(MessageQueue)中
                }
                catch (Java.Lang.InterruptedException e)
                {
                    Log.Debug("ReadInfoTask", e.Message);
                }
            }
        }

        private void GetValue(Message msg)//在主线程更新UI
        {
            var msgStr = msg.What;
            OkHttpClient client = new OkHttpClient();
            var Endpoint = "http://47.91.249.226:8000/api/Video/GetAllVideos";

            // Create request for remote resource.
            Request request = new Request.Builder()
                .Url(Endpoint)
                .Build();

            // Execute the request and retrieve the response.
            Response response = client.NewCall(request).ExecuteAsync().Result;

            // Deserialize HTTP response to concrete type.
            string body = response.Body().StringAsync().Result;
            list = new List<VideoModel>();
            list = JsonConvert.DeserializeObject<List<VideoModel>>(body);
        }

        protected void finishTask()
        {
            //设置视频标题
            mTitleText.Text = "Test";// mVideoDetailsInfo.getTitle();//.setText();
                                                           //设置视频播放数量
            mPlayTimeText.Text = "Test"; //mVideoDetailsInfo.getStat().getView().ToString();//.setText(NumberUtil.converString(mVideoDetailsInfo.getStat().getView()));
                                                                                  //设置视频弹幕数量
            mReviewCountText.Text = "0";//.setText(NumberUtil.converString(mVideoDetailsInfo.getStat().getDanmaku()));
                                        //设置Up主信息
            mDescText.Text = "Test";// mVideoDetailsInfo.getDesc();//.setText(mVideoDetailsInfo.getDesc());
                                                         //mAuthorTagView.SetUpWithInfo(this.Activity, mVideoDetailsInfo.getOwner().getName(), mVideoDetailsInfo.getOwner().getMid(), mVideoDetailsInfo.getOwner().getFace());// .setUpWithInfo(getActivity(), mVideoDetailsInfo.getOwner().getName(),
                                                         //mVideoDetailsInfo.getOwner().getMid(), mVideoDetailsInfo.getOwner().getFace());
                                                         //设置分享 收藏 投币数量
            mShareNum.Text = "0";//setText(NumberUtil.converString(mVideoDetailsInfo.getStat().getShare()));
            mFavNum.Text = "0";//.setText(NumberUtil.converString(mVideoDetailsInfo.getStat().getFavorite()));
            mCoinNum.Text = "0";//.setText(NumberUtil.converString(mVideoDetailsInfo.getStat().getCoin()));
                                //设置视频tags
            setVideoTags();
            //设置视频相关
            setVideoRelated();
        }

        private void setVideoRelated()
        {
            mVideoRelatedLayout.Visibility = ViewStates.Gone;//.setVisibility(View.GONE);
        

            //List<VideoDetailsInfo.DataBean.RelatesBean> relates = mVideoDetailsInfo.getRelates();
            //if (relates == null)
            //{
            //    mVideoRelatedLayout.Visibility = ViewStates.Gone;//.setVisibility(View.GONE);
            //    return;
            //}
            var a = new List<string>();
            a.Add("Test Demo");

           // GetComments();

            VideoRelatedAdapter mVideoRelatedAdapter = new VideoRelatedAdapter(mRecyclerView, comments);
            mRecyclerView.HasFixedSize = false;//  SetHasFixedSize(false);
            mRecyclerView.NestedScrollingEnabled = false;//  SetNestedScrollingEnabled(false);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(base.Context, LinearLayoutManager.Vertical, true));
            mRecyclerView.SetAdapter(mVideoRelatedAdapter);
            //mVideoRelatedAdapter.SetOnItemClickListener((position, holder)->VideoDetailsActivity.launch(getActivity(),
            //        relates.get(position).getAid(), relates.get(position).getPic()));
            return;
        }

        private void setVideoTags()
        {
            return;
            //List<string> tags = mVideoDetailsInfo.getTags();
            //    mTagFlowLayout.setAdapter(new TagAdapter<String>(tags) {
            //        @Override
            //        public View getView(FlowLayout parent, int position, String s)
            //    {
            //        TextView mTags = (TextView)LayoutInflater.from(getActivity()).inflate(R.layout.layout_tags_item, parent, false);
            //        mTags.setText(s);
            //        return mTags;
            //    }
            //});
        }

        public void OnFinish(string result)
        {
            list = new List<VideoModel>();
            list = JsonConvert.DeserializeObject<List<VideoModel>>(result);
            return;
        }
        private  void GetComments()//在主线程更新UI
        {
            OkHttpClient client = new OkHttpClient();
            var Endpoint = string.Format(@"http://cacakaka.com:8000/api/Video/GetVideoCommons?vid={0}&pageIndex={1}&pageSize={2}", 1,1,20) ;// "http://47.91.249.226:8000/api/Video/GetAllVideos";

            // Create request for remote resource.
            Request request = new Request.Builder()
                .Url(Endpoint)
                .Build();
           
            // Execute the request and retrieve the response.
            Response response = client.NewCall(request).ExecuteAsync().Result;
            // Deserialize HTTP response to concrete type.
            string body = response.Body().StringAsync().Result;
            comments = new List<ArticleComment>();
            comments = JsonConvert.DeserializeObject<List<ArticleComment>>(body);
        }


        //@OnClick(R.id.btn_share)
        //    void share()
        //{
        //    Intent intent = new Intent(Intent.ACTION_SEND);
        //    intent.setType("text/plain");
        //    intent.putExtra(Intent.EXTRA_SUBJECT, "分享");
        //    intent.putExtra(Intent.EXTRA_TEXT, "来自「哔哩哔哩」的分享:" + mVideoDetailsInfo.getDesc());
        //    startActivity(Intent.createChooser(intent, mVideoDetailsInfo.getTitle()));
        //}
    }

}
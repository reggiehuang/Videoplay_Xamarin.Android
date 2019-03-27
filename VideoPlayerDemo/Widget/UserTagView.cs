using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using VideoPlayerDemo.Activities;
using VideoPlayerDemo.Utils;

namespace VideoPlayerDemo.Widget
{
    public class UserTagView : FrameLayout
    {
        private CircleImageView avatarView;
        private TextView userNameText;
        private IOnClickListener onClickListener;
        private Activity activity;
        private string name;
        private int mid = -1;
        private string avatarUrl;

        public UserTagView(Context context) : base(context)
        {
        }

        public UserTagView(Context context, IAttributeSet attrs) : base(context, attrs, 0)
        {

        }

        public UserTagView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {

            LinearLayout cardView = (LinearLayout)LayoutInflater.From(context)
                .Inflate(Resource.Layout.layout_user_tag_view, null);
            avatarView = (CircleImageView)cardView.FindViewById(Resource.Id.user_avatar);
            userNameText = (TextView)cardView.FindViewById(Resource.Id.user_name);
            ViewGroup.LayoutParams lp = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, Resources.GetDimensionPixelSize(Resource.Dimension.user_tag_view_height));
            //getResources().getDimensionPixelSize(Resource.Dimension.user_tag_view_height));
            this.AddView(cardView, lp);
            IOnClickListener onclickModel = new OnClickListener(this);
            cardView.SetOnClickListener(onclickModel);
        }

        public class OnClickListener : Java.Lang.Object, IOnClickListener
        {
            private UserTagView ut_view;
            public OnClickListener(UserTagView model)
            {
                ut_view = model;
            }
            public void OnClick(View v)
            {

                if (ut_view == null) return;
                if (ut_view.mid != -1 && ut_view.activity != null)
                {
                    Intent intent = new Intent(ut_view.Context, typeof(VideoPlayerActivity));
                    intent.AddFlags(ActivityFlags.NewTask);// Intent.FLAG_ACTIVITY_NEW_TASK);
                    intent.PutExtra(ConstantUtil.EXTRA_USER_NAME, ut_view.name);
                    intent.PutExtra(ConstantUtil.EXTRA_MID, ut_view.mid);
                    intent.PutExtra(ConstantUtil.EXTRA_AVATAR_URL, ut_view.avatarUrl);
                    ut_view.activity.StartActivity(intent);
                    //UserInfoDetailsActivity.launch(ut_view.activity, ut_view.name, ut_view.mid, ut_view.avatarUrl);
                }

            }

        }

        public void SetAvatar(Bitmap bitmap)
        {
            avatarView.SetImageBitmap(bitmap);
        }

        public void SetAvatar(Drawable drawable)
        {
            avatarView.SetImageDrawable(drawable);
        }

        public void setAvatar(int id)
        {
            avatarView.SetImageResource(id);
        }

        public CircleImageView GetAvatarView()
        {
            return this.avatarView;
        }

        public void SetUserName(String userName)
        {
            userNameText.Text = userName;// setText(userName);
        }

        public TextView GetUserNameText()
        {
            return this.userNameText;
        }

        public void SetUpWithInfo(Activity activity, String name, int mid, String avatarUrl)
        {
            this.activity = activity;
            this.name = name;
            this.mid = mid;
            this.avatarUrl = avatarUrl;
            this.SetUserName(name);
            //Glide.with(getContext())
            //        .load(this.avatarUrl)
            //        .centerCrop()
            //        .dontAnimate()
            //        .placeholder(R.drawable.ico_user_default)
            //        .diskCacheStrategy(DiskCacheStrategy.ALL)
            //        .into(avatarView);
        }


        public override void SetOnClickListener(IOnClickListener listener)
        {
            this.onClickListener = listener;
        }
    }
}
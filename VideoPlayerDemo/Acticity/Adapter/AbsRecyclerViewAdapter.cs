using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;

namespace VideoPlayerDemo.Acticity.Adapter
{
    /**
  * Created by hcc on 16/8/4 14:12
  * 100332338@qq.com
  * <p/>
  * RecycleViewAdapter基类
  */
    //AbsRecyclerViewAdapter.ClickableViewHolder
    public abstract class AbsRecyclerViewAdapter : RecyclerView.Adapter
    {

        private Context context;
        protected RecyclerView mRecyclerView;
        private List<RecyclerView.OnScrollListener> mListeners = new List<RecyclerView.OnScrollListener>();


        public AbsRecyclerViewAdapter(RecyclerView recyclerView)
        {
            this.mRecyclerView = recyclerView;
            var asbonscrolllistener = new Abs_OnScrollListener(this);
            this.mRecyclerView.AddOnScrollListener(asbonscrolllistener);
        }

        public class Abs_OnScrollListener : RecyclerView.OnScrollListener
        {
            private AbsRecyclerViewAdapter ads_Adapter;
            public Abs_OnScrollListener(AbsRecyclerViewAdapter model)
            {
                ads_Adapter = model;
            }
            public override void OnScrollStateChanged(RecyclerView rv, int newState)
            {
                foreach (RecyclerView.OnScrollListener listener in ads_Adapter.mListeners)
                {
                    listener.OnScrollStateChanged(rv, newState);
                }
                //for (RecyclerView.OnScrollListener listener : ads_Adapter.mListeners)
                //{
                //    listener.onScrollStateChanged(rv, newState);
                //}
            }

            public override void OnScrolled(RecyclerView rv, int dx, int dy)
            {
                foreach (RecyclerView.OnScrollListener listener in ads_Adapter.mListeners)
                {
                    listener.OnScrolled(rv, dx, dy);
                }
                //for (RecyclerView.OnScrollListener listener : mListeners)
                //{
                //    listener.onScrolled(rv, dx, dy);
                //}
            }

        }


        public void AddOnScrollListener(RecyclerView.OnScrollListener listener)
        {
            mListeners.Add(listener);
        }


        public interface OnItemClickListener
        {
            void OnItemClick(int position, ClickableViewHolder holder);
        }

        public interface OnItemLongClickListener
        {
            bool OnItemLongClick(int position, ClickableViewHolder holder);
        }

        private OnItemClickListener itemClickListener;
        private OnItemLongClickListener itemLongClickListener;


        public void SetOnItemClickListener(OnItemClickListener listener)
        {
            this.itemClickListener = listener;
        }


        public void SetOnItemLongClickListener(OnItemLongClickListener listener)
        {
            this.itemLongClickListener = listener;
        }


        public void bindContext(Context context)
        {
            this.context = context;
        }


        public Context getContext()
        {
            return this.context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ClickableViewHolder)
            {
                var v_holder = (ClickableViewHolder)holder;
                var absonclick = new Abs_OnClickListener(this, v_holder, position);
                v_holder.GetParentView().SetOnClickListener(absonclick);
                var absonlongclick = new Abs_OnLongClickListener(this, v_holder, position);
                v_holder.GetParentView().SetOnLongClickListener(absonlongclick);
            }

        }

        public class Abs_OnLongClickListener : Java.Lang.Object, View.IOnLongClickListener
        {
            ClickableViewHolder holder;
            int position;
            private AbsRecyclerViewAdapter ads_Adapter;
            public Abs_OnLongClickListener(AbsRecyclerViewAdapter model, ClickableViewHolder h, int p)
            {
                ads_Adapter = model;
                holder = h;
                position = p;
            }

            public bool OnLongClick(View v)
            {
                if (ads_Adapter.itemLongClickListener == null) return false;
                return ads_Adapter.itemLongClickListener.OnItemLongClick(position, holder);
                //throw new NotImplementedException();
            }
        }

        public class Abs_OnClickListener : Java.Lang.Object, View.IOnClickListener
        {
            ClickableViewHolder holder;
            int position;
            private AbsRecyclerViewAdapter ads_Adapter;
            public Abs_OnClickListener(AbsRecyclerViewAdapter model, ClickableViewHolder h, int p)
            {
                ads_Adapter = model;
                holder = h;
                position = p;
            }
            public void OnClick(View v)
            {
                if (ads_Adapter.itemClickListener != null)
                {
                    ads_Adapter.itemClickListener.OnItemClick(position, holder);
                }
            }
        }


        public class ClickableViewHolder : RecyclerView.ViewHolder
        {
            private View parentView;

            public ClickableViewHolder(View itemView) : base(itemView)
            {

                this.parentView = itemView;
            }


            public View GetParentView()
            {
                return parentView;
            }

            public T GetViewById<T>(int id) where T : View
            {
                return (T)parentView.FindViewById(id);
            }

        }
    }
}
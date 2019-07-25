using System;
using Android.Support.V7.Widget;
using Android.Views;
using Xamabrouk.Actions;

namespace Xamabrouk
{
    public abstract class XMAdaptarViewHolder : RecyclerView.ViewHolder
    {
        public XMAdaptarViewHolder(View itemView, Action<int, XMRecyclerViewAction, XMViewCardAction> action) : base(itemView)
        {
            InitComponents(itemView, action);
            InitEvents(itemView, action);
        }
        public abstract void InitComponents(View itemView, Action<int, XMRecyclerViewAction, XMViewCardAction> action);
        public abstract void InitEvents(View itemView, Action<int, XMRecyclerViewAction, XMViewCardAction> action);
    }
}
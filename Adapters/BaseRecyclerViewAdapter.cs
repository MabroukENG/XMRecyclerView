using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Xamabrouk.Actions;
using Xamabrouk.Entities;
using Xamabrouk.EvArgs;

namespace Xamabrouk
{
    /// <summary>
    /// Defines the generic adapter of any Recycler view that will be used in our application.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TViewHolder">Type of the view holder</typeparam>
    public abstract class XMRecyclerViewAdapter<T, TViewHolder> : RecyclerView.Adapter where TViewHolder : XMAdaptarViewHolder
    {

        protected Context context;

        /// <summary>
        /// The source id of the view card designed in <see cref="Resource.Layout"/> for the current <see cref="RecyclerView"/> items.
        /// </summary>
        public abstract int CardViewResourceId { get; }
        public virtual bool AttachViewToRoot { get; } = false;


        /// <summary>
        /// Handles an event when any item in the current <see cref="RecyclerView"/> is selected.
        /// </summary>
        public event EventHandler<XMItemClickEventArgs<T>> ItemClick;

        public event EventHandler<XMViewCardActionEventArgs<T>> OnViewCardActionHandled;

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        public override int ItemCount => DataSource?.Count ?? 0;

        /// <summary>
        /// Gets or sets the data source of the current <see cref="RecyclerView"/> instance. It defines a <see cref="XMDataCollection{T}"/> instance.
        /// </summary>
        public virtual XMDataCollection<T> DataSource { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMRecyclerViewAdapter{T, TViewHolder}"/> class.
        /// </summary>
        /// <param name="context">The context</param>
        public XMRecyclerViewAdapter(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMRecyclerViewAdapter{T, TViewHolder}"/> class.
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="dataSource">The initial data source</param>
        public XMRecyclerViewAdapter(Context context, XMDataCollection<T> dataSource) : this(context)
        {
            DataSource = dataSource;
        }

        /// <summary>
        /// Called when the <see cref="RecyclerView.ViewHolder"/> instance should be created.
        /// </summary>
        /// <param name="parent">The parent <see cref="ViewGroup"/></param>
        /// <param name="viewType">The type of the view</param>
        /// <returns></returns>
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the item:
            View itemView = LayoutInflater.From(parent.Context).Inflate(CardViewResourceId, parent, AttachViewToRoot);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            TViewHolder vh = CreateViewHolderIntance(itemView, HandelAction);
            return vh;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RecyclerView.ViewHolder"/>.
        /// </summary>
        /// <param name="itemView"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected abstract TViewHolder CreateViewHolderIntance(View itemView, Action<int, XMRecyclerViewAction, XMViewCardAction> action);

        protected void HandelAction(int position, XMRecyclerViewAction action, XMViewCardAction viewCardAction)
        {
            switch (action)
            {
                case XMRecyclerViewAction.Selection:
                    ItemClick?.Invoke(this, new XMItemClickEventArgs<T>(position, DataSource[position]));
                    break;
                case XMRecyclerViewAction.CardViewAction:
                    var args = new XMViewCardActionEventArgs<T>(position, viewCardAction, DataSource[position]);
                    HandleViewCardAction(args);
                    OnViewCardActionHandled?.Invoke(this, args);
                    break;
            }
        }

        /// <summary>
        /// Handles any <see cref="XMViewCardAction"/> defined for the current ViewCard.
        /// </summary>
        /// <param name="e"></param>
        protected abstract void HandleViewCardAction(XMViewCardActionEventArgs<T> e);
        // Fill in the contents of the item card (invoked by the layout manager):
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TViewHolder vh = holder as TViewHolder;
            BindViewHolder(vh, position);
        }

        /// <summary>
        /// Fills the contents of the ViewCard.
        /// </summary>
        /// <param name="viewHolder"></param>
        /// <param name="position"></param>
        protected abstract void BindViewHolder(TViewHolder viewHolder, int position);
    }
}
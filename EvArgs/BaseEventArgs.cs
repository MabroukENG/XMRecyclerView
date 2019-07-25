using System;
using Xamabrouk.Entities;

namespace Xamabrouk.EvArgs
{
    public class XMBaseEventArgs<T> : EventArgs
    {
        public int Position { get; set; }
        public XMDataCollectionItem<T> DataItem { get; set; }
        public XMRecyclerViewAction Action { get; set; }
        public XMBaseEventArgs(int position, XMRecyclerViewAction action, XMDataCollectionItem<T> item)
        {
            Position = position;
            DataItem = item;
            Action = action;
        }
    }
}
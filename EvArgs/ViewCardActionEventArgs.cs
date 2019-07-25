using Xamabrouk.Actions;
using Xamabrouk.Entities;

namespace Xamabrouk.EvArgs
{
    public class XMViewCardActionEventArgs<T> : XMBaseEventArgs<T>
    {
        public new XMViewCardAction Action { get; set; }
        public XMViewCardActionEventArgs(int position, XMViewCardAction action, XMDataCollectionItem<T> item) : base(position, XMRecyclerViewAction.Selection, item)
        {
            Action = action;
        }
    }
}
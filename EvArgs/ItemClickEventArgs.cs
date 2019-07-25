using Xamabrouk.Entities;

namespace Xamabrouk.EvArgs
{
    public class XMItemClickEventArgs<T> : XMBaseEventArgs<T>
    {
        public XMItemClickEventArgs(int position, XMDataCollectionItem<T> item) : base(position, XMRecyclerViewAction.Selection, item)
        {

        }
    }
}
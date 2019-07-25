namespace Xamabrouk.Entities
{
    public class XMDataCollectionItem<T>
    {
        public XMDataCollectionItem()
        {
        }

        public XMDataCollectionItem(T item)
        {
            Item = item;
        }

        public XMDataCollectionItem(T item, bool isSelected, bool isExpanded) : this(item)
        {
            IsSelected = isSelected;
            IsExpanded = isExpanded;
        }

        public T Item { get; set; }
        public bool IsSelected { get; set; } = false;
        public bool IsExpanded { get; set; } = false;
    }
}
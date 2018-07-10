using System.Collections.Generic;

namespace DataTree.Common
{
  public class CollectionChangedEventArgs<T>
  {
    public readonly ICollection<T> NewItems;
    public readonly ICollection<T> RemovedItems;

    public CollectionChangedEventArgs(ICollection<T> newItems, ICollection<T> removedItems)
    {
      NewItems = newItems;
      RemovedItems = removedItems;
    }
  }
}
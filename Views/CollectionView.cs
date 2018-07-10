using System.Collections.Generic;
using UnityEngine;

namespace DataTree.Views
{
  public abstract class CollectionView : View
  {
    protected override void BindNodeToView(Node node)
    {
      if (BindRead)
      {
        CollectionUpdated(node.Children, null);
        node.ChildrenCollectionChanged += (s, e) => CollectionUpdated(e.NewItems, e.RemovedItems);
      }
    }
    
    protected abstract void CollectionUpdated(IEnumerable<Node> newItems, IEnumerable<Node> removedItems);
    
    public GameObject ItemPrefab;
  }
}
using System.Collections.Generic;
using System.Linq;
using DataTree.Example.Boxes;
using DataTree.Views;

namespace DataTree.Example.Views
{
  public class UnitsView : CollectionView
  {
    protected override void CollectionUpdated(IEnumerable<Node> newItems, IEnumerable<Node> removedItems)
    {
      if (newItems != null)
      {
        foreach (var item in newItems)
        {
          CreateGameObject(item);
        }
      }

      if (removedItems != null)
      {
        foreach (var item in removedItems)
        {
          Destroy(transform.GetComponentsInChildren<UnitBox>().FirstOrDefault(n => n.Node.Value.Name == item.Name)?.gameObject);
        }
      }
    }

    private void CreateGameObject(Node node)
    {
      var obj = Instantiate(ItemPrefab, transform);
      var box = obj.GetComponent<UnitBox>();
      box.Original = node;
      box.RecreateProjection();
    }
  }
}
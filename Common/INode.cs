namespace DataTree.Common
{
  public interface INode
  {
    event NodeDataChangedEventHandler DataChanged;
    event CollectionChangedEventHandler<Node> ChildrenCollectionChanged;
  }
}
namespace DataTree.Common
{
  public class NodeDataChangedEventArgs
  {
    public readonly object NewValue;
  
    public NodeDataChangedEventArgs(object newValue)
    {
      NewValue = newValue;
    }
  }
}

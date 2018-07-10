using DataTree.Boxes;
using DataTree.Example.MainTree;
using DataTree.Example.ProjectionProviders;

namespace DataTree.Example.Boxes
{
  public class MetaBox : ProjectionBox
  {
    protected override Node InitializeProjection()
    {
      return new MetaProjectionProvider().BuildProjection(GameData.Instance.Value);
    }
  }
}
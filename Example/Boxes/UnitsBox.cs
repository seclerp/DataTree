using DataTree.Boxes;
using DataTree.Example.MainTree;
using DataTree.Example.ProjectionProviders;

namespace DataTree.Example.Boxes
{
  public class UnitsBox : ProjectionBox
  {
    protected override Node InitializeProjection()
    {
      return new UnitsProjectionProvider().BuildProjection(GameData.Instance.Value);
    }
  }
}
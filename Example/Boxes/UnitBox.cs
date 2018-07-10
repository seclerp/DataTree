using DataTree.Boxes;
using DataTree.Example.ProjectionProviders;

namespace DataTree.Example.Boxes
{
  public class UnitBox : ProjectionBox
  {
    public Node Original { get; set; }
    
    protected override Node InitializeProjection()
    {
      return new UnitProjectionProvider().BuildProjection(Original);
    }
  }
}
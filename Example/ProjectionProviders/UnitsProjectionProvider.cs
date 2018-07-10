using DataTree.Common;

namespace DataTree.Example.ProjectionProviders
{
  public class UnitsProjectionProvider : IProjectionProvider
  {
    public virtual Node BuildProjection(Node original)
    {
      return new ProjectionBuilder("PlayerUnits", original)
        .FromNode("Units", original.GetNode("Units"), true, BindMode.Read)
        .Build();
    }
  }
}
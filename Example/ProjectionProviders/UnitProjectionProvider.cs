using DataTree.Common;

namespace DataTree.Example.ProjectionProviders
{
  public class UnitProjectionProvider : IProjectionProvider
  {
    public virtual Node BuildProjection(Node original)
    {
      if (original == null) return null;
      
      return new ProjectionBuilder(original.Name, original)
        .FromNode("Name", original.GetNode("Name"), false, BindMode.Read)
        .FromNode("Health", original.GetNode("Health"), false, BindMode.Read)
        .FromNode("Damage", original.GetNode("Damage"), false, BindMode.Read)
        .FromNode("Defence", original.GetNode("Defence"), false, BindMode.Read)
        .Build();
    }
  }
}
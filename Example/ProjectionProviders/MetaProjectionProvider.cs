using DataTree.Common;

namespace DataTree.Example.ProjectionProviders
{
  public class MetaProjectionProvider : IProjectionProvider
  {
    public virtual Node BuildProjection(Node original)
    {
      return new ProjectionBuilder("MetaProjection", original)
        .FromNode("Nickname", original.GetNode("Meta.Nickname"), false, BindMode.Read | BindMode.Write)
        .FromNode("Password", original.GetNode("Meta.Password"), false, BindMode.Read | BindMode.Write)
        .Build();
    }
  }
}
using System.Collections.Generic;

namespace DataTree
{
  public static class NodeHelper
  {
    public static Node ToNode(this object obj, string name, bool makeDeepTree = false, string dataProperty = "Data")
    {
      var resultNode = new Node(name);

      var children = new List<Node>();
      foreach (var property in obj.GetType().GetProperties())
      {
        if (property.Name == dataProperty)
        {
          resultNode.CommitData(_ => property.GetValue(obj));
          continue;
        }

        if (property.PropertyType.IsValueType || !makeDeepTree)
        {
          children.Add(new Node(property.Name, property.GetValue(obj)));
        }
        else
        {
          children.Add(property.GetValue(obj).ToNode(property.Name));
        }
      }
      
      resultNode.CommitChildren(children, null);
      return resultNode;
    }
  }
}
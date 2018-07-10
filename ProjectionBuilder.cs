using System.Collections.Generic;
using DataTree.Common;

namespace DataTree
{
  public class ProjectionBuilder : IBuilder<Node>
  {
    private List<Node> _builderResultChildren;
    private string _builderResultName;
    private Node _fromNode;
    
    public ProjectionBuilder(string newNodeName, Node fromNode)
    {
      _builderResultName = newNodeName;
      _fromNode = fromNode;
      _builderResultChildren = new List<Node>();
    }

    public ProjectionBuilder FromNode(string name, Node original, bool deepCopy, BindMode bindMode)
    {
      _builderResultChildren.Add(GetNodeCopy(name, original, deepCopy, bindMode));

      return this;
    }
    
    public Node Build()
    {
      var result = new Node(_builderResultName, _fromNode.Data);
      result.CommitChildren(_builderResultChildren, null);
      
      return result;
    }

    private Node GetNodeCopy(string name, Node original, bool deepCopy, BindMode bindMode)
    {
      var newNode = new Node(name, original.Data);
      NodeBinder.Bind(original, newNode, bindMode);
      
      if (!deepCopy)
      {
        return newNode;
      }

      CopyNodeChildrenRec(original, newNode, bindMode);

      return newNode;
    }

    private void CopyNodeChildrenRec(Node from, Node to, BindMode bindMode)
    {
      var newChildren = new List<Node>();
      
      foreach (var child in from.Children)
      {
        var newChild = new Node(child.Name, child.Data);
        NodeBinder.Bind(child, newChild, bindMode);
        
        newChildren.Add(newChild);

        CopyNodeChildrenRec(child, newChild, bindMode);
      }
      
      to.CommitChildren(newChildren, null);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using DataTree.Common;
using DataTree.Exceptions;

namespace DataTree
{
  public class Node : INode
  {
    public string Name { get; }

    private object _data;
    public object Data
    {
      get { return _data; }
      private set
      {
        if (value == null || value.Equals(_data)) return;
        
        _data = value;
      
        OnDataChanged(_data);
      }
    }

    private List<Node> _children;
    public IReadOnlyCollection<Node> Children => _children;

    public Node(string name, object data, params Node[] children)
      : this(name, data)
    {
      CommitChildren(children, null);
    }
    
    public Node(string name, params Node[] children)
      : this(name)
    {
      CommitChildren(children, null);
    }
    
    public Node(string name, object data)
      : this(name)
    {
      Data = data;
    }

    public Node(string name)
    {
      Name = name;
      _children = new List<Node>();
    }

    public Node GetNode(string path)
    {
      return GetNodeRec(this, path);
    }

    private Node GetNodeRec(Node searchFrom, string path)
    {
      if (!path.Contains('.'))
      {
        return searchFrom.Children.FirstOrDefault(c => c.Name == path);
      }

      var pathParts = path.Split('.');
      var child = Children.FirstOrDefault(c => c.Name == pathParts[0]);
      
      return GetNodeRec(child, pathParts.Skip(1).Aggregate((a, b) => $"{a}.{b}"));
    }

    public void ExecuteCommand(Action<Node> command)
    {
      command?.Invoke(this);
    }
    
    public virtual void CommitData(Func<object, object> mutation)
    {
      try
      {
        Data = mutation(Data);
      }
      catch (Exception e)
      {
        throw new MutationApplyException("Failed to apply data mutation:", e);
      }
    }
    
    public virtual void CommitChildren(ICollection<Node> added, ICollection<Node> removed)
    {
      try
      {
        if (added != null && added.Any())
        {
          _children.AddRange(added);
          
          OnChildrenCollectionChanged(added, null);
        }

        if (removed != null && removed.Any())
        {
          foreach (var node in removed)
          {
            _children.Remove(node);
          }
          
          OnChildrenCollectionChanged(null, removed);
        }
      }
      catch (Exception e)
      {
        throw new MutationApplyException("Failed to apply collection mutation:", e);
      }
    }
    
    #region INode Implementation

    public event CollectionChangedEventHandler<Node> ChildrenCollectionChanged;
    public event NodeDataChangedEventHandler DataChanged;

    protected void OnChildrenCollectionChanged(ICollection<Node> added, ICollection<Node> removed)
    {
      ChildrenCollectionChanged?.Invoke(this, 
        new CollectionChangedEventArgs<Node>(
          added, removed
        )
      );
    }
    
    protected void OnDataChanged(object newValue)
    {
      DataChanged?.Invoke(this, new NodeDataChangedEventArgs(newValue));
    }

    #endregion
  }
}
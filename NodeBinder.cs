using System;
using System.Collections.Generic;
using DataTree.Common;

namespace DataTree
{
  public static class NodeBinder
  {
    public static void Bind(Node from, Node to, BindMode mode)
    {
      if (mode.HasFlag(BindMode.Read))
      {
        from.DataChanged += (sender, args) => to.CommitData(node => args.NewValue);
        from.ChildrenCollectionChanged += (sender, args) => to.CommitChildren(args.NewItems, args.RemovedItems);
      }
      
      if (mode.HasFlag(BindMode.Write))
      {
        to.DataChanged += (sender, args) => from.CommitData(node => args.NewValue);
        to.ChildrenCollectionChanged += (sender, args) => from.CommitChildren(args.NewItems, args.RemovedItems);
      }
    }

    public static void BindMany(IDictionary<string, Node> from, Node to, Action<IDictionary<string, Node>, Node> binder)
    {
      foreach (var node in from)
      {
        node.Value.DataChanged += (sender, args) => binder(from, to);
      }
    }
  }
}
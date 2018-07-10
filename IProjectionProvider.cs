using UnityEngine;

namespace DataTree
{
  public interface IProjectionProvider
  {
    Node BuildProjection(Node original);
  }
}
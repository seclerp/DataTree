using DataTree.Boxes;
using UnityEngine;

namespace DataTree.Views
{
  public abstract class View : MonoBehaviour
  {
    public bool BindRead;
    public bool BindWrite;

    public ProjectionBox Box;
    
    public string NodePath;
    
    private Node _sourceNode;

    protected virtual void Start()
    {
      _sourceNode = Box.Node.Value.GetNode(NodePath);

      BindNodeToView(_sourceNode);
    }

    protected abstract void BindNodeToView(Node node);
  }
}
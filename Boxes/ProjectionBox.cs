using System;
using UnityEngine;

namespace DataTree.Boxes
{
  public abstract class ProjectionBox : MonoBehaviour
  {
    public Lazy<Node> Node { get; set; }
    
    private void Awake()
    {
      RecreateProjection();
    }

    public void RecreateProjection()
    {
      Node = new Lazy<Node>(InitializeProjection);
    }
    
    protected abstract Node InitializeProjection();
  }
}
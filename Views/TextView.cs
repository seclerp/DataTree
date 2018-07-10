using UnityEngine;
using UnityEngine.UI;

namespace DataTree.Views
{
  [RequireComponent(typeof(Text))]
  public class TextView : View
  {
    protected override void BindNodeToView(Node node)
    {
      var text = GetComponent<Text>();
      
      // Read
      if (BindRead)
      {
        text.text = node.Data.ToString();
        node.DataChanged += (s, e) => text.text = e.NewValue.ToString();
      }
      
      // Write
      if (BindWrite)
      {
        return;
      }
    }
  }
}
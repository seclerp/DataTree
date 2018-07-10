using UnityEngine;
using UnityEngine.UI;

namespace DataTree.Views
{
  [RequireComponent(typeof(InputField))]
  public class InputFieldView : View
  {
    protected override void BindNodeToView(Node node)
    {
      var inputField = GetComponent<InputField>();
      
      if (BindRead)
      {
        inputField.text = node.Data.ToString();
        node.DataChanged += (sender, args) => inputField.text = args.NewValue.ToString();
      }
      
      if (BindWrite)
      {
        inputField.onValueChanged.AddListener(value => node.CommitData(_ => value));
      }
    }
  }
}
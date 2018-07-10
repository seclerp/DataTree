using System;

namespace DataTree.Exceptions
{
  public class MutationApplyException : Exception
  {
    public MutationApplyException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
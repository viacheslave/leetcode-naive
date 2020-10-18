using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive
{
  public class NodeChildren
  {
    public int val;
    public IList<NodeChildren> children;

    public NodeChildren() {   }
    public NodeChildren(int _val, IList<NodeChildren> _children)
    {
      val = _val;
      children = _children;
    }
  }
}

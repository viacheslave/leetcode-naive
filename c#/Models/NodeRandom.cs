using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive
{
  public class NodeRandom
  {
    public int val;
    public NodeRandom next;
    public NodeRandom random;

    public NodeRandom() {   }
    public NodeRandom(int _val, NodeRandom _next, NodeRandom _random)
    {
      val = _val;
      next = _next;
      random = _random;
    }
  }
}

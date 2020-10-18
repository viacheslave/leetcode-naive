using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive
{
  public class NodeNeighbors
  {
    public int val;
    public IList<NodeNeighbors> neighbors;

    public NodeNeighbors() {   }
    public NodeNeighbors(int _val, IList<NodeNeighbors> _neighbors)
    {
      val = _val;
      neighbors = _neighbors;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/clone-graph/
  ///    Submission: https://leetcode.com/submissions/detail/241432773/
  /// </summary>
  internal class P0133
  {
    public class Solution
    {
      public NodeNeighbors CloneGraph(NodeNeighbors node)
      {
        var map = new Dictionary<NodeNeighbors, NodeNeighbors>();
        map[node] = new NodeNeighbors(node.val, new List<NodeNeighbors>());

        var queue = new Queue<NodeNeighbors>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();

          foreach (var nb in item.neighbors)
          {
            if (!map.TryGetValue(nb, out var nbb))
            {
              nbb = new NodeNeighbors(nb.val, new List<NodeNeighbors>());
              map[nb] = nbb;
              queue.Enqueue(nb);
            }

            map[item].neighbors.Add(nbb);
          }
        }

        return map[node];
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/241020393/
  /// </summary>
  internal class P0103
  {
    public class Solution
    {
      public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
      {
        var map = new SortedDictionary<int, List<int>>();

        Traverse(root, map, 0);

        var result = new List<IList<int>>();

        foreach (var mapItem in map)
        {
          if (mapItem.Key % 2 == 1)
            mapItem.Value.Reverse();

          result.Add(mapItem.Value);
        }

        return result;
      }

      private void Traverse(TreeNode node, SortedDictionary<int, List<int>> map, int level)
      {
        if (node == null)
          return;

        Traverse(node.left, map, level + 1);

        if (!map.ContainsKey(level))
          map[level] = new List<int>();

        map[level].Add(node.val);

        Traverse(node.right, map, level + 1);
      }
    }
  }
}

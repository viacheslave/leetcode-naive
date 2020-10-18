using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-completeness-of-a-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/282933270/
  /// </summary>
  internal class P0958
  {
    public class Solution
    {
      public bool IsCompleteTree(TreeNode root)
      {
        var map = new SortedDictionary<int, List<(TreeNode, int)>>();
        Traverse(root, (null, 0), map, -1, 0);

        var maxLevel = map.Keys.Max();

        foreach (var kvp in map)
        {
          if (kvp.Value.Count == (int)Math.Pow(2, kvp.Key))
            continue;

          if (kvp.Key != maxLevel)
            return false;

          for (int i = 0; i < kvp.Value.Count; i++)
          {
            if (kvp.Value[i].Item2 != i)
              return false;
          }
        }

        return true;
      }

      private void Traverse(TreeNode node,
                            (TreeNode, int) parent,
                            SortedDictionary<int, List<(TreeNode, int)>> map, int pos, int level)
      {
        if (!map.ContainsKey(level))
          map[level] = new List<(TreeNode, int)>();

        var nodeValue = (parent.Item2 * 2) + (pos == 1 ? 1 : 0);
        var nodeItem = (node, nodeValue);

        map[level].Add(nodeItem);

        if (node.left != null)
          Traverse(node.left, nodeItem, map, -1, level + 1);
        if (node.right != null)
          Traverse(node.right, nodeItem, map, 1, level + 1);
      }
    }
  }
}

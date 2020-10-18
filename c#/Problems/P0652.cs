using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-duplicate-subtrees/
  ///    Submission: https://leetcode.com/submissions/detail/312359967/
  /// </summary>
  internal class P0652
  {
    public class Solution
    {
      public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
      {
        var map = new Dictionary<string, List<TreeNode>>();
        Traverse(root, map);

        return map.Where(v => v.Value.Count > 1).Select(v => v.Value[0]).ToList();
      }

      private string Traverse(TreeNode node, Dictionary<string, List<TreeNode>> map)
      {
        if (node == null)
          return "";

        var left = Traverse(node.left, map);
        var right = Traverse(node.right, map);

        var value = node.val.ToString();
        if (left != null) value += $"l{left}";
        if (right != null) value += $"r{right}";

        if (!map.ContainsKey(value))
          map[value] = new List<TreeNode>();

        map[value].Add(node);

        return value;
      }
    }
  }
}

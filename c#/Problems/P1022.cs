using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/234772784/
  /// </summary>
  internal class P1022
  {
    public class Solution
    {
      public int SumRootToLeaf(TreeNode root)
      {
        var sums = new List<string>();
        var sb = new StringBuilder();

        Grab(root, sums, sb);

        return sums.Select(ToNumber).Sum();
      }

      void Grab(TreeNode node, List<string> res, StringBuilder sb)
      {
        if (node == null)
          return;

        sb.Append(node.val.ToString());

        if (node.left == null && node.right == null)
          res.Add(sb.ToString());

        Grab(node.left, res, sb);
        Grab(node.right, res, sb);

        sb.Remove(sb.Length - 1, 1);
      }

      int ToNumber(string n)
      {
        var res = 0;

        for (var i = n.Length - 1; i >= 0; i--)
        {
          var ch = n[i];
          if (ch == '1')
            res += (int)Math.Pow(2, n.Length - 1 - i);
        }

        return res;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/construct-string-from-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/230646632/
  /// </summary>
  internal class P0606
  {
    public class Solution
    {
      public string Tree2str(TreeNode t)
      {
        if (t == null)
          return "";

        var sb = new StringBuilder();

        Constr(t, sb);

        return sb.ToString();
      }

      void Constr(TreeNode t, StringBuilder sb)
      {
        if (t == null)
        {
          //sb.Append("()");
          return;
        }

        sb.Append(t.val.ToString());

        if (t.left == null && t.right == null)
          return;

        if (t.left == null)
        {
          sb.Append("()");
        }
        else
        {
          sb.Append("(");
          Constr(t.left, sb);
          sb.Append(")");
        }

        if (t.right != null)
        {
          sb.Append("(");
          Constr(t.right, sb);
          sb.Append(")");
        }
      }
    }
  }
}

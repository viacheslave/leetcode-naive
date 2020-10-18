using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-of-smaller-numbers-after-self/
  ///    Submission: https://leetcode.com/submissions/detail/243879621/
  /// </summary>
  internal class P0315
  {
    public class Solution
    {
      public IList<int> CountSmaller(int[] nums)
      {
        if (nums.Length == 0)
          return new List<int>();

        var ans = new List<int>() { 0 };
        var root = new No(nums[nums.Length - 1], 1);

        for (int i = nums.Length - 2; i >= 0; i--)
        {
          CheckWith(root, null, nums[i], ans, 0, 0);
        }

        ans.Reverse();
        return ans;
      }

      private void CheckWith(No node, No parent, int value, List<int> ans, int side, int count)
      {
        if (node == null)
        {
          ans.Add(count);

          if (parent != null)
          {
            if (side == 0)
              parent.left = new No(value, 1);
            else
              parent.right = new No(value, 1);
          }

          return;
        }

        if (node.val.Item1 == value)
        {
          ans.Add(count + (node.left != null ? node.left.val.Item2 : 0));
          node.val = (node.val.Item1, node.val.Item2 + 1);
          return;
        }

        if (value < node.val.Item1)
          CheckWith(node.left, node, value, ans, 0, count);

        if (value > node.val.Item1)
          CheckWith(node.right, node, value, ans, 1, count + node.val.Item2 - (node.right != null ? node.right.val.Item2 : 0));

        node.val = (node.val.Item1, node.val.Item2 + 1);
      }

      public class No
      {
        public (int, int) val;
        public No left;
        public No right;
        public No(int x, int count) { val = (x, count); }
      }
    }
  }
}

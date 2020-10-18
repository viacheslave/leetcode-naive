using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/
  ///    Submission: https://leetcode.com/submissions/detail/227428820/
  /// </summary>
  internal class P0109
  {
    public class Solution
    {
      public TreeNode SortedListToBST(ListNode head)
      {

        if (head == null)
          return null;

        var list = new List<int>() { head.val };

        var current = head.next;
        while (current != null)
        {
          list.Add(current.val);
          current = current.next;
        }

        return SortedArrayToBST(list.ToArray());
      }

      public TreeNode SortedArrayToBST(int[] nums)
      {
        if (nums.Length == 0)
          return null;

        if (nums.Length == 1)
          return new TreeNode(nums[0]);

        return Fill(nums, 0, nums.Length - 1);
        ;
      }

      private TreeNode Fill(int[] nums, int start, int end)
      {
        var middle = (end + start) / 2;
        var node = new TreeNode(nums[middle]);

        if (start == end)
          return node;

        if (start != middle)
          node.left = Fill(nums, start, middle - 1);

        if (middle != end)
          node.right = Fill(nums, middle + 1, end);


        return node;
      }
    }
  }
}

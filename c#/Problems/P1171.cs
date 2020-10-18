using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/255332504/
  /// </summary>
  internal class P1171
  {
    public class Solution
    {
      public ListNode RemoveZeroSumSublists(ListNode head)
      {
        var arr = new List<int>();
        while (head != null)
        {
          arr.Add(head.val);
          head = head.next;
        }

        while (true)
        {
          var sums = new int[arr.Count + 1];
          sums[0] = 0;

          for (int i = 0; i < arr.Count; i++)
            sums[i + 1] = sums[i] + arr[i];

          var result = Delete(arr, sums);
          if (!result)
            break;
        }

        return Build(arr);
      }

      private static bool Delete(List<int> arr, int[] sums)
      {
        for (int start = 0; start < sums.Length - 1; start++)
        {
          for (int end = start + 1; end < sums.Length; end++)
          {
            if (sums[start] == sums[end])
            {
              for (int pos = end - 1; pos >= start; pos--)
                arr.RemoveAt(pos);

              return true;
            }
          }
        }

        return false;
      }

      private ListNode Build(List<int> arr)
      {
        if (arr.Count == 0)
          return null;

        var head = new ListNode(arr[0]);
        var current = head;

        for (int i = 1; i < arr.Count; i++)
        {
          var node = new ListNode(arr[i]);
          current.next = node;
          current = node;
        }

        return head;
      }
    }
  }
}

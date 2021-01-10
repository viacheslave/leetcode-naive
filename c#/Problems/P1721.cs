using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/swapping-nodes-in-a-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/441131898/
  /// </summary>
  internal class P1721
  {
    public class Solution
    {
      public ListNode SwapNodes(ListNode head, int k)
      {
        var arr = new List<ListNode>();

        var current = head;
        while (current != null)
        {
          arr.Add(current);
          current = current.next;
        }

        if (arr.Count == 1)
          return head;

        if (arr.Count == 2)
        {
          arr[1].next = arr[0];
          arr[0].next = null;
          return arr[1];
        }

        var i1 = k - 1;
        var i2 = arr.Count - k;

        if (i1 == i2)
          return head;

        var ord = new[] { i1, i2 };
        Array.Sort(ord);

        i1 = ord[0];
        i2 = ord[1];

        // [n-1, n]
        if (Math.Abs(i2 - i1) == 1)
        {
          var prev = arr[i1 - 1];
          var next = arr[i2 + 1];

          prev.next = arr[i2];
          prev.next.next = arr[i1];
          prev.next.next.next = next;

          return head;
        }

        // [0, n]
        if (i1 == 0)
        {
          var next = arr[1];
          var prev = arr[^2];

          arr[i2].next = next;
          prev.next = arr[i1];
          prev.next.next = null;

          return arr[i2];
        }

        var p1 = arr[i1 - 1];
        var n1 = arr[i1 + 1];
        var p2 = arr[i2 - 1];
        var n2 = arr[i2 + 1];

        p1.next = arr[i2];
        arr[i2].next = n1;

        p2.next = arr[i1];
        arr[i1].next = n2;

        return head;
      }
    }
  }
}

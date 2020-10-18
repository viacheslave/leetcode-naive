using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reverse-linked-list-ii/
  ///    Submission: https://leetcode.com/submissions/detail/232032386/
  /// </summary>
  internal class P0092
  {
    public class Solution
    {
      public ListNode ReverseBetween(ListNode head, int m, int n)
      {
        if (m == n)
          return head;

        var current = head;
        var index = 0;
        var pivot = head;
        ListNode pivotprev = null;
        ListNode currentprev = null;

        while (current != null)
        {
          index++;

          if (index == m - 1 && index > 0)
            pivotprev = current;

          if (index == m)
            pivot = current;

          if (m < index && index <= n)
          {
            var next = current.next;
            current.next = pivot;
            if (pivotprev != null)
              pivotprev.next = current;
            //else head = pivot;

            currentprev.next = next;

            // 
            pivot = current;
            current = currentprev;

            if (pivotprev == null) head = pivot;
          }

          currentprev = current;
          current = current.next;
        }

        return head;
      }
    }
  }
}

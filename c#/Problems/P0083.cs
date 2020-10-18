using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-duplicates-from-sorted-list/
  ///    Submission: https://leetcode.com/submissions/detail/226655066/
  /// </summary>
  internal class P0083
  {
    public class Solution
    {
      public ListNode DeleteDuplicates(ListNode head)
      {
        var current = head;

        while (current != null)
        {
          if (current.next == null)
            break;

          while (current.next != null && current.next.val == current.val)
            current.next = current.next.next;

          current = current.next;
        }

        return head;
      }
    }
  }
}

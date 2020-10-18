using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-linked-list-elements/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/227384775/
  /// </summary>
  internal class P0203
  {
    public class Solution
    {
      public ListNode RemoveElements(ListNode head, int val)
      {
        if (head == null)
          return null;

        while (head.val == val)
        {
          head = head.next;
          if (head == null)
            return null;
        }

        var current = head;

        while (current.next != null)
        {
          if (current.next.val == val)
          {
            if (current.next.next != null)
              current.next = current.next.next;
            else
              current.next = null;
          }
          else
          {
            current = current.next;
          }
        }

        return head;
      }
    }
  }
}

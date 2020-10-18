using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/229707083/
  /// </summary>
  internal class P0234
  {
    public class Solution
    {
      public bool IsPalindrome(ListNode head)
      {
        if (head == null)
          return true;

        if (head.next == null)
          return true;

        var stack = new Stack<ListNode>();
        var index = 0;

        var current = head;
        var mid = head;

        while (current != null)
        {
          index++;

          if (index % 2 == 0)
          {
            stack.Push(mid);
            mid = mid.next;
          }

          current = current.next;
        }

        var currentRight = index % 2 == 0 ? stack.Peek().next : stack.Peek().next.next;
        var currentLeft = stack.Pop();

        while (currentRight != null)
        {
          if (currentLeft.val != currentRight.val)
            return false;

          currentLeft = stack.Count > 0 ? stack.Pop() : null;
          currentRight = currentRight.next;
        }

        return true;
      }
    }
  }
}

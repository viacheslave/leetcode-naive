using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/intersection-of-two-linked-lists/
  ///    Submission: https://leetcode.com/submissions/detail/229141216/
  /// </summary>
  internal class P0160
  {
    public class Solution
    {
      public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
      {
        if (headA == null || headB == null)
          return null;

        var ac = headA;
        var ret = ac.next;

        while (ac != null)
        {
          ret = ac.next;
          ac.next = headB;

          var bCurrent = headB;
          while (bCurrent != null)
          {
            if (bCurrent == ac || bCurrent == ret)
            {
              ac.next = ret;
              return bCurrent;
            }

            bCurrent = bCurrent.next;

          }

          ac.next = ret;

          ac = ac.next;
        }

        return null;
      }
    }
  }
}

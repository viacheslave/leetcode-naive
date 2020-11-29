using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/merge-in-between-linked-lists/
  ///    Submission: https://leetcode.com/submissions/detail/425437739/
  /// </summary>
  internal class P1669
  {
    public class Solution
    {
      public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
      {
        ListNode first = null;
        ListNode last = null;

        ListNode parent = null;
        var current = list1;
        var index = 0;

        while (last == null)
        {
          if (index == a)
          {
            first = parent;
          }

          if (index == b)
          {
            last = current.next;
          }

          index++;

          parent = current;
          current = current.next;
        }

        if (first == null && last == null)
          return list2;

        if (first == null)
        {
          var cf = list2;
          while (cf.next != null)
            cf = cf.next;

          cf.next = last;
          return list2;
        }

        if (last == null)
        {
          first.next = list2;
          return list1;
        }

        first.next = list2;

        var c = list2;
        while (c.next != null)
          c = c.next;

        c.next = last;
        return list1;
      }
    }
  }
}

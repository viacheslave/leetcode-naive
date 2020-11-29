using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-front-middle-back-queue/
  ///    Submission: https://leetcode.com/submissions/detail/425433683/
  /// </summary>
  internal class P1670
  {
    public class FrontMiddleBackQueue
    {
      private readonly LinkedList<int> left = new LinkedList<int>();
      private readonly LinkedList<int> right = new LinkedList<int>();

      public FrontMiddleBackQueue()
      {
      }

      public void PushFront(int val)
      {
        left.AddLast(val);
        Rebalance();
      }

      public void PushMiddle(int val)
      {
        if (right.Count > left.Count)
          left.AddFirst(val);

        else
          right.AddFirst(val);
      }

      public void PushBack(int val)
      {
        right.AddLast(val);
        Rebalance();
      }

      public int PopFront()
      {
        if (left.Count == 0 && right.Count == 0)
          return -1;

        if (left.Count == 0 && right.Count > 0)
        {
          var l = right.First;
          right.RemoveFirst();

          return l.Value;
        }

        var pop = left.Last;
        left.RemoveLast();

        Rebalance();

        return pop.Value;
      }

      public int PopMiddle()
      {
        if (left.Count == 0 && right.Count == 0)
          return -1;

        if (left.Count == right.Count)
        {
          var pop = left.First;
          left.RemoveFirst();

          return pop.Value;
        }

        if (left.Count < right.Count)
        {
          var pop1 = right.First;
          right.RemoveFirst();

          return pop1.Value;
        }

        return -1;
      }

      public int PopBack()
      {
        if (right.Count == 0)
          return -1;

        var pop = right.Last;
        right.RemoveLast();

        Rebalance();

        return pop.Value;
      }

      private void Rebalance()
      {
        if (right.Count > left.Count + 1)
        {
          while (right.Count > left.Count + 1)
          {
            var pop = right.First;
            right.RemoveFirst();

            left.AddFirst(pop.Value);
          }
        }

        if (left.Count > right.Count)
        {
          while (left.Count > right.Count)
          {
            var pop = left.First;
            left.RemoveFirst();

            right.AddFirst(pop.Value);
          }
        }
      }
    }
  }
}

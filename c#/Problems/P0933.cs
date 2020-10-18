using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-recent-calls/
  ///    Submission: https://leetcode.com/submissions/detail/231709941/
  /// </summary>
  internal class P0933
  {
    public class RecentCounter
    {
      LinkedList<int> exp = new LinkedList<int>();

      public RecentCounter()
      {
      }

      public int Ping(int t)
      {
        return Add(t);
      }

      int Add(int value)
      {
        var expirationValue = value + 3000;

        if (exp.First == null || expirationValue <= exp.First.Value)
        {
          exp.AddFirst(expirationValue);
          return 1;
        }

        var current = exp.First;
        while (current != null)
        {
          if (expirationValue == current.Value)
          {
            exp.AddBefore(current, expirationValue);
            return exp.Count;
          }

          if (expirationValue < current.Value)
          {
            exp.AddAfter(current.Previous, expirationValue);
            return exp.Count;
          }

          var tmpCurrent = current;
          current = current.Next;

          if (tmpCurrent.Value < value)
            exp.RemoveFirst();
        }

        if (exp.Last == null)
        {
          exp.AddFirst(expirationValue);
        }
        else
        {
          exp.AddAfter(exp.Last, expirationValue);
        }

        return exp.Count;
      }
    }
  }
}

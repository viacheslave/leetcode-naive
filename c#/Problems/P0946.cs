using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/validate-stack-sequences/
  ///    Submission: https://leetcode.com/submissions/detail/238071858/
  /// </summary>
  internal class P0946
  {
    public class Solution
    {
      public bool ValidateStackSequences(int[] pushed, int[] popped)
      {
        Stack<int> s = new Stack<int>();

        var pu = 0;
        var po = 0;

        while (po < popped.Length)
        {
          if (s.Count == 0 || s.Peek() != popped[po])
          {
            if (pu >= pushed.Length)
              return false;

            s.Push(pushed[pu]);
            pu++;
            continue;
          }

          if (po >= popped.Length)
            return false;

          if (s.Peek() == popped[po])
          {
            s.Pop();
            po++;
          }
        }

        return true;
      }
    }
  }
}

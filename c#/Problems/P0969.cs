using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/pancake-sorting/
  ///    Submission: https://leetcode.com/submissions/detail/243597647/
  /// </summary>
  internal class P0969
  {
    public class Solution
    {
      public IList<int> PancakeSort(int[] A)
      {
        var list = A.ToList();
        var flips = new List<int>();

        for (var i = A.Length; i >= 1; i--)
        {
          if (A[i - 1] == i)
            continue;

          var index = Array.FindLastIndex(A, _ => _ == i);
          if (index != 0)
          {
            flips.Add(index + 1);
            Flip(A, index);
          }

          flips.Add(i);
          Flip(A, i - 1);
        }

        return flips;
      }

      private void Flip(int[] A, int index)
      {
        var list = new List<int>();
        for (var i = index; i >= 0; i--)
          list.Add(A[i]);

        for (var i = 0; i < list.Count; i++)
          A[i] = list[i];
      }
    }
  }
}

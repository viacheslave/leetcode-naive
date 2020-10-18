using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/make-two-arrays-equal-by-reversing-sub-arrays/
  ///    Submission: https://leetcode.com/submissions/detail/387708790/
  /// </summary>
  internal class P1460
  {
    public class Solution
    {
      public bool CanBeEqual(int[] target, int[] arr)
      {
        Array.Sort(target);
        Array.Sort(arr);

        for (var i = 0; i < target.Length; i++)
          if (target[i] != arr[i])
            return false;

        return true;
      }
    }
  }
}

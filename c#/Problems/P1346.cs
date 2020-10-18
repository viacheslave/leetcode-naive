using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-n-and-its-double-exist/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/301636168/
  /// </summary>
  internal class P1346
  {
    public class Solution
    {
      public bool CheckIfExist(int[] arr)
      {
        for (var i = 0; i < arr.Length; i++)
        {
          for (var j = 0; j < arr.Length; j++)
          {
            if (i == j) continue;

            if (arr[i] * 2 == arr[j])
              return true;
          }
        }
        return false;
      }
    }
  }
}

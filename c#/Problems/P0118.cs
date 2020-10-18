using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/pascals-triangle/
  ///    Submission: https://leetcode.com/submissions/detail/226654029/
  /// </summary>
  internal class P0118
  {
    public class Solution
    {
      public IList<IList<int>> Generate(int numRows)
      {
        List<IList<int>> result = new List<IList<int>>();

        for (var i = 0; i < numRows; i++)
        {
          List<int> arr = new List<int>() { 1 };

          for (var j = 1; j < i + 1; j++)
          {
            var left = result[i - 1][j - 1];
            var right = result[i - 1].Count > j ? result[i - 1][j] : 0;

            arr.Add(left + right);
          }

          result.Add(arr);
        }

        return result;
      }
    }
  }
}

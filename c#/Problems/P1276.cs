using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-burgers-with-no-waste-of-ingredients/
  ///    Submission: https://leetcode.com/submissions/detail/283185025/
  /// </summary>
  internal class P1276
  {
    public class Solution
    {
      public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
      {
        var b = (cheeseSlices * 4 - tomatoSlices) * 0.5;
        var a = cheeseSlices - b;

        if (Math.Abs(b - Convert.ToInt32(b)) > 0)
          return new List<int>();

        if (b < 0 || a < 0)
          return new List<int>();

        return new List<int>() { Convert.ToInt32(a), Convert.ToInt32(b) };
      }
    }
  }
}

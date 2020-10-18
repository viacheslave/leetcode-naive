using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/fizz-buzz/
  ///    Submission: https://leetcode.com/submissions/detail/227848053/
  /// </summary>
  internal class P0412
  {
    public class Solution
    {
      public IList<string> FizzBuzz(int n)
      {
        var list = new List<string>(n);

        for (var i = 1; i <= n; i++)
        {
          if (i % 15 == 0)
            list.Add("FizzBuzz");
          else if (i % 5 == 0)
            list.Add("Buzz");
          else if (i % 3 == 0)
            list.Add("Fizz");
          else
            list.Add(i.ToString());
        }

        return list;
      }
    }
  }
}

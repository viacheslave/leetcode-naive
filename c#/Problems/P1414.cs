using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-the-minimum-number-of-fibonacci-numbers-whose-sum-is-k/
	///		Submission: https://leetcode.com/submissions/detail/327721707/
	/// </summary>
	internal class P1414
	{
    public int FindMinFibonacciNumbers(int k)
    {
      var fibs = new List<int> { 1, 1 };

      while (true)
      {
        try
        {
          checked
          {
            fibs.Add(fibs[fibs.Count - 1] + fibs[fibs.Count - 2]);
          }
        }
        catch
        {
          break;
        }
      }

      var ans = 0;
      var sum = k;
      var index = fibs.Count - 1;

      while (sum != 0)
      {
        while (sum < fibs[index])
          index--;

        sum -= fibs[index];
        ans++;
      }

      return ans;
    }
  }
}

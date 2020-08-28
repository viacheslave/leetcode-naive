using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/kth-missing-positive-number/
	///		Submission: https://leetcode.com/submissions/detail/387684524/
	/// </summary>
	internal class P1539
	{
    public int FindKthPositive(int[] arr, int k)
    {
      var missing = new List<int>();

      var current = 1;

      for (int i = 0; i < arr.Length; i++)
      {
        while (arr[i] != current)
        {
          missing.Add(current);
          if (missing.Count == k)
            return current;

          current++;
        }

        current++;
      }

      while (true)
      {
        missing.Add(current);
        if (missing.Count == k)
          return current;

        current++;
      }

      return -1;
    }
  }
}

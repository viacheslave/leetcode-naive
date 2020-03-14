using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sum-of-mutated-array-closest-to-target/
	///		Submission: https://leetcode.com/submissions/detail/299316841/
	/// </summary>
	internal class P1300
	{
    public int FindBestValue(int[] arr, int target)
    {
      if (arr.Sum() <= target)
        return arr.Max();

      var min = 0;
      var max = arr.Max();

      Array.Sort(arr);

      var dist = new SortedDictionary<int, int>();
      while (true)
      {
        if (max - min == 1)
        {
          dist[min] = GetSum(arr, min);
          dist[max] = GetSum(arr, max);
          break;
        }

        var pick = (max + min) / 2;
        int sum = GetSum(arr, pick);

        if (sum == target)
          return pick;

        if (sum < target)
          min = pick;
        else
          max = pick;

        dist[pick] = sum;
      }

      var mindist = dist.Min(x => Math.Abs(x.Value - target));
      var ans = dist.Where(d => Math.Abs(d.Value - target) == mindist).Select(d => d.Key).Min();

      return ans;
    }

    private static int GetSum(int[] arr, int pick)
    {
      var sum = 0;
      for (var i = 0; i < arr.Length; i++)
        if (arr[i] <= pick)
          sum += arr[i];
        else
          sum += pick;
      return sum;
    }
  }
}

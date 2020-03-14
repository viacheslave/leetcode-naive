using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-absolute-difference/
	///		Submission: https://leetcode.com/submissions/detail/263165693/
	/// </summary>
	internal class P1200
	{
		public IList<IList<int>> MinimumAbsDifference(int[] arr)
		{
			Array.Sort(arr);
			var ans = new List<IList<int>>();

			var temp = new SortedDictionary<int, List<int>>();
			for (int i = 0; i < arr.Length - 1; i++)
			{
				var diff = arr[i + 1] - arr[i];
				if (!temp.ContainsKey(diff))
					temp[diff] = new List<int>();

				temp[diff].Add(i);
			}

			var indicies = temp.First().Value;
			foreach (var ind in indicies)
			{
				ans.Add(new List<int>() { arr[ind], arr[ind + 1] });
			}

			return ans;
		}
	}
}

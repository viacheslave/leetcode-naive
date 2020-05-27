using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/two-city-scheduling/
	///		Submission: https://leetcode.com/submissions/detail/246775123/
	/// </summary>
	internal class P1029
	{
		public int TwoCitySchedCost(int[][] costs)
		{
			var costsList = costs.OrderBy(_ => _[0] - _[1]).ToList();
			return costsList.Take(costs.Length / 2).Sum(_ => _[0])
					+ costsList.Skip(costs.Length / 2).Take(costs.Length / 2).Sum(_ => _[1]);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/destination-city/
	///		Submission: https://leetcode.com/submissions/detail/333774371/
	/// </summary>
	internal class P1436
	{
		public string DestCity(IList<IList<string>> paths)
		{
			var dests = paths.Select(p => p[1]).Distinct();
			var starts = paths.Select(p => p[0]).Distinct();

			return dests.First(value => !starts.Contains(value));
		}
	}
}

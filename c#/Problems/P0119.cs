using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/pascals-triangle-ii/
	///		Submission: https://leetcode.com/submissions/detail/226740560/
	/// </summary>
	internal class P0119
	{
		public IList<int> GetRow(int rowIndex)
		{
			List<IList<int>> result = new List<IList<int>>();

			for (var i = 0; i <= rowIndex; i++)
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

			return result[result.Count - 1];
		}
	}
}

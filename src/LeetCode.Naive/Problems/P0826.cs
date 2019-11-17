using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/most-profit-assigning-work/
	///		Submission: https://leetcode.com/submissions/detail/245917781/
	/// </summary>
	internal class P0826
	{
		public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
		{
			Array.Sort(worker);

			var maxProfit = 0;

			var tuples = new List<(int, int)>();
			for (int i = 0; i < difficulty.Length; i++)
				tuples.Add((difficulty[i], profit[i]));

			var currentMaxProfit = 0;
			tuples = tuples.OrderBy(_ => _.Item1).ToList();

			var sd = new SortedList<int, int>();
			for (int i = 0; i < tuples.Count; i++)
			{
				currentMaxProfit = Math.Max(currentMaxProfit, tuples[i].Item2);
				sd[tuples[i].Item1] = currentMaxProfit;
			}

			int sdKeyPos = sd.Count - 1;

			for (int i = worker.Length - 1; i >= 0; i--)
			{
				var workerDifficulty = worker[i];

				while (sdKeyPos >= 0 && sd.Keys[sdKeyPos] > workerDifficulty)
					sdKeyPos--;

				if (sdKeyPos >= 0)
					maxProfit += sd[sd.Keys[sdKeyPos]];
				else
					break;
			}

			return maxProfit;
		}
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/combination-sum/
	///		Submission: https://leetcode.com/submissions/detail/236867564/
	/// </summary>
	internal class P0039
	{
		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			var cand = candidates.Where(_ => _ <= target).OrderBy(_ => _).ToList();
			var arrIndex = new List<int>(cand.Count);
			var res = new List<IList<int>>();

			Comb(cand, arrIndex, res, target, 0);

			return res;
		}

		private void Comb(List<int> cand, List<int> arrIndex, List<IList<int>> res, int target, int v)
		{
			for (var i = v; i < cand.Count; i++)
			{
				arrIndex.Add(i);

				var sum = Sum(cand, arrIndex);

				if (sum > target)
				{
					arrIndex.RemoveAt(arrIndex.Count - 1);
					break;
				}

				if (sum == target)
				{
					var r = new List<int>();
					foreach (var index in arrIndex)
						r.Add(cand[index]);

					res.Add(r);
					arrIndex.RemoveAt(arrIndex.Count - 1);
					break;
				}

				Comb(cand, arrIndex, res, target, i);

				arrIndex.RemoveAt(arrIndex.Count - 1);
			}
		}

		private int Sum(List<int> cand, List<int> arrIndex)
		{
			var sum = 0;
			foreach (var index in arrIndex)
				sum += cand[index];
			return sum;
		}
	}
}

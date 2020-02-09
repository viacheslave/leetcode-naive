using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-interval/
	///		Submission: https://leetcode.com/submissions/detail/282744315/
	/// </summary>
	internal class P1272
	{
		public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
		{
			var inlist = intervals.Select(_ => new List<int> { _[0], _[1] }).ToList();

			var ri = new List<int>();

			for (int i = 0; i < inlist.Count; i++)
			{
				if (toBeRemoved[0] >= inlist[i][1])
					continue;

				if (toBeRemoved[1] <= inlist[i][0])
					break;

				// interval is inside
				if (toBeRemoved[0] <= inlist[i][0] && inlist[i][1] <= toBeRemoved[1])
				{
					ri.Add(i);
					continue;
				}

				if (inlist[i][0] == toBeRemoved[0] && toBeRemoved[1] < inlist[i][1])
				{
					inlist[i][0] = toBeRemoved[1];
					continue;
				}

				if (inlist[i][0] < toBeRemoved[0] && toBeRemoved[1] == inlist[i][1])
				{
					inlist[i][1] = toBeRemoved[0];
					continue;
				}

				if (inlist[i][0] < toBeRemoved[0] && toBeRemoved[1] < inlist[i][1])
				{
					inlist[i].Insert(1, toBeRemoved[0]);
					inlist[i].Insert(2, toBeRemoved[1]);
					continue;
				}

				if (toBeRemoved[0] < inlist[i][1] && inlist[i][1] < toBeRemoved[1])
				{
					inlist[i][1] = toBeRemoved[0];
					continue;
				}

				if (toBeRemoved[0] < inlist[i][0] && inlist[i][0] < toBeRemoved[1])
				{
					inlist[i][0] = toBeRemoved[1];
					continue;
				}
			}

			for (int i = ri.Count - 1; i >= 0; i--)
			{
				inlist.RemoveAt(ri[i]);
			}

			return inlist
					.SelectMany(_ => Build(_))
					.ToList();
		}

		private IList<IList<int>> Build(List<int> _)
		{
			var res = new List<IList<int>>();
			for (int i = 0; i < _.Count; i += 2)
			{
				res.Add(new List<int>() { _[i], _[i + 1] });
			}

			return res;
		}
	}
}

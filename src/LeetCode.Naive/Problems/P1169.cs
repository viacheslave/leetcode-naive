using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/invalid-transactions/
	///		Submission: https://leetcode.com/submissions/detail/255322312/
	/// </summary>
	internal class P1169
	{
		public IList<string> InvalidTransactions(string[] transactions)
		{
			var trans = new List<(string name, int time, int amount, string city)>();

			foreach (var tr in transactions)
			{
				var parts = tr.Split(',');
				var t = (parts[0], int.Parse(parts[1]), int.Parse(parts[2]), parts[3]);
				trans.Add(t);
			}

			trans = trans.OrderBy(t => t.time).ToList();

			var ans = new List<(string name, int time, int amount, string city)>();

			for (int i = 0; i < trans.Count; i++)
			{
				var tran = trans[i];

				if (tran.amount > 1000)
				{
					ans.Add(tran);
					continue;
				}

				var left = i - 1;
				var right = i + 1;

				while (left >= 0)
				{
					if ((left >= 0 && Math.Abs(trans[left].time - tran.time) <= 60) && trans[left].name == tran.name && trans[left].city != tran.city)
						ans.Add(tran);

					left--;
				}

				while (right <= trans.Count)
				{
					if ((right < trans.Count && Math.Abs(trans[right].time - tran.time) <= 60) && trans[right].name == tran.name && trans[right].city != tran.city)
						ans.Add(tran);

					right++;
				}
			}

			return ans
		.Distinct()
		.Select(a => $"{a.name},{a.time},{a.amount},{a.city}")
		.ToList();
		}
	}
}

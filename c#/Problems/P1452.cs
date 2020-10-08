using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/people-whose-list-of-favorite-companies-is-not-a-subset-of-another-list/
	///		Submission: https://leetcode.com/submissions/detail/345044821/
	/// </summary>
	internal class P1452
	{
		public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
		{
			var fc = favoriteCompanies
				.Select((c, i) => (i, c.ToHashSet()))
				.OrderBy(c => c.Item2.Count)
				.ToList();

			var ans = new HashSet<int>();

			for (int i = 0; i < fc.Count; i++)
			{
				for (int j = i + 1; j < fc.Count; j++)
				{
					if (fc[i].Item2.IsSubsetOf(fc[j].Item2))
					{
						ans.Add(fc[i].i);
						break;
					}
				}
			}

			return Enumerable.Range(0, fc.Count)
				.Where(c => !ans.Contains(c))
				.OrderBy(x => x)
				.ToList();
		}
	}
}

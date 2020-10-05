using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/camelcase-matching/
	///		Submission: https://leetcode.com/submissions/detail/404803538/
	/// </summary>
	internal class P1023
	{
		public IList<bool> CamelMatch(string[] queries, string pattern)
		{
			var ans = new List<bool>();

			foreach (var query in queries)
				ans.Add(Matches(query, pattern));

			return ans;
		}

		private bool Matches(string query, string pattern)
		{
			var dp = new Dictionary<(int, int), bool>();

			dp[(-1, -1)] = true;

			Resolve(dp, query, pattern, query.Length - 1, pattern.Length - 1);

			return dp[(query.Length - 1, pattern.Length - 1)];
		}

		private bool Resolve(Dictionary<(int, int), bool> dp, string query, string pattern, int q, int p)
		{
			if (dp.ContainsKey((q, p)))
				return dp[(q, p)];

			if (p == -1)
				return char.IsLower(query[q]) && Resolve(dp, query, pattern, q - 1, p);

			dp[(q, p)] =
					(query[q] == pattern[p] && Resolve(dp, query, pattern, q - 1, p - 1)) ||
					(query[q] != pattern[p] && char.IsLower(query[q]) && Resolve(dp, query, pattern, q - 1, p));

			return dp[(q, p)];
		}
	}
}

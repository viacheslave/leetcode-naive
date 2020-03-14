using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/subdomain-visit-count/
	///		Submission: https://leetcode.com/submissions/detail/233393302/
	/// </summary>
	internal class P0811
	{
		public IList<string> SubdomainVisits(string[] cpdomains)
		{
			var d = new Dictionary<string, int>();

			foreach (var domain in cpdomains)
			{
				var h = domain.Split(' ');
				var count = int.Parse(h[0]);

				var parts = h[1].Split('.');
				var sb = new StringBuilder();

				for (var i = parts.Length - 1; i >= 0; i--)
				{
					if (i != parts.Length - 1)
						sb.Insert(0, ".");
					sb.Insert(0, parts[i]);

					var value = sb.ToString();
					if (!d.ContainsKey(value))
						d[value] = 0;

					d[value] = d[value] + count;
				}
			}

			return d.Select(_ => $"{_.Value} {_.Key}").ToList();
		}
	}
}

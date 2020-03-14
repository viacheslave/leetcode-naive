using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/simplify-path/
	///		Submission: https://leetcode.com/submissions/detail/238068371/
	/// </summary>
	internal class P0071
	{
		public string SimplifyPath(string path)
		{
			var cur = new List<string>();

			var values = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

			foreach (var value in values)
			{
				if (value == ".")
					continue;

				if (value == "..")
				{
					if (cur.Count > 0)
						cur.RemoveAt(cur.Count - 1);
					continue;
				}

				cur.Add(value);
			}

			return "/" + string.Join('/', cur);
		}
	}
}

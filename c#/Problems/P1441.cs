using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/build-an-array-with-stack-operations/
	///		Submission: https://leetcode.com/submissions/detail/387701546/
	/// </summary>
	internal class P1441
	{
		public IList<string> BuildArray(int[] target, int n)
		{
			var ans = new List<string>();

			var current = 1;

			for (var i = 0; i < target.Length; i++)
			{
				var el = target[i];

				while (el != current)
				{
					ans.Add("Push");
					ans.Add("Pop");

					current++;
				}

				ans.Add("Push");
				current++;
			}

			return ans;
		}
	}
}

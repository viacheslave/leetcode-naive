using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/verifying-an-alien-dictionary/
	///		Submission: https://leetcode.com/submissions/detail/233823366/
	/// </summary>
	internal class P0953
	{
		public bool IsAlienSorted(string[] words, string order)
		{
			var newList = new List<string>();

			foreach (var word in words)
			{
				var sb = new StringBuilder();

				foreach (var ch in word)
					sb.Append((char)(97 + order.IndexOf(ch)));

				newList.Add(sb.ToString());
			}

			var orderedList = newList.OrderBy(_ => _).ToList();

			for (var i = 0; i < newList.Count; i++)
				if (newList[i] != orderedList[i])
					return false;

			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/print-words-vertically/
	///		Submission: https://leetcode.com/submissions/detail/295932663/
	/// </summary>
	internal class P1324
	{
		public IList<string> PrintVertically(string s)
		{
			var words = s.Split(' ');
			var length = words.Max(s1 => s1.Length);

			var mat = new char[words.Length][];
			for (int i = 0; i < words.Length; i++)
				mat[i] = words[i].ToCharArray();

			var ans = new List<string>();

			for (int j = 0; j < length; j++)
			{
				var arr = new char[words.Length];
				for (int i = 0; i < words.Length; i++)
					arr[i] = j < mat[i].Length ? mat[i][j] : ' ';

				ans.Add(new string(arr).TrimEnd());
			}

			return ans;
		}
	}
}

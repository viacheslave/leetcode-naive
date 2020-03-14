using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
	///		Submission: https://leetcode.com/submissions/detail/225956043/
	/// </summary>
	internal class P0017
	{
		Dictionary<int, char[]> map = new Dictionary<int, char[]>
				{
						{2, new char[] {'a','b','c'}},
						{3, new char[] {'d','e','f'}},
						{4, new char[] {'g','h','i'}},
						{5, new char[] {'j','k','l'}},
						{6, new char[] {'m','n','o'}},
						{7, new char[] {'p','q','r', 's'}},
						{8, new char[] {'t','u','v'}},
						{9, new char[] {'w','x','y', 'z'}}
				};



		public IList<string> LetterCombinations(string digits)
		{
			var len = digits.Length;

			var res = new List<string>();
			if (len == 0)
				return res;

			var cur = new char[len];

			Process(digits, res, cur, 0);

			return res;
		}

		private void Process(string digits, List<string> res, char[] cur, int index)
		{
			if (index == cur.Length)
			{
				res.Add(new string(cur));
				return;
			}

			var number = int.Parse(digits[index].ToString());
			var arr = map[number];

			for (var i = 0; i < arr.Length; i++)
			{
				cur[index] = arr[i];
				Process(digits, res, cur, index + 1);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/detect-capital/
	///		Submission: https://leetcode.com/submissions/detail/228177776/
	/// </summary>
	internal class P0520
	{
		public bool DetectCapitalUse(string word)
		{
			if (word.Length == 1)
				return true;

			bool firstCap = Char.IsUpper(word[0]);

			bool allCaps = firstCap;
			bool allLow = !firstCap;


			for (var i = 1; i < word.Length; i++)
			{
				allCaps = allCaps && Char.IsUpper(word[i]);
				allLow = allLow && Char.IsLower(word[i]);
				firstCap = firstCap && Char.IsLower(word[i]);

				if (allCaps || allLow)
					continue;

				if (firstCap && Char.IsLower(word[i]))
					continue;


				return false;
			}

			return true;
		}
	}
}

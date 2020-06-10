using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/unique-morse-code-words/
	///		Submission: https://leetcode.com/submissions/detail/233859645/
	/// </summary>
	internal class P0804
	{
		private string[] m = new string[] {
				".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};

		public int UniqueMorseRepresentations(string[] words)
		{
			var hs = new HashSet<string>();

			foreach (var word in words)
				hs.Add(GetMorse(word));

			return hs.Count;
		}

		private string GetMorse(string s)
		{
			var sb = new StringBuilder();

			foreach (var ch in s)
				sb.Append(m[(int)ch - 97]);

			return sb.ToString();
		}
	}
}

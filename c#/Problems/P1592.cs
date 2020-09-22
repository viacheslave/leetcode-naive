using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rearrange-spaces-between-words/
	///		Submission: https://leetcode.com/submissions/detail/399262984/
	/// </summary>
	internal class P1592
	{
		public string ReorderSpaces(string text) 
    {
      var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      var wordsCharactersLength = words.Sum(x => x.Length);

      var spaces = text.Length - wordsCharactersLength;

      if (spaces == 0)
          return text;

      if (words.Length == 1)
          return words[0] + new string(' ', spaces);

      var spacesInGroup = spaces / (words.Length - 1);
      var spacesInTheEnd = spaces % (words.Length - 1);

      var sb = new StringBuilder();

      for (int i = 0; i < words.Length; i++) 
      {
          string word = words[i];
          sb.Append(word);

          if (i != words.Length - 1)
              sb.Append(new string(' ', spacesInGroup));
      }

      sb.Append(new string(' ', spacesInTheEnd));
      return sb.ToString();
    }
	}
}

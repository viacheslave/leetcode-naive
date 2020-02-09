using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/substring-with-concatenation-of-all-words/
	///		Submission: https://leetcode.com/submissions/detail/291191448/
	/// </summary>
	internal class P0030
	{
    public IList<int> FindSubstring(string s, string[] words)
    {
      if (string.IsNullOrEmpty(s) || words.Length == 0)
        return new List<int>();

      var wordLength = words[0].Length;
      var subLength = wordLength * words.Length;

      var ans = new List<int>();

      var wordsMap = new Dictionary<string, int>();
      foreach (var word in words)
      {
        if (!wordsMap.ContainsKey(word))
          wordsMap[word] = 0;
        wordsMap[word]++;
      }

      //var wordsDistinct = string.Join("", words).Distinct().Count();

      for (var i = 0; i < s.Length; i++)
      {
        if (i + subLength > s.Length)
          break;

        var sub = s.Substring(i, subLength);

        //if (sub.Distinct().Count() != wordsDistinct)
        //    continue;

        var fit = true;

        var subMap = new Dictionary<string, int>();
        for (var j = 0; j < sub.Length; j += wordLength)
        {
          var subsub = sub.Substring(j, wordLength);
          if (!wordsMap.ContainsKey(subsub))
          {
            fit = false;
            break;
          }

          if (!subMap.ContainsKey(subsub))
            subMap[subsub] = 0;
          subMap[subsub]++;
        }

        if (!fit) continue;

        fit = wordsMap.Count == subMap.Count;
        if (fit)
        {
          foreach (var word in wordsMap)
          {
            if (!subMap.ContainsKey(word.Key) || subMap[word.Key] != word.Value)
            {
              fit = false;
              break;
            }
          }

          if (fit)
            ans.Add(i);
        }

      }

      return ans;
    }
  }
}

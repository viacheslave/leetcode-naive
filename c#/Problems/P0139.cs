using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/word-break/
	///		Submission: https://leetcode.com/submissions/detail/396646874/
	/// </summary>
	internal class P0139
	{
    public bool WordBreak(string s, IList<string> wordDict)
    {
      var dp = new Dictionary<string, bool>();

      dp[""] = true;

      var can = CanBreak(dp, s, wordDict);
      return can;
    }

    public bool CanBreak(Dictionary<string, bool> dp, string s, IList<string> wordDict)
    {
      if (dp.ContainsKey(s))
        return dp[s];

      var res = false;

      foreach (var word in wordDict)
      {
        if (s == word)
        {
          dp[s] = true;
          return dp[s];
        }

        var index = s.IndexOf(word);
        if (index == -1)
          continue;

        var local = true;

        var words = new[] { s.Substring(0, index), s.Substring(index + word.Length) };
        foreach (var w in words)
          local = local && CanBreak(dp, w, wordDict);

        res = res || local;
      }

      dp[s] = res;
      return dp[s];
    }
  }
}

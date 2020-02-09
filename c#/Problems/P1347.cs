using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
  /// <summary>
	///		Problem: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/
	///		Submission: https://leetcode.com/submissions/detail/301669796/
	/// </summary>
	internal class P1347
  {
    public int MinSteps(string s, string t)
    {
      var mapS = s.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());
      var mapT = t.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());

      var diff = new Dictionary<char, int>();

      foreach (var item in mapS)
        if (!mapT.ContainsKey(item.Key))
          diff[item.Key] = -item.Value;

      foreach (var item in mapT)
        if (!mapS.ContainsKey(item.Key))
          diff[item.Key] = item.Value;

      foreach (var item in mapT)
      {
        if (mapS.ContainsKey(item.Key))
          diff[item.Key] = mapT[item.Key] - mapS[item.Key];
      }

      return diff.Where(x => x.Value > 0).Sum(x => x.Value);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/increasing-decreasing-string/
	///		Submission: https://leetcode.com/submissions/detail/310646478/
	/// </summary>
	internal class P1370
	{
    public string SortString(string s)
    {
      var map = s.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
      var sortedMap = new SortedDictionary<char, int>(map);
      var keys = sortedMap.Keys.ToArray();
      var ans = new StringBuilder();

      var added = 1;
      while (added > 0)
      {
        added = 0;

        for (var i = 0; i < keys.Length; i++)
        {
          if (sortedMap[keys[i]] > 0)
          {
            added++;
            ans.Append(keys[i]);
            sortedMap[keys[i]]--;
          }
        }

        added = 0;

        for (var i = keys.Length - 1; i >= 0; i--)
        {
          if (sortedMap[keys[i]] > 0)
          {
            added++;
            ans.Append(keys[i]);
            sortedMap[keys[i]]--;
          }
        }
      }

      return ans.ToString();
    }
  }
}

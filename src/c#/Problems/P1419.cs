using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-number-of-frogs-croaking/
	///		Submission: https://leetcode.com/submissions/detail/327714161/
	/// </summary>
	internal class P1419
	{
    public int MinNumberOfFrogs(string croakOfFrogs)
    {
      if (croakOfFrogs.Length % 5 != 0)
        return -1;

      var dis = croakOfFrogs.Length / 5;
      if (!croakOfFrogs.GroupBy(c => c).Select(x => x.Count()).All(x => x == dis))
        return -1;

      var data = new Dictionary<char, int>();
      var count = 0;
      var ans = 0;

      foreach (var ch in croakOfFrogs)
      {
        switch (ch)
        {
          case 'c':
            Inc(data, ch);
            count++;
            ans = Math.Max(ans, count);
            break;

          case 'r':
            if (!data.ContainsKey('c') || data['c'] == 0)
              return -1;

            data['c']--;
            Inc(data, 'r');
            break;

          case 'o':
            if (!data.ContainsKey('r') || data['r'] == 0)
              return -1;

            data['r']--;
            Inc(data, 'o');
            break;

          case 'a':
            if (!data.ContainsKey('o') || data['o'] == 0)
              return -1;

            data['o']--;
            Inc(data, 'a');
            break;

          case 'k':
            if (!data.ContainsKey('a') || data['a'] == 0)
              return -1;

            data['a']--;
            count--;
            break;
        }
      }

      return ans;
    }
  }
}

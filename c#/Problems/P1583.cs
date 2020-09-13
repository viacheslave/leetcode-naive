using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-unhappy-friends/
	///		Submission: https://leetcode.com/submissions/detail/395080508/
	/// </summary>
	internal class P1583
	{
		public int UnhappyFriends(int n, int[][] preferences, int[][] pairs)
    {
      var ranks = new int[n][];

      for (var i = 0; i < n; i++)
      {
        ranks[i] = new int[n];
        for (var j = 0; j < preferences[i].Length; j++)
            ranks[i][preferences[i][j]] = j;
      }

      var pairMap = new Dictionary<int, int>();
      foreach (var pair in pairs)
      {
        pairMap.Add(pair[0], pair[1]);
        pairMap.Add(pair[1], pair[0]);
      }

      var ans = new List<int>();

      for (var i = 0; i < n; i++)
      {
        var preference = preferences[i];
        var pair = pairMap[i];
        var pairIndex = ranks[i][pair];

        for (var j = 0; j < pairIndex; j++)
        {
          var other = preference[j];
          var otherPair = pairMap[other];
          var otherPairIndex = ranks[other][otherPair];
          var thisIndex = ranks[other][i];

          if (thisIndex < otherPairIndex)
              ans.Add(i);
        }
      }

      return ans.Distinct().Count();
    }
	}
}

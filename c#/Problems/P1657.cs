using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/determine-if-two-strings-are-close/
  ///    Submission: https://leetcode.com/submissions/detail/420472172/
  /// </summary>
  internal class P1657
  {
    public class Solution
    {
      public bool CloseStrings(string word1, string word2)
      {
        var map1 = word1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var map2 = word2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if (!map1.Keys.ToHashSet().SetEquals(map2.Keys.ToHashSet()))
          return false;

        var arr1 = new List<int>();
        var arr2 = new List<int>();

        for (var ch = 97; ch <= 97 + 26; ch++)
        {
          if (map1.ContainsKey((char)ch) && map2.ContainsKey((char)ch) && map1[(char)ch] == map2[(char)ch])
            continue;

          if (map1.ContainsKey((char)ch))
            arr1.Add(map1[(char)ch]);

          if (map2.ContainsKey((char)ch))
            arr2.Add(map2[(char)ch]);
        }

        arr1.Sort();
        arr2.Sort();

        if (arr1.Count != arr2.Count)
          return false;

        for (int i = 0; i < arr2.Count; i++)
        {
          if (arr1[i] != arr2[i])
            return false;
        }

        return true;
      }
    }
  }
}

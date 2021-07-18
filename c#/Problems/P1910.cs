using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-all-occurrences-of-a-substring/
  ///    Submission: https://leetcode.com/submissions/detail/518848178/
  /// </summary>
  internal class P1910
  {
    public class Solution
    {
      public string RemoveOccurrences(string s, string part)
      {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
          stack.Push(ch);

          if (ch == part[part.Length - 1] && stack.Count >= part.Length)
          {
            var arr = new char[part.Length];
            for (var j = 0; j < part.Length; j++)
              arr[arr.Length - 1 - j] = stack.Pop();

            if (new string(arr) != part)
              for (var j = 0; j < part.Length; j++)
                stack.Push(arr[j]);
          }
        }

        var ans = new List<char>();
        while (stack.Count > 0)
          ans.Add(stack.Pop());

        var str = new string(ans.Reverse<char>().ToArray());
        return str;
      }
    }
  }
}

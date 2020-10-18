using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/
  ///    Submission: https://leetcode.com/submissions/detail/300767151/
  /// </summary>
  internal class P1190
  {
    public class Solution
    {
      public string ReverseParentheses(string s)
      {
        var brackets = new Stack<(char, int)>();
        var arr = new StringBuilder(s);

        for (var i = 0; i < s.Length; i++)
        {
          if (s[i] == '(')
          {
            brackets.Push((s[i], i));
          }
          else if (s[i] == ')')
          {
            var lastBracket = brackets.Pop();
            var substring = arr.ToString().Substring(lastBracket.Item2 + 1, i - 1 - lastBracket.Item2);
            var reversed = substring.Reverse().ToList();

            for (int index = lastBracket.Item2 + 1, j = 0; index < i; index++, j++)
            {
              arr[index] = reversed[j];
            }
          }
        }

        return arr.ToString().Replace("(", "").Replace(")", "");
      }
    }
  }
}

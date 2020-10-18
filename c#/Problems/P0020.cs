using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-parentheses/
  ///    Submission: https://leetcode.com/submissions/detail/227444718/
  /// </summary>
  internal class P0020
  {
    public class Solution
    {
      public bool IsValid(string s)
      {
        Dictionary<char, char> keys = new Dictionary<char, char>
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };

        Stack<char> stack = new Stack<char>();

        char next = default(char);
        bool opened = false;

        foreach (var ch in s)
        {
          if (keys.ContainsKey(ch))
          {
            stack.Push(ch);
            continue;
          }

          if (stack.Count > 0 && keys[stack.Peek()] == ch)
          {
            stack.Pop();
          }
          else
          {
            return false;
          }

        }

        return stack.Count == 0;
      }
    }
  }
}

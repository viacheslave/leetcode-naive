using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-score-from-removing-substrings/
  ///    Submission: https://leetcode.com/submissions/detail/440752660/
  /// </summary>
  internal class P1717
  {
    public class Solution
    {
      public int MaximumGain(string s, int x, int y)
      {
        var stack = new Stack<char>();
        var ans = 0;

        var prefered = x > y ? "ab" : "ba";
        var preferedPoints = Math.Max(x, y);
        var nonPreferedPoints = Math.Min(x, y);

        for (var i = 0; i < s.Length; i++)
        {
          stack.TryPeek(out var peek);

          // process combination with max score
          if (s[i] == prefered[1] && peek == prefered[0])
          {
            ans += preferedPoints;
            stack.Pop();

            // process stack in case of last char
            if (i == s.Length - 1)
              ProcessStack();

            continue;
          }

          // if not max score combination - add to stack
          if (s[i] == prefered[0] || s[i] == prefered[1])
            stack.Push(s[i]);

          // if not 'a' and not 'b', or last char - process stack
          // because stack cannot be connected to next chars
          if ((s[i] != prefered[0] && s[i] != prefered[1]) || i == s.Length - 1)
            ProcessStack();
        }

        return ans;

        void ProcessStack()
        {
          // stack score is min combination score times min count of chars 'a' or 'b'
          var a = 0;
          var b = 0;

          while (stack.Count > 0)
          {
            var ch = stack.Pop();
            if (ch == 'a') a++;
            else b++;
          }

          var nonPreferedCount = Math.Min(a, b);
          ans += nonPreferedCount * nonPreferedPoints;
        }
      }
    }
  }
}

using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string/
  ///    Submission: https://leetcode.com/submissions/detail/428905599/
  /// </summary>
  internal class P1541
  {
    public class Solution
    {
      public int MinInsertions(string s)
      {
        var stack = new Stack<char>();
        var ans = 0;

        var index = 0;
        while (index < s.Length)
        {
          if (s[index] == '(')
          {
            stack.Push('(');
            index++;
            continue;
          }

          if (stack.Count > 0)
            stack.Pop();
          else
            ans++;

          if (index + 1 < s.Length && s[index] == ')' && s[index + 1] == ')')
          {
            index += 2;
          }
          else
          {
            ans++;
            index++;
          }
        }

        return ans + stack.Count * 2;
      }
    }
  }
}

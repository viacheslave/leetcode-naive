using System;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/latest-time-by-replacing-hidden-digits/
  ///    Submission: https://leetcode.com/submissions/detail/450195497/
  /// </summary>
  internal class P1736
  {
    public class Solution
    {
      public string MaximumTime(string time)
      {
        var sb = new StringBuilder(time);

        if (sb[0] == '?') sb[0] = (sb[1] == '?' || int.Parse(sb[1].ToString()) < 4) ? '2' : '1';
        if (sb[1] == '?') sb[1] = sb[0] == '2' ? '3' : '9';
        if (sb[2] == '?') sb[2] = ':';
        if (sb[3] == '?') sb[3] = '5';
        if (sb[4] == '?') sb[4] = '9';

        return sb.ToString();
      }
    }
  }
}

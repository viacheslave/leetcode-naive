using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-and-say/
  ///    Submission: https://leetcode.com/submissions/detail/225962073/
  /// </summary>
  internal class P0038
  {
    public class Solution
    {
      public string CountAndSay(int n)
      {
        int[] current = new int[1] { 1 };


        for (var i = 1; i < n; i++)
        {
          List<int> next = new List<int>();

          int count = 1;
          int value;

          if (current.Length == 1)
          {
            current = new int[2] { 1, current[0] };
            continue;
          }

          for (var j = 1; j < current.Length; j++)
          {
            if (current[j] == current[j - 1])
            {
              count++;
            }
            else
            {
              next.Add(count);
              next.Add(current[j - 1]);

              count = 1;
            }

            if (j == current.Length - 1)
            {
              next.Add(count);
              next.Add(current[j]);
              break;
            }
          }

          current = next.ToArray();
        }

        var sb = new StringBuilder();
        for (var i = 0; i < current.Length; i++)
          sb.Append(current[i]);

        return sb.ToString();
      }
    }
  }
}

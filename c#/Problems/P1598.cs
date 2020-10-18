using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/crawler-log-folder/
  ///    Submission: https://leetcode.com/submissions/detail/401316170/
  /// </summary>
  internal class P1598
  {
    public class Solution
    {
      public int MinOperations(string[] logs)
      {
        var st = new Stack<string>();

        foreach (var log in logs)
        {
          if (log == "./")
            continue;

          if (log == "../")
          {
            if (st.Count > 0)
              st.Pop();
            continue;
          }

          st.Push(log);
        }

        return st.Count;
      }
    }
  }
}

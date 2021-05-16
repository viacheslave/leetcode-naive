using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/incremental-memory-leak/
  ///    Submission: https://leetcode.com/submissions/detail/493857545/
  /// </summary>
  internal class P1860
  {
    public class Solution
    {
      public int[] MemLeak(int memory1, int memory2)
      {
        for (var i = 1; ; ++i)
        {
          if (memory1 >= memory2 && memory1 >= i)
            memory1 -= i;
          else if (memory1 < memory2 && memory2 >= i)
            memory2 -= i;
          else
            return new[] { i, memory1, memory2 };
        }
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/1-bit-and-2-bit-characters/
  ///    Submission: https://leetcode.com/submissions/detail/230464204/
  /// </summary>
  internal class P0717
  {
    public class Solution
    {
      public bool IsOneBitCharacter(int[] bits)
      {
        int index = 0;


        var last = 0;

        while (index < bits.Length)
        {
          if (bits[index] == 0)
          {
            last = 1;
            index++;
            continue;
          }

          if (bits[index] == 1)
          {
            last = 2;
            index += 2;
          }
        }

        return last == 1;
      }
    }
  }
}

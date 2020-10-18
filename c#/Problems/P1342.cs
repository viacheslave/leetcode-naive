using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
  ///    Submission: https://leetcode.com/submissions/detail/301633536/
  /// </summary>
  internal class P1342
  {
    public class Solution
    {
      public int NumberOfSteps(int num) {
        var ans = 0;
        while (num > 0) {
          if (num % 2 == 0) {
            num >>= 1;
          } else {
            num -= 1;
          }
          ans++;
        }
        return ans;
      }
    } 
  }
}

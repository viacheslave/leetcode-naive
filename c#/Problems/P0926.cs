using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flip-string-to-monotone-increasing/
  ///    Submission: https://leetcode.com/submissions/detail/432969331/
  /// </summary>
  internal class P0926
  {
    public class Solution
    {
      public int MinFlipsMonoIncr(string S)
      {
        var totalOnes = S.Count(x => x == '1');

        if (totalOnes == S.Length || totalOnes == 0)
          return 0;

        // calculate number of ones up to centain index
        var preOnes = new int[S.Length + 1];
        for (var i = 0; i < S.Length; i++)
          preOnes[i + 1] = S[i] == '1' ? preOnes[i] + 1 : preOnes[i];

        var ans = int.MaxValue;

        for (var i = 0; i < S.Length + 1; i++)
        {
          var onesLeft = preOnes[i];
          var onesRight = totalOnes - onesLeft;

          // for every left and right substring:
          // answer is the sum of ones on the left (to be converted to zeros)
          // plus the sum of zeros on the right (to be converted to ones)
          // in order to make is monotone increasing.
          ans = Math.Min(ans,
            onesLeft + (S.Length - i - onesRight));
        }

        return ans;
      }
    }
  }
}

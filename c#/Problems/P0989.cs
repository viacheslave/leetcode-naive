using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/add-to-array-form-of-integer/
  ///    Submission: https://leetcode.com/submissions/detail/227858131/
  /// </summary>
  internal class P0989
  {
    public class Solution
    {
      public IList<int> AddToArrayForm(int[] A, int K)
      {

        var kLength = K.ToString().Length;
        var length = Math.Max(A.Length, kLength);

        var sb = new List<int>();
        var carry = 0;

        for (var i = 0; i < length; i++)
        {
          int left = 0;
          int right = 0;

          if (A.Length - 1 - i >= 0)
            left = A[A.Length - 1 - i];

          if (kLength - 1 - i >= 0)
            right = int.Parse(K.ToString()[kLength - 1 - i].ToString());

          var sum = left + right + carry;

          if (sum >= 10)
          {
            sb.Insert(0, sum % 10);
            carry = sum >= 10 ? 1 : 0;
          }
          else
          {
            sb.Insert(0, sum);
            carry = 0;
          }
        }

        if (carry == 1)
          sb.Insert(0, 1);


        return sb;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-palindromic-subsequences/
	///		Submission: https://leetcode.com/submissions/detail/297532395/
	/// </summary>
	internal class P1342
	{
		public int NumberOfSteps (int num) {
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

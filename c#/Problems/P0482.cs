using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/license-key-formatting/
	///		Submission: https://leetcode.com/submissions/detail/231769060/
	/// </summary>
	internal class P0482
	{
		public string LicenseKeyFormatting(string S, int K)
		{
			var dashesUpper = S.Replace("-", "").ToUpper();

			var firstGroupLength = dashesUpper.Length % K;

			var sb = new StringBuilder();
			if (firstGroupLength > 0)
			{
				sb.Append(dashesUpper.Substring(0, firstGroupLength));
				sb.Append("-");
			}

			for (var i = firstGroupLength; i < dashesUpper.Length; i += K)
			{
				sb.Append(dashesUpper.Substring(i, K));
				sb.Append("-");
			}

			if (sb.Length > 0)
				sb.Remove(sb.Length - 1, 1);

			return sb.ToString();
		}
	}
}

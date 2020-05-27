using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/permutation-sequence/
	///		Submission: https://leetcode.com/submissions/detail/235663363/
	/// </summary>
	internal class P0060
	{
		public string GetPermutation(int n, int k)
		{
			var arrFilled = new int[n];
			var arrRes = new int[n];

			for (var digitIndex = 0; digitIndex < n; digitIndex++)
			{
				var groupLength = GetGroupIndex(n - digitIndex);

				var parentGroupIndex = (k - 1) % GetGroupIndex(n - digitIndex + 1);

				var groupIndex = parentGroupIndex / groupLength;

				var digit = 0;

				var freeCurrent = 0;
				for (var i = 0; i < arrFilled.Length; i++)
				{
					if (arrFilled[i] == 1)
						continue;

					if (freeCurrent == groupIndex)
					{
						digit = i + 1;
						arrFilled[i] = 1;
						break;
					}

					freeCurrent++;
				}

				arrRes[digitIndex] = digit;
			}

			var sb = new StringBuilder();
			foreach (var item in arrRes)
				sb.Append(item);

			return sb.ToString();
		}

		private int GetGroupIndex(int n)
		{
			var length = 1;
			for (var i = 1; i < n; i++)
				length = length * i;

			return length;
		}
	}
}

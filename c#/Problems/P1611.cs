using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-one-bit-operations-to-make-integers-zero
	///		Submission: https://leetcode.com/submissions/detail/404450691/
	/// </summary>
	internal class P1611
	{
		public int MinimumOneBitOperations(int n)
		{
			if (n == 0)
				return 0;

			var digits = GetDigits(n);

			var binaryTreeDirections = new List<int>();

			var oneZero = (1, 0);
			var zeroOne = (0, 1);

			var current = oneZero;
			binaryTreeDirections.Add(1);

			for (var i = 1; i < digits.Count; i++)
			{
				var digit = digits[i];

				current = binaryTreeDirections.Last() == 1
						? zeroOne
						: oneZero;

				if (current.Item1 == digit)
					binaryTreeDirections.Add(1);
				else
					binaryTreeDirections.Add(0);
			}

			var ans = 0;

			for (int i = 0; i < binaryTreeDirections.Count; i++)
			{
				if (binaryTreeDirections[i] == 1)
					ans += (int)Math.Pow(2, binaryTreeDirections.Count - i - 1);
			}

			return ans;
		}

		private static List<int> GetDigits(int n)
		{
			var digits = new List<int>();

			while (n > 0)
			{
				digits.Add(n % 2);
				n >>= 1;
			}

			digits.Reverse();
			return digits;
		}
	}
}

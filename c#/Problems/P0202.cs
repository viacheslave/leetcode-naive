using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/happy-number/
	///		Submission: https://leetcode.com/submissions/detail/226906845/
	/// </summary>
	internal class P0202
	{
		public bool IsHappy(int n)
		{
			HashSet<int> sums = new HashSet<int>();

			while (true)
			{
				var sum = GetSum(n);
				if (sums.Contains(sum))
					return false;

				if (sum == 1)
					return true;

				sums.Add(sum);
				n = sum;
			}

			return false;
		}

		private int GetSum(int n)
		{
			int d = 1;
			while (d <= n / 10)
			{
				d = d * 10;
			}

			var arr = new List<int>();
			while (true)
			{
				var digit = n / d;
				var mod = n % d;

				if (d == 1)
				{
					arr.Add(n);
					break;
				}

				n = n - digit * d;
				d = d / 10;

				arr.Add(digit);
			}

			var s = 0;
			for (var i = 0; i < arr.Count; i++)
				s += arr[i] * arr[i];

			return s;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/self-dividing-numbers/
	///		Submission: https://leetcode.com/submissions/detail/229081425/
	/// </summary>
	internal class P0728
	{
		public IList<int> SelfDividingNumbers(int left, int right)
		{

			var res = new List<int>();

			for (var i = left; i <= right; i++)
			{
				var digits = GetDigits(i);
				var fits = true;

				for (var j = 0; j < digits.Count; j++)
				{
					if (digits[j] == 0 || i % digits[j] != 0)
					{
						fits = false;
						break;
					}
				}

				if (fits)
				{
					res.Add(i);
				}
			}

			return res;
		}

		private List<int> GetDigits(int num)
		{
			var res = new List<int>();

			var power = 1;
			while (num / power >= 10)
			{
				power = power * 10;
			}

			while (power >= 0)
			{
				var digit = num / power;
				num = num - power * digit;

				res.Add(digit);

				power = power / 10;

				if (power == 0)
					break;
			}

			return res;
		}
	}
}

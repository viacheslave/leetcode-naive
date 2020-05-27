using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/add-strings/
	///		Submission: https://leetcode.com/submissions/detail/227448914/
	/// </summary>
	internal class P0415
	{
		public string AddStrings(string num1, string num2)
		{
			var i1 = num1.Length - 1;
			var i2 = num2.Length - 1;

			StringBuilder sb = new StringBuilder();

			bool carry = false;

			while (i1 >= 0 || i2 >= 0)
			{
				var n1 = (i1 >= 0) ? int.Parse(num1[i1].ToString()) : 0;
				var n2 = (i2 >= 0) ? int.Parse(num2[i2].ToString()) : 0;

				var s = n1 + n2;
				if (carry)
					s++;

				if (s >= 10)
					carry = true;
				else
					carry = false;

				sb.Insert(0, (s % 10).ToString());

				i1--;
				i2--;
			}

			if (carry)
				sb.Insert(0, "1");

			return sb.ToString();
		}
	}
}

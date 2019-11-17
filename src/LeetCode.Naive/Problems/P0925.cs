using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/long-pressed-name/
	///		Submission: https://leetcode.com/submissions/detail/229946055/
	/// </summary>
	internal class P0925
	{
		public bool IsLongPressedName(string name, string typed)
		{
			if (name.Length == 0)
				return true;

			int i = 0;
			int j = 0;

			while (i < name.Length)
			{
				if (j >= typed.Length)
					return false;

				if (name[i] != typed[j])
					return false;

				// next equals
				if ((i + 1 < name.Length) && (j + 1 < typed.Length) && (name[i + 1] == typed[j + 1]))
				{
					i++; j++;
					continue;
				}

				while (j < typed.Length && typed[j] == name[i])
				{
					j++;
				}

				i++;
			}

			return true;
		}
	}
}

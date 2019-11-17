using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/circular-permutation-in-binary-representation/
	///		Submission: https://leetcode.com/submissions/detail/279588617/
	/// </summary>
	internal class P1238
	{
		public IList<int> CircularPermutation(int n, int start)
		{
			var list = new int[(int)Math.Pow(2, n)];

			for (int col = 0; col < n; col++)
			{
				var step = (int)Math.Pow(2, col);
				var round = 0;

				for (int row = 0; row < (int)Math.Pow(2, n); row++)
				{
					if (round == 4)
						round = 0;

					if (round == 1 || round == 2)
						list[row] += (int)Math.Pow(2, col);

					step--;
					if (step == 0)
					{
						step = (int)Math.Pow(2, col); ;
						round++;
					}
				}
			}

			var ans = new int[(int)Math.Pow(2, n)];
			var pos = Array.IndexOf(list, start);

			for (int i = 0; i < list.Length; i++)
			{
				ans[i] = list[(i + pos) % list.Length];
			}

			return ans;
		}
	}
}

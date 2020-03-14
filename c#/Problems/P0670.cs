using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-swap/
	///		Submission: https://leetcode.com/submissions/detail/235891190/
	/// </summary>
	internal class P0670
	{
		public int MaximumSwap(int num)
		{
			var list = num.ToString().Select(_ => int.Parse(_.ToString())).ToList();

			if (list.Count == 1)
				return num;

			for (var i = 0; i < list.Count - 1; i++)
			{
				var max = list[i];
				var secondIndex = i + 1;

				for (var j = i + 1; j < list.Count; j++)
				{
					if (list[j] >= max)
					{
						max = list[j];
						secondIndex = j;
					}
				}

				if (list[i] != max)
				{
					var tmp = list[i];
					list[i] = list[secondIndex];
					list[secondIndex] = tmp;

					var sb = new StringBuilder();
					foreach (var a in list)
						sb.Append(a);

					return int.Parse(sb.ToString());
				}
			}

			return num;
		}
	}
}

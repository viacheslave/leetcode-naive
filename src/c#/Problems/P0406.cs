using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/queue-reconstruction-by-height/
	///		Submission: https://leetcode.com/submissions/detail/237101688/
	/// </summary>
	internal class P0406
	{
		public class P
		{
			public int Height;
			public int K;
		}

		public int[][] ReconstructQueue(int[][] people)
		{
			var sd = people
					.Select(_ => new P { Height = _[0], K = _[1] })
					.OrderBy(_ => _.Height)
					.ThenBy(_ => _.K)
					.ToList();

			var res = new P[people.Length];

			P lastItem = null;
			int lastPos = -1;

			foreach (var item in sd)
			{
				var startPos = 0;
				var k = item.K;

				if (lastItem != null && item.Height == lastItem.Height)
				{
					startPos = lastPos;
					k = item.K - lastItem.K - 1;
				}

				var currentPos = -1;
				var index = startPos;

				for (index = startPos; index < res.Length; index++)
				{
					if (res[index] == null)
					{
						currentPos++;
						if (currentPos == k)
						{
							res[index] = item;
							break;
						}
					}
				}

				lastItem = item;
				lastPos = index;
			}

			return res.Select(_ => new[] { _.Height, _.K }).ToArray();
		}
	}
}

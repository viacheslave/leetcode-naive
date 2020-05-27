using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-gap/
	///		Submission: https://leetcode.com/submissions/detail/229929384/
	/// </summary>
	internal class P0868
	{
		public int BinaryGap(int N)
		{
			var lastoneindex = -1;
			var max = 0;

			for (var i = 0; i < 32; i++)
			{
				var isone = N % 2 == 1;

				if (isone)
				{
					if (lastoneindex != -1)
					{
						var dist = i - lastoneindex;
						if (max < dist)
							max = dist;
					}

					lastoneindex = i;
				}

				N = N >> 1;
			}

			return max;
		}
	}
}

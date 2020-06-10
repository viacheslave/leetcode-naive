using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-lines-to-write-string/
	///		Submission: https://leetcode.com/submissions/detail/233406076/
	/// </summary>
	internal class P0806
	{
		public int[] NumberOfLines(int[] widths, string S)
		{
			int lineIndex = -1;
			int lineCol = -1;

			foreach (var ch in S)
			{
				var width = widths[((int)ch - 97)];
				var supLineCol = lineCol + width;

				if (supLineCol < 100)
				{
					if (lineIndex == -1)
						lineIndex = 0;

					lineCol = supLineCol;
				}
				else
				{
					lineIndex++;
					lineCol = width - 1;
				}
			}

			return new int[] { lineIndex + 1, lineCol + 1 };
		}
	}
}

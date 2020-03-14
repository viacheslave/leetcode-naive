using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/path-in-zigzag-labelled-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/243012420/
	/// </summary>
	internal class P1104
	{
		public IList<int> PathInZigZagTree(int label)
		{
			var power = 0;

			var cur = label;
			while (cur / 2 > 0)
			{
				cur /= 2;
				power++;
			}

			var straightRow = power % 2 == 0;
			var start = (int)Math.Pow(2, power);

			var result = new List<int>();

			var origLabel = straightRow ? label : (3 * start - label - 1);
			result.Add(label);

			while (origLabel / 2 > 0)
			{
				origLabel /= 2;
				start /= 2;
				straightRow = !straightRow;

				var value = straightRow ? origLabel : (3 * start - origLabel - 1);
				result.Add(value);
			}

			result.Reverse();

			return result;
		}
	}
}

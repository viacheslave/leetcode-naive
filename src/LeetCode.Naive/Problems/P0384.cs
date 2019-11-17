using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shuffle-an-array/
	///		Submission: https://leetcode.com/submissions/detail/230839286/
	/// </summary>
	internal class P0384
	{
		List<int> original;
		Random rnd = new Random((int)DateTime.Now.Ticks);

		public _0384(int[] nums)
		{
			original = new List<int>(nums);
		}

		/** Resets the array to its original configuration and return it. */
		public int[] Reset()
		{
			return original.ToArray();
		}

		/** Returns a random shuffling of the array. */
		public int[] Shuffle()
		{
			var l = new List<int>(original);

			var length = l.Count;
			var result = new List<int>(original.Count);

			while (length > 0)
			{
				var i = rnd.Next(0, length);
				result.Add(l[i]);

				l.RemoveAt(i);
				length--;
			}

			return result.ToArray();
		}
	}
}

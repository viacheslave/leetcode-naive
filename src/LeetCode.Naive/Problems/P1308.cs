using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/jump-game-iii/
	///		Submission: https://leetcode.com/submissions/detail/289482100/
	/// </summary>
	internal class P1308
	{
		public bool CanReach(int[] arr, int start)
		{
			var q = new Queue<int>();
			q.Enqueue(start);

			var set = new HashSet<int>();

			while (q.Count > 0)
			{
				var index = q.Dequeue();
				if (arr[index] == 0)
					return true;

				if (set.Contains(index))
					continue;

				set.Add(index);

				var left = index - arr[index];
				var right = index + arr[index];

				if (left >= 0)
					q.Enqueue(left);
				if (right < arr.Length)
					q.Enqueue(right);
			}

			return false;
		}
	}
}

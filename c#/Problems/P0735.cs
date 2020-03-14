using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/asteroid-collision/
	///		Submission: https://leetcode.com/submissions/detail/290254012/
	/// </summary>
	internal class P0735
	{
		public int[] AsteroidCollision(int[] asteroids)
		{
			if (asteroids.Length <= 1)
				return asteroids;

			var left = 0;
			var right = 1;

			var list = asteroids.ToList();

			while (true)
			{
				if (list.Count <= 1)
					break;

				if (!(list[left] > 0 && list[right] < 0))
				{
					left++;
					right++;
					if (right >= list.Count)
						break;

					continue;
				}

				var result = 0;
				if (list[left] > Math.Abs(list[right]))
					result = list[left];
				else if (list[left] < Math.Abs(list[right]))
					result = list[right];
				else
					result = 0;

				// elimination
				if (result == 0)
				{
					list.RemoveAt(left);
					list.RemoveAt(left);
					left--;

					if (left < 0) left = 0;
					right = left + 1;
				}
				else if (result > 0)
				{
					list.RemoveAt(right);
				}
				else
				{
					list.RemoveAt(left);
					left--;

					if (left < 0) left = 0;
					right = left + 1;
				}

				if (right >= list.Count)
					break;
			}

			return list.ToArray();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/k-closest-points-to-origin/
	///		Submission: https://leetcode.com/submissions/detail/231070939/
	/// </summary>
	internal class P0973
	{
		public int[][] KClosest(int[][] points, int K)
		{
			var d = new Dictionary<Point, double>();

			for (var i = 0; i < points.Length; i++)
			{
				var p = new Point { x = points[i][0], y = points[i][1] };

				d[p] = Math.Sqrt((p.x * p.x) + (p.y * p.y));
			}

			return d.OrderBy(item => item.Value)
					.Take(K)
					.Select(item => item.Key)
					.Select(item => new int[] { item.x, item.y })
					.ToArray();
		}

		class Point
		{
			public int x;
			public int y;

			public override int GetHashCode()
			{
				unchecked
				{
					return x ^ y;
				}
			}

			public override bool Equals(object o)
			{
				var other = (Point)o;
				return other.x == this.x && other.y == this.y;
			}
		}
	}
}

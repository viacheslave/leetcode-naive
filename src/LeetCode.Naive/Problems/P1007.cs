using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/
	///		Submission: https://leetcode.com/submissions/detail/239333343/
	/// </summary>
	internal class P1007
	{
		public int MinDominoRotations(int[] A, int[] B)
		{
			var length = A.Length;

			var mapsA = new Dictionary<int, HashSet<int>>();
			var mapsB = new Dictionary<int, HashSet<int>>();

			for (var pos = 0; pos < A.Length; pos++)
			{
				if (!mapsA.ContainsKey(A[pos])) mapsA[A[pos]] = new HashSet<int>();
				if (!mapsB.ContainsKey(B[pos])) mapsB[B[pos]] = new HashSet<int>();

				mapsA[A[pos]].Add(pos);
				mapsB[B[pos]].Add(pos);
			}

			var min = int.MaxValue;

			for (var i = 1; i <= 6; i++)
			{
				if ((
			mapsA.ContainsKey(i) &&
			mapsB.ContainsKey(i) &&
			mapsA[i].Count + mapsB[i].Count >= length) ||
			(mapsA.ContainsKey(i) && mapsA[i].Count == length) ||
			(mapsB.ContainsKey(i) && mapsB[i].Count == length)
		)
				{
					if ((mapsA.ContainsKey(i) && mapsA[i].Count == length) ||
						 (mapsB.ContainsKey(i) && mapsB[i].Count == length))
					{
						min = 0;
						continue;
					}

					var filled = true;

					for (var pos = 0; pos < length; pos++)
					{
						if (!mapsA[i].Contains(pos) && !mapsB[i].Contains(pos))
						{
							filled = false;
							break;
						}
					}

					if (!filled)
						continue;

					var res = Math.Min(mapsA[i].Count, mapsB[i].Count) - mapsA[i].Intersect(mapsB[i]).Count();
					min = Math.Min(min, res);
				}
			}

			return min == int.MaxValue ? -1 : min;
		}
	}
}

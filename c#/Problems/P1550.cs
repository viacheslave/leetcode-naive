using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/three-consecutive-odds/
	///		Submission: https://leetcode.com/submissions/detail/387676050/
	/// </summary>
	internal class P1550
	{
		public bool ThreeConsecutiveOdds(int[] arr)
		{
			if (arr.Length < 3)
				return false;

			for (var i = 0; i < arr.Length - 2; i++)
				if ((arr[i] % 2) == 1 && (arr[i + 1] % 2) == 1 && (arr[i + 2] % 2) == 1)
					return true;

			return false;
		}
	}
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-students-doing-homework-at-a-given-time/
	///		Submission: https://leetcode.com/submissions/detail/387698346/
	/// </summary>
	internal class P1450
	{
		public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
		{
			var ans = 0;

			for (var i = 0; i < startTime.Length; i++)
			{
				if (startTime[i] <= queryTime && queryTime <= endTime[i])
					ans++;
			}

			return ans;
		}
	}
}

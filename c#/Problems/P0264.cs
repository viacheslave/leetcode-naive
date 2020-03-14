using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/ugly-number-ii/
	///		Submission: https://leetcode.com/submissions/detail/237775765/
	/// </summary>
	internal class P0264
	{
		public int NthUglyNumber(int n)
		{
			var arr2 = new SortedSet<long>() { 2 };
			var arr3 = new SortedSet<long>() { 3 };
			var arr5 = new SortedSet<long>() { 5 };

			var current = 1;
			var currentCount = 1;

			while (currentCount < n)
			{
				var next = Math.Min(arr2.First(), Math.Min(arr3.First(), arr5.First()));

				if (next == arr2.First())
				{
					arr2.Add(arr2.First() * 2);
					arr2.Add(arr2.First() * 3);
					arr2.Add(arr2.First() * 5);
					arr2.Remove(arr2.First());
				}

				if (next == arr3.First())
				{
					arr3.Add(arr3.First() * 2);
					arr3.Add(arr3.First() * 3);
					arr3.Add(arr3.First() * 5);
					arr3.Remove(arr3.First());
				}

				if (next == arr5.First())
				{
					arr5.Add(arr5.First() * 2);
					arr5.Add(arr5.First() * 3);
					arr5.Add(arr5.First() * 5);
					arr5.Remove(arr5.First());
				}

				current = (int)next;

				currentCount++;
			}

			return current;
		}
	}
}

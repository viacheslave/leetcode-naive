using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/relative-sort-array/
	///		Submission: https://leetcode.com/submissions/detail/244669124/
	/// </summary>
	internal class P1122
	{
		public int[] RelativeSortArray(int[] arr1, int[] arr2)
		{
			var arr1Map = new SortedDictionary<int, int>(arr1.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count()));
			var result = new List<int>();

			for (int i = 0; i < arr2.Length; i++)
			{
				arr1Map.TryGetValue(arr2[i], out var count);
				result.AddRange(Enumerable.Repeat(arr2[i], count));

				arr1Map.Remove(arr2[i]);
			}

			foreach (var item in arr1Map)
				result.AddRange(Enumerable.Repeat(item.Key, item.Value));

			return result.ToArray();
		}
	}
}

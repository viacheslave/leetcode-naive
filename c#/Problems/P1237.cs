using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-positive-integer-solution-for-a-given-equation/
	///		Submission: https://leetcode.com/submissions/detail/278254624/
	/// </summary>
	internal class P1237
	{
/*
 * // This is the custom function interface.
 * // You should not implement it, or speculate about its implementation
 * public class CustomFunction {
 *     // Returns f(x, y) for any given positive integers x and y.
 *     // Note that f(x, y) is increasing with respect to both x and y.
 *     // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
 *     public int f(int x, int y);
 * };
 */

		public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
		{
			var ans = new List<IList<int>>();

			for (int x = 1; x <= 1000; x++)
			{
				for (int y = 1; y <= 1000; y++)
				{
					if (customfunction.f(x, y) == z)
					{
						ans.Add(new List<int>() { x, y });
					}
				}
			}

			return ans;
		}

		//
		public class CustomFunction
		{
			// Returns f(x, y) for any given positive integers x and y.
			// Note that f(x, y) is increasing with respect to both x and y.
			// i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
			public int f(int x, int y) => throw new NotImplementedException(); 
		};
	}
}

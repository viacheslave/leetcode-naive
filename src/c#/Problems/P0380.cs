using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/insert-delete-getrandom-o1/
	///		Submission: https://leetcode.com/submissions/detail/241445267/
	/// </summary>
	internal class P0380
	{
		public class RandomizedSet
		{
			SortedDictionary<int, int> set = new SortedDictionary<int, int>();
			Random random = new Random((int)DateTime.Now.Ticks);

			/** Initialize your data structure here. */
			public RandomizedSet()
			{

			}

			/** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
			public bool Insert(int val)
			{
				if (set.ContainsKey(val))
					return false;

				set.Add(val, val);
				return true;
			}

			/** Removes a value from the set. Returns true if the set contained the specified element. */
			public bool Remove(int val)
			{
				if (set.ContainsKey(val))
				{
					set.Remove(val);
					return true;
				}

				return false;
			}

			/** Get a random element from the set. */
			public int GetRandom()
			{
				return set.Values.ToArray()[random.Next(set.Count)];
			}
		}
	}
}

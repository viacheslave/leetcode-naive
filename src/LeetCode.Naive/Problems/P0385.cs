using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/mini-parser/
	///		Submission: https://leetcode.com/submissions/detail/247041386/
	/// </summary>
	internal class P0385
	{
		/**
		 *		// This is the interface that allows for creating nested lists.
		 *		// You should not implement it, or speculate about its implementation
		 *		interface NestedInteger {
		 *
		 *     // Constructor initializes an empty nested list.
		 *     public NestedInteger();
		 *
		 *     // Constructor initializes a single integer.
		 *     public NestedInteger(int value);
		 *
		 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
		 *     bool IsInteger();
		 *
		 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
		 *     // Return null if this NestedInteger holds a nested list
		 *     int GetInteger();
		 *
		 *     // Set this NestedInteger to hold a single integer.
		 *     public void SetInteger(int value);
		 *
		 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
		 *     public void Add(NestedInteger ni);
		 *
		 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
		 *     // Return null if this NestedInteger holds a single integer
		 *     IList<NestedInteger> GetList();
		 *		}
		 */


		public NestedInteger Deserialize(string s)
		{
			return ParseObj(s).Item1;
		}

		private (NestedInteger, int) ParseObj(string s)
		{
			if (s[0] == '[')
			{
				var end = 0;
				var ni = new NestedInteger();

				do
				{
					var sub = s.Substring(1 + end);
					if (sub[0] == ']')
					{
						end += 1;
						break;
					}

					var res = ParseObj(sub);
					end += res.Item2 + 1;
					ni.Add(res.Item1);
				}
				while (end < s.Length && s[end] == ',');

				return (ni, end + 1);
			}
			else
			{
				return ParseAsSingle(s);
			}
		}

		private (NestedInteger, int) ParseAsSingle(string s)
		{
			var end = s.IndexOfAny(new char[] { '[', ']', ',' });
			if (end != -1)
				return (new NestedInteger(int.Parse(s.Substring(0, end))), end);
			return (new NestedInteger(int.Parse(s)), end);
		}
	}
}

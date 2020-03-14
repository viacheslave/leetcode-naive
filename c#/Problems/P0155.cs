using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/min-stack/
	///		Submission: https://leetcode.com/submissions/detail/226677256/
	/// </summary>
	internal class P0155
	{
		public class MinStack
		{

			int index = -1;

			List<int> stack = new List<int>();
			List<int> mins = new List<int>();

			/** initialize your data structure here. */
			public MinStack()
			{

			}

			public void Push(int x)
			{

				if (index < stack.Count - 1)
				{
					stack[index + 1] = x;
					mins[index + 1] = x;
				}
				else
				{
					stack.Add(x);
					mins.Add(x);
				}

				index++;

				if (index > 0)
				{
					if (mins[index - 1] < x)
					{
						mins[index] = mins[index - 1];
					}
				}

			}

			public void Pop()
			{
				index--;
			}

			public int Top()
			{
				return stack[index];
			}

			public int GetMin()
			{
				return mins[index];
			}
		}
	}
}

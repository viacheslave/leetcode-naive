using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/daily-temperatures/
	///		Submission: https://leetcode.com/submissions/detail/237129535/
	/// </summary>
	internal class P0739
	{
		public int[] DailyTemperatures(int[] T)
		{
			Stack<(int, int)> stack = new Stack<(int, int)>();
			stack.Push((T[0], 0));

			var res = new int[T.Length];

			for (var i = 1; i < T.Length; i++)
			{
				if (T[i] > T[i - 1])
				{
					if (stack.Count > 0)
					{
						while (stack.Count > 0)
						{
							var item = stack.Pop();
							if (T[i] > item.Item1)
							{
								res[item.Item2] = i - item.Item2;
							}
							else
							{
								stack.Push(item);
								break;
							}
						}
						stack.Push((T[i], i));
						continue;
					}

					stack.Pop();
					stack.Push((T[i], i));
					res[i - 1] = 1;
				}
				else
				{
					stack.Push((T[i], i));
				}
			}

			return res;
		}
	}
}

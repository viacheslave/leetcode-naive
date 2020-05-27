using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/linked-list-components/
	///		Submission: https://leetcode.com/submissions/detail/231292294/
	/// </summary>
	internal class P0817
	{
		public int NumComponents(ListNode head, int[] G)
		{
			var set = new HashSet<int>(G);
			var incomp = false;
			var count = 0;

			var current = head;
			while (current != null)
			{
				if (set.Contains(current.val))
				{
					if (!incomp)
					{
						incomp = true;
						count++;
					}
					else
					{
						incomp = true;
					}
				}
				else
				{
					incomp = false;
				}

				current = current.next;
			}

			return count;
		}
	}
}

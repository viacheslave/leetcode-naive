using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
	///		Submission: https://leetcode.com/submissions/detail/286082021/
	/// </summary>
	internal class P1290
	{
		public int GetDecimalValue(ListNode head)
		{
			var ans = 0;

			var current = head;
			while (current != null)
			{
				ans *= 2;
				ans += current.val;
				current = current.next;
			}

			return ans;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
	///		Submission: https://leetcode.com/submissions/detail/235222714/
	/// </summary>
	internal class P0082
	{
		public ListNode DeleteDuplicates(ListNode head)
		{
			if (head == null)
				return null;

			ListNode prevPointer = null;
			var current = head;
			var start = head;
			var end = head;
			var newHead = head;

			while (current != null)
			{
				var next = current.next;
				if (next == null)
				{
					if (start != end)
					{
						if (prevPointer != null)
							prevPointer.next = null;
						else
							newHead = null;
					}

					break;
				}

				if (current.val == next.val)
				{
					end = next;
				}
				else
				{
					if (start != end)
					{
						// remove duplicates
						if (prevPointer != null)
							prevPointer.next = next;
						else
							newHead = next;
					}
					else
					{
						prevPointer = current;
					}

					start = next;
					end = next;
				}

				current = current.next;
			}

			return newHead;
		}
	}
}

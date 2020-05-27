using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/split-linked-list-in-parts/
	///		Submission: https://leetcode.com/submissions/detail/239729709/
	/// </summary>
	internal class P0725
	{
		public ListNode[] SplitListToParts(ListNode root, int k)
		{
			var result = new ListNode[k];

			if (root == null)
				return result;

			var count = 1;
			var current = root;
			while (current.next != null)
			{
				count++;
				current = current.next;
			}

			var totalLength = count;
			var segmentLength = 0;
			var currentLength = 0;
			var segments = 0;

			current = root;

			while (current != null)
			{
				if (currentLength == 0)
				{
					if (k > totalLength) segmentLength = 1;
					else segmentLength = (totalLength / k) + (totalLength % k > 0 ? 1 : 0);

					result[segments] = current;

					segments++;
					currentLength++;
				}

				if (currentLength == segmentLength)
				{
					var last = current;
					current = current.next;
					last.next = null;

					totalLength -= segmentLength;
					k--;

					currentLength = 0;
					continue;
				}

				currentLength++;
				current = current.next;
			}

			return result;
		}
	}
}

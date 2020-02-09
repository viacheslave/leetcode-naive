using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/jump-game/
	///		Submission: https://leetcode.com/submissions/detail/228076772/
	/// </summary>
	internal class P0055
	{
		public bool CanJump(int[] nums)
		{
			if (nums.Length <= 1)
				return true;

			int index = nums.Length - 1;
			HashSet<int> seen = new HashSet<int>();

			while (index >= 0)
			{
				if (index == nums.Length - 1 || (seen.Contains(index) && nums[index] > 0))
				{
					for (var i = index - 1; i >= 0; i--)
					{
						if (nums[i] >= (index - i))
						{
							seen.Add(i);

							if (i == 0)
								return true;
						}
					}
				}

				index--;
			}

			return false;
		}
	}
}

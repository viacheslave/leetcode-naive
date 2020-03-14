using System.Linq;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-numbers-with-even-number-of-digits/
	///		Submission: https://leetcode.com/submissions/detail/288229785/
	/// </summary>
	internal class P1295
	{
		public int FindNumbers(int[] nums)
		{
			return nums.Count(num => num.ToString().Length % 2 == 0);
		}
	}
}

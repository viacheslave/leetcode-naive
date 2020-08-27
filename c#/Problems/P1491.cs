using System.Linq;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary/
	///		Submission: https://leetcode.com/submissions/detail/387147571/
	/// </summary>
	internal class P1491
	{
		public double Average(int[] salary)
		{
			return salary.OrderBy(c => c).Skip(1).Take(salary.Length - 2).Average();
		}
	}
}

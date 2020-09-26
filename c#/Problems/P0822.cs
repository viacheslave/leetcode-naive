using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/card-flipping-game/
	///		Submission: https://leetcode.com/submissions/detail/400994751/
	/// </summary>
	internal class P0822
	{
		public int Flipgame(int[] fronts, int[] backs)
		{
			var nonAnswers = new HashSet<int>();
			var frontNumbers = new HashSet<int>();

			for (int i = 0; i < fronts.Length; i++)
			{
				frontNumbers.Add(fronts[i]);

				if (fronts[i] == backs[i])
					nonAnswers.Add(fronts[i]);
			}

			frontNumbers.ExceptWith(nonAnswers);

			var minBack = int.MaxValue;

			for (int i = 0; i < fronts.Length; i++)
			{
				if (!frontNumbers.Contains(backs[i]) && !nonAnswers.Contains(backs[i]))
					minBack = Math.Min(minBack, backs[i]);
			}

			if (minBack == int.MaxValue && frontNumbers.Count == 0)
				return 0;

			if (frontNumbers.Count == 0)
				return minBack;

			return Math.Min(minBack, frontNumbers.Min());
		}
	}
}

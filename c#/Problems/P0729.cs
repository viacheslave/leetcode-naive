using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/my-calendar-i/
	///		Submission: https://leetcode.com/submissions/detail/235955114/
	/// </summary>
	internal class P0729
	{
		public class MyCalendar
		{
			private HashSet<(int, int)> _int = new HashSet<(int, int)>();

			public MyCalendar()
			{
			}

			public bool Book(int start, int end)
			{

				foreach (var (s, e) in _int)
				{
					var outer = (start <= s && s <= end - 1);
					var inner = (s <= start && end - 1 <= e);
					var over = (s <= end - 1 && e >= start);

					if (outer || inner || over)
						return false;
				}

				_int.Add((start, end - 1));
				return true;
			}
		}
	}
}

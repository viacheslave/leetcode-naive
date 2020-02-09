using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/task-scheduler/
	///		Submission: https://leetcode.com/submissions/detail/242506743/
	/// </summary>
	internal class P0621
	{
		public int LeastInterval(char[] tasks, int n)
		{
			var map = tasks.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
			var list = new List<char>();

			while (map.Count > 0)
			{
				var task = map.OrderByDescending(_ => _.Value).FirstOrDefault(_ => IsValid(_.Key, list, n));
				list.Add(task.Key);

				if (task.Key == default(char))
					continue;

				map[task.Key]--;
				if (map[task.Key] == 0)
					map.Remove(task.Key);
			}

			return list.Count;
		}

		private bool IsValid(char key, List<char> list, int n)
		{
			for (var pos = list.Count - 1; pos > list.Count - 1 - n; pos--)
			{
				if (pos < 0)
					return true;

				if (list[pos] == key)
					return false;
			}

			return true;
		}
	}
}

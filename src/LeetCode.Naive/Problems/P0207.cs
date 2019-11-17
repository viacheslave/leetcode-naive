using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/course-schedule/submissions/
	///		Submission: https://leetcode.com/submissions/detail/241687294/
	/// </summary>
	internal class P0207
	{
		public bool CanFinish(int numCourses, int[][] prerequisites)
		{
			var map = prerequisites
					.GroupBy(p => p[0])
					.ToDictionary(p => p.Key, p => new HashSet<int>(p.Select(_ => _[1])));

			for (int i = 0; i < numCourses; i++)
			{
				if (!map.ContainsKey(i))
					map[i] = new HashSet<int>();
			}

			foreach (var mapItem in map)
			{
				var visited = new HashSet<int>();

				var result = Traverse(mapItem.Key, map, visited);
				if (!result)
					return false;
			}

			return true;
		}

		private bool Traverse(int id, Dictionary<int, HashSet<int>> map, HashSet<int> visited)
		{
			visited.Add(id);

			var result = true;

			foreach (var item in map[id])
			{
				if (!visited.Contains(item))
					result = result && Traverse(item, map, visited);
				else return false;
			}

			visited.Remove(id);

			return result;
		}
	}
}

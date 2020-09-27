using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/evaluate-division/
	///		Submission: https://leetcode.com/submissions/detail/401312108/
	/// </summary>
	internal class P0399
	{
		public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
		{
			var map = new Dictionary<string, List<(string, double)>>();

			for (int i = 0; i < equations.Count; i++)
			{
				var eq = equations[i];
				var value = values[i];

				if (!map.ContainsKey(eq[0]))
					map[eq[0]] = new List<(string, double)>();

				if (!map.ContainsKey(eq[1]))
					map[eq[1]] = new List<(string, double)>();

				map[eq[0]].Add((eq[1], value));
				map[eq[1]].Add((eq[0], 1 / value));
			}

			var ans = new List<double>();

			foreach (var query in queries)
			{
				var res = Solve((query[0], query[1]), map);
				ans.Add(res);
			}

			return ans.ToArray();
		}

		private double Solve((string, string) p, Dictionary<string, List<(string, double)>> map)
		{
			var start = p.Item1;
			var end = p.Item2;

			if (!map.ContainsKey(start) || !map.ContainsKey(end))
				return -1;

			var visited = new HashSet<string>();
			var q = new Queue<(string Point, double Value, double Running)>();

			foreach (var way in map[start])
				q.Enqueue((way.Item1, way.Item2, 1));

			while (q.Count > 0)
			{
				var el = q.Dequeue();
				if (visited.Contains(el.Point))
					continue;

				visited.Add(el.Point);

				if (el.Point == end)
					return el.Running * el.Value;

				var running = el.Running * el.Value;

				foreach (var way in map[el.Point])
				{
					if (!visited.Contains(way.Item1))
						q.Enqueue((way.Item1, way.Item2, running));
				}
			}

			return -1;
		}
	}
}

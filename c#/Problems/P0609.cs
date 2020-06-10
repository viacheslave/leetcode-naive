using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-duplicate-file-in-system/
	///		Submission: https://leetcode.com/submissions/detail/282055764/
	/// </summary>
	internal class P0609
	{
		public IList<IList<string>> FindDuplicate(string[] paths)
		{
			var data = new Dictionary<string, string>();

			foreach (var path in paths)
			{
				var parts = path.Split(' ');
				if (parts.Length > 1)
				{
					for (int i = 1; i < parts.Length; i++)
					{
						var fileName = parts[i].Split('(')[0];
						var fileContent = parts[i].Split('(')[1].TrimEnd(')');
						var fullPath = $"{parts[0]}/{fileName}";

						data.Add(fullPath, fileContent);
					}
				}
			}

			var ans = data.GroupBy(d => d.Value)
					.Select(x => (IList<string>)x.ToArray().Select(f => f.Key).ToList());

			return ans.Where(a => a.Count > 1).ToList();
		}
	}
}

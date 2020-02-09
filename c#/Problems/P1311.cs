using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/get-watched-videos-by-your-friends/
	///		Submission: https://leetcode.com/submissions/detail/299289223/
	/// </summary>
	internal class P1311
	{
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
      var friendsMap = friends
          .Select((x, i) => (i, x))
          .ToDictionary(x => x.i, x => x.x.ToList());

      var visited = new Dictionary<int, int>();
      var q = new Queue<(int id, int level)>();

      q.Enqueue((id, 0));
      while (q.Count > 0)
      {
        var item = q.Dequeue();
        if (visited.ContainsKey(item.id))
        {
          if (visited[item.id] > item.level)
            visited[item.id] = item.level;

          continue;
        }

        visited[item.id] = item.level;

        if (item.level == level)
          continue;

        foreach (var friend in friendsMap[item.id])
          q.Enqueue((friend, item.level + 1));
      }

      var selected = visited.Where(v => v.Value == level).Select(x => x.Key).ToHashSet();

      var videos = watchedVideos
          .Select((list, index) => (index, list))
          .Where(x => selected.Contains(x.index))
          .SelectMany(x => x.list)
          .ToList();

      var freqs = videos
          .GroupBy(v => v)
          .Select(v => (v.Key, v.Count()))
          .OrderBy(v => v.Item2)
          .ThenBy(v => v.Key)
          .Select(v => v.Key)
          .ToList();

      return freqs;
    }
  }
}

using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/course-schedule-ii/
  ///    Submission: https://leetcode.com/submissions/detail/428217332/
  /// </summary>
  internal class P0210
  {
    public class Solution
    {
      public int[] FindOrder(int numCourses, int[][] prerequisites)
      {
        // Kahn

        var count = 0;
        var indegree = new int[numCourses];
        var vertices = new Dictionary<int, List<int>>();
        var queue = new Queue<int>();
        var top = new List<int>();

        for (var i = 0; i < numCourses; i++)
          vertices.Add(i, new List<int>());

        foreach (var pre in prerequisites)
        {
          vertices[pre[1]].Add(pre[0]);
          indegree[pre[0]]++;
        }

        for (var i = 0; i < indegree.Length; i++)
          if (indegree[i] == 0)
            queue.Enqueue(i);

        while (queue.Count > 0)
        {
          var vertex = queue.Dequeue();
          top.Add(vertex);
          count++;

          foreach (var next in vertices[vertex])
          {
            indegree[next]--;
            if (indegree[next] == 0)
              queue.Enqueue(next);
          }
        }

        if (count != numCourses)
          return Array.Empty<int>();

        return top.ToArray();
      }
    }
  }
}

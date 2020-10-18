using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/copy-list-with-random-pointer/
  ///    Submission: https://leetcode.com/submissions/detail/242577709/
  /// </summary>
  internal class P0138
  {
    public class Solution
    {
      public NodeRandom CopyRandomList(NodeRandom head)
      {
        if (head == null)
          return null;

        var source = head;
        var target = new NodeRandom() { val = source.val };
        var map = new Dictionary<NodeRandom, NodeRandom> { [source] = target };
        var result = target;

        while (source != null)
        {
          if (source.next != null)
          {
            var sourceNext = source.next;
            var targetNext = map.ContainsKey(sourceNext)
                ? map[sourceNext]
                : new NodeRandom { val = sourceNext.val };

            target.next = targetNext;
            map[sourceNext] = targetNext;
          }

          if (source.random != null)
          {
            var sourceRandom = source.random;
            var targetRandom = map.ContainsKey(sourceRandom)
                ? map[sourceRandom]
                : new NodeRandom { val = sourceRandom.val };

            target.random = targetRandom;
            map[sourceRandom] = targetRandom;
          }

          source = source.next;
          target = target.next;
        }

        return result;
      }
    }
  }
}

using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/stamping-the-sequence/
  ///    Submission: https://leetcode.com/submissions/detail/470531170/
  /// </summary>
  internal class P0936
  {
    public class Solution
    {
      public int[] MovesToStamp(string stamp, string target)
      {
        var ans = new Stack<int>();
        var q = new Queue<int>();
        var ls = new List<Window>(1 + target.Length - stamp.Length);
        var stamped = new bool[target.Length];
        var indiciesStamped = 0;

        for (var i = 0; i <= target.Length - stamp.Length; i++)
        {
          var complete = new HashSet<int>();
          var toComplete = new HashSet<int>();
          
          for (int j = 0; j < stamp.Length; j++)
            if (target[i + j] == stamp[j])
              complete.Add(i + j);
            else
              toComplete.Add(i + j);

          ls.Add(new Window(complete, toComplete));

          if (toComplete.Count == 0)
          {
            ans.Push(i);

            foreach (int index in complete)
            {
              if (!stamped[index])
              {
                indiciesStamped++;
                q.Enqueue(index);
                stamped[index] = true;
              }
            }
          }
        }

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          
          for (int k = Math.Max(0, 1 + item - stamp.Length); k <= Math.Min(target.Length - stamp.Length, item); k++)
          {
            if (ls[k].ToComplete.Contains(item))
            {
              ls[k].ToComplete.Remove(item);
              ls[k].Complete.Add(item);
              
              if (ls[k].ToComplete.Count == 0)
              {
                ans.Push(k);                        

                foreach (int index in ls[k].Complete)
                {
                  if (!stamped[index])
                  {
                    indiciesStamped++;
                    q.Enqueue(index);
                    stamped[index] = true;
                  }
                }
              }
            }
          }

          if (indiciesStamped == target.Length) 
            break;
        }

        if (indiciesStamped < target.Length)
          return Array.Empty<int>();

        var result = new int[ans.Count];
        
        var t = 0;
        while (ans.Count > 0) 
          result[t++] = ans.Pop();

        return result;
      }

      public class Window
      {
        public HashSet<int> Complete;
        public HashSet<int> ToComplete;

        public Window(HashSet<int> complete, HashSet<int> toComplete)
        {
          Complete = complete;
          ToComplete = toComplete;
        }
      }
    }
  }
}


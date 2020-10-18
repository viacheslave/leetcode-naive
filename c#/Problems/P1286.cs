using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/iterator-for-combination/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/290527497/
  /// </summary>
  internal class P1286
  {
    public class CombinationIterator
    {
      private readonly int combinationLength;
      private readonly IEnumerator<string> enumerator;
      private readonly List<char> chars;
      private string last;
      private string lastPossible;

      public CombinationIterator(string characters, int combinationLength)
      {
        chars = characters.ToList();
        this.combinationLength = combinationLength;

        lastPossible = new string(characters.TakeLast(combinationLength).ToArray());

        enumerator = Get(new List<char>(), 0).GetEnumerator();
        }

      public string Next()
      {
        if (enumerator.MoveNext())
        {
          last = enumerator.Current;
          return last;
          }

        return null;
        }

      private IEnumerable<string> Get(List<char> result, int index)
      {
        if (result.Count == combinationLength)
          yield return new string(result.ToArray());

        for (var i = index; i < chars.Count; i++)
        {
          result.Add(chars[i]);

          foreach (var res in Get(result, i + 1))
            yield return res;

          result.RemoveAt(result.Count - 1);
          }
        }

      public bool HasNext()
      {
        return last == null || last != lastPossible;
        }
      }
    }
}

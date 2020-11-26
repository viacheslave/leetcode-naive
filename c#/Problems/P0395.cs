using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/
  ///    Submission: https://leetcode.com/submissions/detail/424294792/
  /// </summary>
  internal class P0395
  {
    public class Solution
    {
      public class Entry : IComparable<Entry>, IEquatable<Entry>
      {
        public char Char { get; }
        public int Freq { get; }

        public Entry(char ch, int freq)
        {
          Char = ch;
          Freq = freq;
        }

        public int CompareTo(Entry other)
        {
          if (Freq < other.Freq)
            return -1;
          if (Freq > other.Freq)
            return 1;

          return Char.CompareTo(other.Char);
        }

        public bool Equals(Entry other) => Freq == other.Freq && Char == other.Char;

        public override bool Equals(object obj) => ((Entry)obj).Freq == Freq && ((Entry)obj).Char == Char;

        public override int GetHashCode() => HashCode.Combine(Char, Freq);
      }

      public int LongestSubstring(string s, int k)
      {
        var missingCh = s
          .GroupBy(ch => ch)
          .Where(x => x.Count() < k)
          .Select(x => x.Key)
          .ToHashSet();

        var chmap = new Dictionary<char, int>();
        var freq = new SortedList<Entry, int>();

        var ans = 0;

        for (var left = 0; left < s.Length; left++)
        {
          chmap = new Dictionary<char, int>();
          freq = new SortedList<Entry, int>(
            chmap.ToDictionary(x => new Entry(x.Key, x.Value), x => x.Value));

          for (var right = left; right < s.Length; right++)
          {
            if (missingCh.Contains(s[right]))
              break;

            if (!chmap.ContainsKey(s[right]))
            {
              chmap[s[right]] = 1;
              freq.Add(new Entry(s[right], 1), 1);
            }
            else
            {
              var f = chmap[s[right]];

              chmap[s[right]]++;
              freq.Remove(new Entry(s[right], f));
              freq.Add(new Entry(s[right], f + 1), f + 1);
            }

            if (right - left + 1 < ans)
              continue;

            if (freq.Keys[0].Freq >= k)
              ans = Math.Max(ans, right - left + 1);
          }
        }

        return ans;
      }
    }
  }
}

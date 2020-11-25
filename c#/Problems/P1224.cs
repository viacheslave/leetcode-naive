using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-equal-frequency/
  ///    Submission: https://leetcode.com/submissions/detail/423944245/
  /// </summary>
  internal class P1224
  {
    public class Solution
    {
      public class Entry : IComparable<Entry>, IEqualityComparer<Entry>
      {
        public int Value { get; }
        public int Freq { get; }

        public Entry(int value, int freq)
        {
          Value = value;
          Freq = freq;
        }

        public int CompareTo(Entry other)
        {
          var r = Freq.CompareTo(other.Freq);
          return (r == 0) ? Value.CompareTo(other.Value) : r;
        }

        public bool Equals(Entry x, Entry y) => x.Value == y.Value;

        public int GetHashCode(Entry obj) => Value.GetHashCode();

        public override bool Equals(object obj) => (obj as Entry).Value == Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"{Value} - {Freq} times";
      }

      public int MaxEqualFreq(int[] nums)
      {
        var frequencies = nums
          .GroupBy(v => v)
          .ToDictionary(
            v => v.Key,
            v => v.Count());

        var sortedlist = new SortedList<Entry, int>(
          nums
            .GroupBy(v => v)
            .ToDictionary(
              v => new Entry(v.Key, v.Count()),
              v => v.Count())
          );

        var index = nums.Length - 1;

        while (sortedlist.Count > 0)
        {
          if (sortedlist.Count == 1)
            return sortedlist.Keys[0].Freq;

          var first = sortedlist.Keys[0];
          var last = sortedlist.Keys[^1];

          // if all have the same frequencies, but the last is +1
          if (last.Freq - first.Freq == 1)
          {
            if (first.Freq == sortedlist.Keys[^2].Freq)
              return sortedlist.Keys[0].Freq * sortedlist.Count + 1;
          }

          // if all have the same frequences, but the first is 1
          if (first.Freq == 1)
          {
            if (sortedlist.Keys[1].Freq == last.Freq)
              return sortedlist.Keys[1].Freq * (sortedlist.Count - 1) + 1;
          }

          var el = nums[index];
          var entry = new Entry(nums[index], frequencies[nums[index]]);

          if (entry.Freq == 1)
          {
            frequencies.Remove(entry.Value);
            sortedlist.Remove(entry);
          }
          else
          {
            frequencies[entry.Value]--;
            sortedlist.Remove(entry);

            var newEntry = new Entry(entry.Value, frequencies[entry.Value]);
            sortedlist.Add(newEntry, newEntry.Freq);
          }

          index--;
        }

        return -1;
      }
    }
  }
}

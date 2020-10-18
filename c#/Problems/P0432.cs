using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/all-oone-data-structure/
  ///    Submission: https://leetcode.com/submissions/detail/244919893/
  /// </summary>
  internal class P0432
  {
    public class Solution
    {
      public class AllOne
      {

        Dictionary<string, int> _kv = new Dictionary<string, int>();
        SortedList<int, HashSet<string>> _vk = new SortedList<int, HashSet<string>>();

        /** Initialize your data structure here. */
        public AllOne()
        {

        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
          if (!_kv.ContainsKey(key))
            _kv[key] = 0;

          var value = _kv[key];

          if (!_vk.ContainsKey(value))
            _vk[value] = new HashSet<string>();
          if (!_vk.ContainsKey(value + 1))
            _vk[value + 1] = new HashSet<string>();

          _kv[key] = value + 1;

          _vk[value].Remove(key);
          if (_vk[value].Count == 0)
            _vk.Remove(value);

          _vk[value + 1].Add(key);
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
          if (!_kv.ContainsKey(key))
            return;

          var value = _kv[key];

          if (value == 1)
          {
            _kv.Remove(key);
            _vk[value].Remove(key);
            if (_vk[value].Count == 0)
              _vk.Remove(value);

            return;
          }

          _kv[key] = value - 1;

          _vk[value].Remove(key);
          if (_vk[value].Count == 0)
            _vk.Remove(value);

          if (!_vk.ContainsKey(value - 1))
            _vk[value - 1] = new HashSet<string>();
          _vk[value - 1].Add(key);
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
          if (_vk.Count > 0)
          {
            int key = _vk.Keys[_vk.Keys.Count - 1];
            var values = _vk[key];

            return values.Count > 0 ? values.First() : "";
          }

          return "";
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
          if (_vk.Count > 0)
          {
            int key = _vk.Keys[0];
            var values = _vk[key];

            return values.Count > 0 ? values.First() : "";
          }

          return "";
        }
      }
    }
  }
}

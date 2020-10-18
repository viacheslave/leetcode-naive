using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/accounts-merge/
  ///    Submission: https://leetcode.com/submissions/detail/394302552/
  /// </summary>
  internal class P0721
  {
    public class Solution
    {
      public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
      {
        var map = new Dictionary<string, int>();
        var mapById = new Dictionary<int, HashSet<string>>();

        for (var i = 0; i < accounts.Count; i++)
        {
          var account = accounts[i];

          for (var j = 1; j < account.Count; j++)
          {
            var email = account[j];

            if (!map.ContainsKey(email))
            {
              map[email] = i;

              if (!mapById.ContainsKey(i))
                mapById[i] = new HashSet<string>();

              mapById[i].Add(email);
              continue;
            }

            // update existing
            var id = map[email];

            if (i == id)
              continue;

            var gr = mapById[id];

            if (!mapById.ContainsKey(i))
              mapById[i] = new HashSet<string>();

            foreach (var key in gr)
            {
              map[key] = i;
              mapById[i].Add(key);
            }

            mapById.Remove(id);

            map[email] = i;
            mapById[i].Add(email);
          }
        }

        return mapById
            .Select(entry =>
            {
              var name = accounts[entry.Key][0];

              var list = new List<string>() { name };
              list.AddRange(entry.Value.OrderBy(f => f, StringComparer.Ordinal));

              return (IList<string>)list;
            })
            .ToList();
      }
    }
  }
}

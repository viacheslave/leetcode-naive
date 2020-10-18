using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/display-table-of-food-orders-in-a-restaurant/
  ///    Submission: https://leetcode.com/submissions/detail/327640598/
  /// </summary>
  internal class P1418
  {
    public class Solution
    {
      public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
      {
        var map = new Dictionary<(string table, string food), int>();

        foreach (var order in orders)
        {
          var table = order[1];
          var food = order[2];

          if (!map.ContainsKey((table, food)))
            map[(table, food)] = 0;

          map[(table, food)]++;
        }

        var foods = map.Keys.Select(d => d.food).Distinct().OrderBy(d => d, StringComparer.Ordinal).ToList();
        var firstRow = new List<string>() { "Table" };
        firstRow.AddRange(foods);

        var rows = new List<List<string>>() { firstRow };
        foreach (var item in map.GroupBy(x => x.Key.table).OrderBy(x => int.Parse(x.Key)).ToList())
        {
          var table = item.Key;
          var values = item.ToDictionary(x => x.Key.food, x => x.Value);

          var row = new List<string> { table };

          foreach (var food in foods)
          {
            var v = 0;
            if (values.ContainsKey(food))
              v = values[food];

            row.Add(v.ToString());
          }

          rows.Add(row);
        }

        var ans = new List<IList<string>>();
        ans.AddRange(rows);

        return ans;
      }
    }
  }
}

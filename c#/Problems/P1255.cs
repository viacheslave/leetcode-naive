using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-score-words-formed-by-letters/
  ///    Submission: https://leetcode.com/submissions/detail/418414578/
  /// </summary>
  internal class P1255
  {
    public class Solution
    {
      int _max = int.MinValue;

      public int MaxScoreWords(string[] words, char[] letters, int[] score)
      {
        var wordsSet = words.ToList();
        var lettersMap = letters.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var scoreMap = score.Select((rank, ch) => (97 + ch, rank)).ToDictionary(x => (char)x.Item1, x => x.rank);

        var usedWordsIndexes = Enumerable.Range(0, wordsSet.Count).ToHashSet();

        DFS(wordsSet, usedWordsIndexes, lettersMap, scoreMap, 0, new HashSet<int>());

        return _max;
      }

      private void DFS(List<string> wordsSet, HashSet<int> usedWordsIndexes, Dictionary<char, int> lettersMap, Dictionary<char, int> scoreMap, int score, HashSet<int> set)
      {
        foreach (var index in usedWordsIndexes.ToArray())
        {
          var wordCh = GetWordCh(wordsSet[index]);

          if (Fits(wordCh, lettersMap))
          {
            set.Add(index);
            usedWordsIndexes.Remove(index);

            foreach (var entry in wordCh)
              lettersMap[entry.Key] -= entry.Value;

            var extra = GetScore(wordCh, scoreMap);
            DFS(wordsSet, usedWordsIndexes, lettersMap, scoreMap, score + extra, set);

            foreach (var entry in wordCh)
              lettersMap[entry.Key] += entry.Value;

            usedWordsIndexes.Add(index);
            set.Remove(index);
          }
        }

        _max = Math.Max(_max, score);
      }

      private int GetScore(Dictionary<char, int> wordCh, Dictionary<char, int> scoreMap)
      {
        return wordCh.Select(x => scoreMap[x.Key] * x.Value).Sum();
      }

      private bool Fits(Dictionary<char, int> wordCh, Dictionary<char, int> lettersMap)
      {
        foreach (var entry in wordCh)
          if (!lettersMap.ContainsKey(entry.Key) || lettersMap[entry.Key] < entry.Value)
            return false;

        return true;
      }

      private Dictionary<char, int> GetWordCh(string word)
      {
        return word.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      }
    }
  }
}

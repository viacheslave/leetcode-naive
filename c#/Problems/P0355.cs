using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/design-twitter/
	///		Submission: https://leetcode.com/submissions/detail/241510439/
	/// </summary>
	internal class P0355
	{
		public class Twitter
		{
			Dictionary<int, HashSet<int>> _foll = new Dictionary<int, HashSet<int>>();
			Dictionary<int, List<(DateTime, int)>> _tweets = new Dictionary<int, List<(DateTime, int)>>();


			/** Initialize your data structure here. */
			public Twitter()
			{

			}

			/** Compose a new tweet. */
			public void PostTweet(int userId, int tweetId)
			{
				if (!_tweets.ContainsKey(userId))
					_tweets[userId] = new List<(DateTime, int)>();

				_tweets[userId].Add((DateTime.UtcNow, tweetId));
			}

			/** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
			public IList<int> GetNewsFeed(int userId)
			{
				return
						(
							 (_foll.ContainsKey(userId) ? _foll[userId] : new HashSet<int>())

							 .SelectMany(u => _tweets.ContainsKey(u) ? _tweets[u] : new List<(DateTime, int)>())
						)
						.Union(_tweets.ContainsKey(userId) ? _tweets[userId] : new List<(DateTime, int)>())
						.OrderByDescending(_ => _.Item1)
						.Take(10)
						.Select(_ => _.Item2)
						.ToList();
			}

			/** Follower follows a followee. If the operation is invalid, it should be a no-op. */
			public void Follow(int followerId, int followeeId)
			{
				if (!_foll.ContainsKey(followerId))
					_foll[followerId] = new HashSet<int>();

				_foll[followerId].Add(followeeId);
			}

			/** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
			public void Unfollow(int followerId, int followeeId)
			{
				if (!_foll.ContainsKey(followerId))
					_foll[followerId] = new HashSet<int>();

				_foll[followerId].Remove(followeeId);
			}
		}
	}
}

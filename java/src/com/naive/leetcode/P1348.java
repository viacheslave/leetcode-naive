package com.naive.leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/tweet-counts-per-frequency/
 * Submission: https://leetcode.com/submissions/detail/378366434/
 */
public class P1348 {
    class TweetCounts {

        private HashMap<String, ArrayList<Integer>> map =
                new HashMap<>();

        public TweetCounts() {

        }

        public void recordTweet(String tweetName, int time) {
            map.putIfAbsent(tweetName, new ArrayList<>());
            map.get(tweetName).add(time);
        }

        public List<Integer> getTweetCountsPerFrequency(String freq, String tweetName, int startTime, int endTime) {
            if (!map.containsKey(tweetName))
                return new ArrayList<>();

            var times = map.get(tweetName);

            var values = new TreeMap<Integer, Integer>();

            for (var time : times) {
                if (startTime <= time && time <= endTime) {
                    var index = getKey(freq, time - startTime);

                    values.putIfAbsent(index, 0);
                    values.put(index, values.get(index) + 1);
                }
            }

            var ans = new ArrayList<Integer>();

            var startKey = getKey(freq, startTime - startTime);
            var endKey = getKey(freq, endTime - startTime);

            for (var i = startKey; i <= endKey; i++) {
                if (values.containsKey(i))
                    ans.add(values.get(i));
                else
                    ans.add(0);
            }

            return ans;
        }

        private int getKey(String freq, int value) {
            if (freq.equals("minute")) {
                return value / 60;
            } else if (freq.equals("hour")) {
                return value  / 3600;
            } else {
                return value  / 86400;
            }
        }
    }

    /**
     * Your TweetCounts object will be instantiated and called as such:
     * TweetCounts obj = new TweetCounts();
     * obj.recordTweet(tweetName,time);
     * List<Integer> param_2 = obj.getTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
     */
}

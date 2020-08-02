package com.naive.leetcode;

import java.util.HashMap;
import java.util.Map;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/online-election/
 * Submission: https://leetcode.com/submissions/detail/375101438/
 */
class P0911 {
    class TopVotedCandidate {

        private HashMap<Integer, Integer> _votes;
        private TreeMap<Integer, Integer> _timed;

        private Map.Entry<Integer, Integer> _max;


        public TopVotedCandidate(int[] persons, int[] times) {
            _votes = new HashMap<>();
            _timed = new TreeMap<>();

            for (int i = 0; i < persons.length; ++i) {
                int vote = persons[i];
                int time = times[i];

                _votes.putIfAbsent(vote, 0);
                _votes.put(vote, _votes.get(vote) + 1);

                var current = _votes.get(vote);
                if (_max == null || current >= _max.getValue().intValue())
                    _max = new MyEntry(vote, current);

                _timed.put(time, _max.getKey());
            }
        }

        public int q(int t) {
            return _timed.floorEntry(t).getValue();
        }

        final class MyEntry<K, V> implements Map.Entry<K, V> {
            private final K key;
            private V value;

            public MyEntry(K key, V value) {
                this.key = key;
                this.value = value;
            }

            @Override
            public K getKey() {
                return key;
            }

            @Override
            public V getValue() {
                return value;
            }

            @Override
            public V setValue(V value) {
                V old = this.value;
                this.value = value;
                return old;
            }
        }
    }

    /**
     * Your TopVotedCandidate object will be instantiated and called as such:
     * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
     * int param_1 = obj.q(t);
     */
}
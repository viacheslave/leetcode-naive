package com.naive.leetcode;

import java.util.*;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) {
	      var r2 = new Solution().largestComponentSize(new int[] {1,2,3,4,5,6,7,8,9});
    }

    public static class Solution {
        private int[] _components = new int[100_001];
        private int[] _ranks = new int[100_001];
        private int _ans;

        public int largestComponentSize(int[] A) {
            Arrays.sort(A);

            for (var i = 0; i < 100_001; i++) {
                _components[i] = i;
                _ranks[i] = 1;
            }

            var primes = getPrimes(100_000);

            var map = new HashMap<Integer, ArrayList<Integer>>();

            for (var a : A) {
                var num = a;
                for (var prime : primes) {
                    if (prime > num)
                        break;

                    if (num % prime == 0) {
                        map.putIfAbsent(prime, new ArrayList<>());
                        map.get(prime).add(a);

                        num /= prime;
                    }
                }
            }

            for (var entry : map.entrySet()) {
                var values = entry.getValue();
                for (var i = 0; i < values.size() - 1; i++) {
                    union(values.get(i), values.get(i + 1));
                }
            }

            return _ans;
        }

        private int find(int x) {
            if (_components[x] != x)
                _components[x] = find(_components[x]);

            return _components[x];
        }

        private void union(int x, int y) {
            int px = find(x);
            int py = find(y);

            if (px != py) {
                if (_ranks[px] <= _ranks[py]) {
                    _components[px] = py;
                    _ranks[py] += _ranks[px];
                    _ans = Math.max(_ans, _ranks[py]);
                }
                else {
                    _components[py] = px;
                    _ranks[px] += _ranks[py];
                    _ans = Math.max(_ans, _ranks[px]);
                }
            }
        }

        private List<Integer> getPrimes(int n) {
            var ans = new ArrayList<Integer>();

            for (var i = 2; i <= n; i++) {
                var isPrime = true;

                for (var el : ans) {
                    if (el * el <= i && i % el == 0) {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    ans.add(i);
            }

            return ans;
        }
    }
}

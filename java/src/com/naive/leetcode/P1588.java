package com.naive.leetcode;

/**
 * Problem: https://leetcode.com/problems/sum-of-all-odd-length-subarrays/
 * Submission: https://leetcode.com/submissions/detail/399258336/
 */
public class P1588 {
    class Solution {
        public int sumOddLengthSubarrays(int[] arr) {
            var ans = 0;
            
            for (var i = 0; i < arr.length; i++) {
                var runningSum = 0;
                
                for (var j = i; j < arr.length; j++) {
                    runningSum += arr[j];
                    
                    if ((j - i) % 2 == 0)
                        ans += runningSum;
                }
            }
            
            return ans;
        }
    }
}

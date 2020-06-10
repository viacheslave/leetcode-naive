package com.naive.leetcode;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/product-of-the-last-k-numbers/
 * Submission: https://leetcode.com/submissions/detail/303785593/
 */
class P1352 {
    int pref[] = new int[40000];
    int index = 0;
    
    public P1352() {
        
    }
    
    public void add(int num) {
        pref[index] = num;

		for (int i = 0; i < index; i++) {
			if (num == 0)
				pref[i] = 0;
			else
				pref[i] *= num;
		}

		index += 1;
    }
    
    public int getProduct(int k) {
        return pref[index - k];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.add(num);
 * int param_2 = obj.getProduct(k);
 */
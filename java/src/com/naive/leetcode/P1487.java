package com.naive.leetcode;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Problem: https://leetcode.com/problems/making-file-names-unique/
 * Submission: https://leetcode.com/submissions/detail/365095331/
 */
public class P1487 {
    class Solution {
        public String[] getFolderNames(String[] names) {
            var ans = new ArrayList<String>();
            var set = new HashMap<String, Integer>();

            for (String name : names) {
                if (!set.containsKey(name)) {
                    ans.add(name);
                    set.put(name, 1);
                    continue;
                }

                var index = set.get(name).intValue();

                while (set.containsKey(name + "(" + index + ")")) {
                    index++;
                }


                var candidate = name + "(" + index + ")";
                ans.add(candidate);

                set.put(candidate, 1);
                set.put(name, index + 1);
            }

            return ans.toArray(new String[ans.size()]);
        }
    }
}

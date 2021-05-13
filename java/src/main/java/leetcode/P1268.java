package leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Problem: https://leetcode.com/problems/search-suggestions-system/
 * Submission: https://leetcode.com/submissions/detail/387737613/
 */
public class P1268 {
    class Solution {
        public List<List<String>> suggestedProducts(String[] products, String searchWord) {
            Arrays.sort(products);

            var ans = new ArrayList<List<String>>();

            for (int i = 1; i <= searchWord.length(); i++)
            {
                var input = searchWord.substring(0, i);

                var list = Arrays.stream(products)
                    .filter(p -> p.startsWith(input))
                    .limit(3)
                    .collect(Collectors.toList());

                ans.add(list);
            }

            return ans;
        }
    }
}

package leetcode;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/employee-importance/
 * Submission: https://leetcode.com/submissions/detail/234432683/
 */
class P0690 {
    class Solution {
        public int getImportance(List<Employee> employees, int id) {
            HashSet<Integer> processed = new HashSet<Integer>();

            HashMap<Integer, Employee> all = new HashMap<Integer, Employee>();
            for (Employee i : employees)
                all.put(i.id, i);

            return Calc(all, processed, id);
        }

        private int Calc(HashMap<Integer, Employee> all, HashSet<Integer> processed, Integer id) {
            if (processed.contains(id))
                return 0;

            Employee e = all.get(id);

            processed.add(e.id);
            Integer imp = e.importance;

            for (Integer i : e.subordinates)
                imp += Calc(all, processed, i);

            return imp;
        }
    }
}
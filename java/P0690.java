using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/submissions/detail/234432683/
	///		Submission: https://leetcode.com/submissions/detail/238079511/
	/// </summary>
	internal class P0690
	{
		/*
		// Employee info
		class Employee {
				// It's the unique id of each node;
				// unique id of this employee
				public int id;
				// the importance value of this employee
				public int importance;
				// the id of direct subordinates
				public List<Integer> subordinates;
		};
		*/

		/*
		public int getImportance(List<Employee> employees, int id) 
    {
        HashSet<Integer> processed = new HashSet<Integer>();
        
        HashMap<Integer, Employee> all = new HashMap<Integer, Employee>();
        for (Employee i : employees) 
            all.put(i.id, i);
        
        return Calc(all, processed, id);
    }
    
    private int Calc(HashMap<Integer, Employee> all, HashSet<Integer> processed, Integer id)
    {
        if (processed.contains(id))
            return 0;
        
        Employee e = all.get(id);
        
        processed.add(e.id);
        Integer imp = e.importance;
        
        for (Integer i : e.subordinates)
            imp += Calc(all, processed, i);
        
        return imp;
    }
		*/
	}
}

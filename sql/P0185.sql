/*
Problem: https://leetcode.com/problems/department-top-three-salaries/
Submission: https://leetcode.com/submissions/detail/432049234/
*/

/* Write your T-SQL query statement below */

SELECT 
  dep.Name AS Department,
  emp.Name AS Employee,
  emp.Salary AS Salary
FROM Employee emp
JOIN Department dep ON emp.DepartmentId = dep.Id
JOIN
(
  SELECT DISTINCT f.salary, e.departmentid
  FROM Employee e
  CROSS APPLY (
    /* Here we select all top distinct salaries by department */
    SELECT DISTINCT TOP 3 d.salary
    FROM Employee d
    WHERE d.DepartmentId = e.DepartmentId
    ORDER BY d.salary DESC
  ) f
) j
ON emp.Salary = j.Salary AND emp.DepartmentId = j.departmentid

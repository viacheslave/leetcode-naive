/*
https://leetcode.com/problems/department-highest-salary/
https://leetcode.com/submissions/detail/226317002/
*/

/* Write your T-SQL query statement below */
select 
  d.name as [Department],
  e.Name as [Employee],
  a.MaxSalary as [Salary]
from Employee e
  join Department d on e.DepartmentId = d.Id
  join (
    select 
      d.Id as DepartmentId,
      max(e.Salary) as MaxSalary
    from Employee e
      join Department d on e.DepartmentId = d.Id
    group by d.Id
  ) a on a.DepartmentId = d.Id and e.Salary = a.MaxSalary
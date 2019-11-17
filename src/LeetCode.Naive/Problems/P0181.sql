/*
https://leetcode.com/problems/employees-earning-more-than-their-managers/
https://leetcode.com/submissions/detail/226272413/
*/

select e1.Name as [Employee]
from Employee e1
  join Employee e2 on e1.ManagerId = e2.Id
where e1.Salary > e2.Salary
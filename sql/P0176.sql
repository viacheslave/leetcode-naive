/*
https://leetcode.com/problems/second-highest-salary/
https://leetcode.com/submissions/detail/226298078/
*/

/* Write your T-SQL query statement below */

select s.SecondHighestSalary
from

(select 2 as row_number) a
left join
(
  select 
    salary as SecondHighestSalary,
    (row_number() OVER (ORDER BY salary desc)) as row_number
  from Employee
  group by salary
) s on s.row_number = a.row_number
/*
Problem: https://leetcode.com/problems/classes-more-than-5-students/
Submission: https://leetcode.com/submissions/detail/226280390/
*/

/* Write your T-SQL query statement below */
select f.class 
from (select distinct student, class from courses) f
group by f.class
having count(*) >= 5
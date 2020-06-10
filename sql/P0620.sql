/*
Problem: https://leetcode.com/problems/not-boring-movies/
Submission: https://leetcode.com/submissions/detail/226174667/
*/

/* Write your T-SQL query statement below */
select* from cinema
where id % 2 = 1
and description not like 'boring'
order by rating desc

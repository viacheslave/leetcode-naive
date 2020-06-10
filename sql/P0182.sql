/*
https://leetcode.com/problems/duplicate-emails/
https://leetcode.com/submissions/detail/226176437/
*/

/* Write your T-SQL query statement below */
select p.email as Email from Person p group by p.email having count(*) >1
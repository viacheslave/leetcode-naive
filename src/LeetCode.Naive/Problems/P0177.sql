/*
https://leetcode.com/problems/nth-highest-salary/
https://leetcode.com/submissions/detail/226299987/
*/

/* Write your T-SQL query statement below */

CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        select s.HighestSalary
        from

         (select @N as row_number) a
         left join
         (
            select 
              salary as HighestSalary,
              (row_number() OVER (ORDER BY salary desc)) as row_number
            from Employee
            group by salary
         ) s on s.row_number = a.row_number
        
    );
END
/*
Problem: https://leetcode.com/problems/exchange-seats/
Submission: https://leetcode.com/submissions/detail/235459441/
*/

/* Write your T-SQL query statement below */
SELECT
    ROW_NUMBER() OVER (ORDER BY (CASE WHEN [Id] % 2 = 0 THEN [Id] - 1 ELSE [Id] + 1 END)) AS [id],
    [Student] AS [student]
FROM [seat]
ORDER BY 1

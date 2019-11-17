/*
Problem: https://leetcode.com/problems/trips-and-users/
Submission: https://leetcode.com/submissions/detail/226325707/
*/
select
	t.Request_at as [Day],
		round(count(case when t.Status != 'completed' then 1 end) * 1.0 / count(*), 2) as [Cancellation Rate]
	from Trips t
		join Users c on t.Client_id = c.Users_id and c.Role = 'client' and c.Banned = 'No'
		join Users d on t.Driver_Id = d.Users_id and d.Role = 'driver' and d.Banned = 'No'
	where t.Request_at between '2013-10-01' and '2013-10-03'
group by t.Request_at
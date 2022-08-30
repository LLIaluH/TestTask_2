SELECT cpu FROM PC WHERE memory = 3000

GO

SELECT U.UserName, D.Name
FROM Users U JOIN PC P ON U.PCId = P.Id
JOIN Departaments D ON U.DepartamentId = D.Id
WHERE P.hdd > 500

GO

SELECT D.Name, COUNT(U.Id)
FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
GROUP BY D.Id, D.Name

GO

SELECT D.Name, COUNT(U.Id), SUM(U.Salary)
FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
GROUP BY D.Id, D.Name

GO

SELECT DISTINCT P.*
FROM PC P JOIN USERS U ON P.Id = U.PCId,
	(SELECT D.Id id, SUM(U.Salary) AS sm
	FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
	GROUP BY D.Id, D.Name) AS T1
WHERE U.DepartamentId = T1.id AND T1.sm = (SELECT MAX(T2.sm) FROM (SELECT D.Id id, SUM(U.Salary) AS sm
										FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
										GROUP BY D.Id, D.Name) T2)
										
SELECT dbo.MyFunc ('1d95001e-2eee-411f-b83a-4da673d5e7c1') --Дом 1/ул. Пушкина/г. Санкт-Петербург
SELECT dbo.MyFunc ('5b7f0bf1-8ba2-4a2f-9a6f-d6843c60a65c') --ул. Пушкина/г. Москва
SELECT dbo.MyFunc ('3e0fb8ad-e095-4da2-81fa-5e67834701a5') --г. Москва
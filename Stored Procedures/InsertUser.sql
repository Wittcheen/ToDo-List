CREATE PROCEDURE InsertUser(@username VARCHAR(25), @password VARCHAR(200))
AS
BEGIN

DECLARE @addHour TINYINT;
SET @addHour = 1;

INSERT INTO Users(username, [password], dateCreated)
VALUES(@username, @password, DATEADD(HOUR, @addHour, GETDATE()))

END

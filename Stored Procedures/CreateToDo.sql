CREATE PROCEDURE CreateToDo(@username VARCHAR(25), @description VARCHAR(MAX))
AS
BEGIN

INSERT INTO ToDos(username_FK, [description])
VALUES(@username, @description);

END

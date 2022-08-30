CREATE FUNCTION dbo.MyFunc
(
	@param1 nvarchar(40)
)
RETURNS nvarchar(200)
AS
BEGIN
	DECLARE @nextId nvarchar(40), @str nvarchar(400)

	SELECT @nextId = A.ParentId, @str = A.Name
	FROM AddressParts A
	WHERE A.Id = @param1;

	IF @nextId IS NULL
		RETURN @str;
	ELSE
		RETURN @str + '/' + dbo.MyFunc(@nextId);
	RETURN @str;
END
DROP PROCEDURE sp_FizzBuzzAdd
GO

CREATE PROCEDURE [dbo].[sp_FizzBuzzAdd]
	@FizzBuzzNumber INT,
	@FizzBuzzResult VARCHAR(100),
	@DateTime VARCHAR(100),
	@Id INT
AS
	INSERT INTO [dbo].[FizzBuzzData] (Id, FizzBuzzNumber, FizzBuzzResult, DateTime) VALUES (@Id, @FizzBuzzNumber, @FizzBuzzResult, @DateTime)
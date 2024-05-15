CREATE PROCEDURE [dbo].[AddEmployee]
    @EmployeeID int,
	@FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15),
    @Department NVARCHAR(50),
    @Salary DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS(SELECT 1 FROM Employee WHERE Id=@EmployeeID)
    BEGIN
    SELECT 'Employee with same id already exists' AS Result;
    END
    ELSE
    BEGIN

    INSERT INTO Employee ( Id,FirstName, LastName, Email, PhoneNumber, Department, Salary)
    VALUES (@EmployeeID,@FirstName, @LastName, @Email, @PhoneNumber, @Department, @Salary);
    END    
END

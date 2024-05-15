CREATE PROCEDURE [dbo].[UpdateEmployee]
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
    
    -- Check if the employee exists
    IF NOT EXISTS (SELECT 1 FROM Employee WHERE Id = @EmployeeID)
    BEGIN
        -- If the employee does not exist, return an error message
        SELECT 'Employee with specified ID does not exist' AS Result;
        RETURN;
    END

    -- Update the employee details
    UPDATE Employee
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
        Department = @Department,
        Salary = @Salary
    WHERE Id = @EmployeeID;

    -- Return success message
    SELECT 'Employee details updated successfully' AS Result;
END

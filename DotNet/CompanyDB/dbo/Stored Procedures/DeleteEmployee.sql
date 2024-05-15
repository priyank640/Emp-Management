CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Employee
    WHERE Id = @EmployeeID;
    
    IF @@ROWCOUNT = 0
    BEGIN
            SELECT 'Employee  id dose not  exists' AS Result;

    END
END;

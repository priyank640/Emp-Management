namespace CompanyDB_Management.Model
{
    public class EmployeeModel
    {
        public string? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
        public decimal? Salary { get; set; }

    }
    public class EmployeeResponce
    {
        public bool? IsSuccess { get; set; }
        public bool? IsError { get; set; }

        public string? Message { get; set; }
    }
    public class DeleteModel
    {
        public string? Id { get; set; }
    }
}

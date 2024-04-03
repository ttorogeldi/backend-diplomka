namespace Assignment.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string? NationalIDNumber { get; set; }

        public string? EmployeeName { get; set; }

        public string? LoginID { get; set; }

        public string? JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Gender { get; set; }

        public DateTime HireDate { get; set; }

        public Guid? RowGuid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int WarehouseBranchId { get; set; } // Внешний ключ к филиалу
        public WarehouseBranch WarehouseBranch { get; set; } // Навигационное свойство к филиалу
    }
}
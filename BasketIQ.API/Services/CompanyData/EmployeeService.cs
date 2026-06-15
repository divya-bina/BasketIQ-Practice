using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using System.Text.Json;

namespace BasketIQ.API.Services.CompanyData
{
    public class EmployeeService : IEmployeeInterface
    {
        private RootData LoadRootData()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<RootData>(jsonString, options);
        }

        public EmployeeWithDepartmentResponse GetEmployeeDetails(string id)
        {
            var data = LoadRootData();

            // Step 1 - Get Employee
            var employee = data.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return null;

            // Step 2 - Get Department Name
            var department = data.Departments.FirstOrDefault(d => d.Id == employee.Department_Id);

            // Step 3 - Return Employee with Department Name
            return new EmployeeWithDepartmentResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Department_Id = employee.Department_Id,
                Department_Name = department != null ? department.Name : "Unknown",
                Role_Title = employee.Role_Title,
                Salary = employee.Salary,
                City = employee.City,
                Joining_Date = employee.Joining_Date,
                Days_Worked = employee.Days_Worked,
                Is_Remote = employee.Is_Remote,
                Skills_Mastered = employee.Skills_Mastered,
                Assigned_Projects = employee.Assigned_Projects
            };
        }
    }
}
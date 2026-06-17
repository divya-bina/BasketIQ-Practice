using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using System.Net.WebSockets;
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

        public EmployeeWithDepartmentResponse GetEmployeeDetailsById(string id)
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


        public List<EmployeeWithDepartmentResponse> GetEmployeeDetails()
        {
            var data = LoadRootData();

            var result = new List<EmployeeWithDepartmentResponse>();

            foreach (var employee in data.Employees)
            {
                var department = data.Departments.FirstOrDefault(d => d.Id == employee.Department_Id);

                result.Add(new EmployeeWithDepartmentResponse
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
                });
            }

            return result;
        }


        public List<EmployeeWithCategoryResponse> GetAllEmployeesWithCategory()
        {
            var data = LoadRootData();
            var result = new List<EmployeeWithCategoryResponse>();

            foreach (var employee in data.Employees)
            {
                var department = data.Departments.FirstOrDefault(d => d.Id == employee.Department_Id);

                var skillsWithCategory = employee.Skills_Mastered.Select(sm =>
                {
                    var skill = data.Skills_Catalog.FirstOrDefault(s => s.Id == sm.Skill_Id);
                    return new SkillWithCategory
                    {
                        Skill_Name = skill != null ? skill.Name : "Unknown",
                        Category = skill != null ? skill.Category : "Unknown",
                     
                    };
                }).ToList();

                result.Add(new EmployeeWithCategoryResponse
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
                    Skills_Mastered = skillsWithCategory
                });
            }

            return result;
        }




        public List<EmployeeWithProjectResponse> GetAllEmployeesWithProject()
        {
            var data = LoadRootData();
            var result = new List<EmployeeWithProjectResponse>();

            foreach (var employee in data.Employees)
            {
                
                var department = data.Departments.FirstOrDefault(d => d.Id == employee.Department_Id);

                
                var assignedProjectsWithNames = employee.Assigned_Projects.Select(ap =>
                {
                    var project = data.Projects.FirstOrDefault(p => p.Id == ap.Project_Id);
                    return new AssignedProjectWithName
                    {
                        Project_Name = project != null ? project.Name : "Unknown",
                      
                    };
                }).ToList();

                result.Add(new EmployeeWithProjectResponse
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
                    Assigned_Projects = assignedProjectsWithNames
                });
            }

            return result;
        }


        public List<Employee> GetRemoteEmployees()
        {
            var data = LoadRootData();

            
            var result = data.Employees
                .Where(e => e.Is_Remote == true)
                .ToList();

            if (result.Count == 0) return null;

            return result;
        }

        public List<Employee> GetSeattleEmployees()
        {
            var data = LoadRootData();

            var result = data.Employees
                .Where(e => e.City == "Seattle")
                .ToList();

            if (result.Count == 0) return null;

            return result;
        }

      
      public List<Employee> GetEmployeeWithHighSalary()
        { 
            var data = LoadRootData();

        var result = data.Employees
            .Where(e => e.Salary > 100000)
            .ToList();

            if (result.Count == 0) return null;
            return result;
        }

        public List<Employee> GetEmployeesJoinedAfter2022()
        {
            var data = LoadRootData();

            var result = data.Employees
                    .Where(e =>DateTime.Parse(e.Joining_Date).Year > 2022)
                    .ToList();
            if (result.Count == 0) return null;
            return result;
        }

        public List<Employee> GetExperiencedEmployees()
        {
            var data = LoadRootData();
            var result = data.Employees
                .Where(e => e.Skills_Mastered.Any(s => s.Years_Experience > 5))
                .ToList();
            if (result.Count == 0) return null;
            return result;
        }


        


    }
}
using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using System.Text.Json;

namespace BasketIQ.API.Services.CompanyData
{
    public class DepartmentService : IDepartmentInterface
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

        public List<Department> GetAllDepartments()
        {
            return LoadRootData().Departments;
        }

        public Department GetDepartmentById(string id)
        {
            var departments = LoadRootData().Departments;
            return departments.FirstOrDefault(d => d.Id == id);
        }


        public string AddDepartment(Department request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            // Check if department with same ID already exists
            var existing = data.Departments.FirstOrDefault(d => d.Id == request.Id);
            if (existing != null) return null;

            data.Departments.Add(request);

            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return "Department Added Successfully....!!!!";
        }

        public string UpdateDepartment(Department request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var department = data.Departments.FirstOrDefault(d => d.Id == request.Id);

            // If department not found return null
            if (department == null) return null;

            department.Name = request.Name;
            department.Budget = request.Budget;
            department.Manager_Id = request.Manager_Id;

            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return "Department Updated Successfully....!!!!";
        }


        public string DeleteDepartment(Department request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var department = data.Departments.FirstOrDefault(d => d.Id == request.Id);

            if (department == null) return null;

            data.Departments.Remove(department);

            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return $"Department '{department.Name}' Deleted Successfully....!!!!";
        }


        public List<Department> GetHighBudgetDepartments()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var result = data.Departments
                .Where(d => d.Budget > 500000)
                .ToList();

            if (result.Count == 0) return null;
            return result;
        }



    }
}
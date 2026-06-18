using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using System.Net.WebSockets;
using System.Text.Json;
namespace BasketIQ.API.Services.CompanyData
{
    public class ProjectService : IProjectInterface

    {
        private List<Project> LoadProjects()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);
            return data.Projects;
        }


        // Get all projects
        public List<Project> GetAllProjects()
        {
            return LoadProjects();
        }

        // Get single project by id e.g PRJ-901
        public Project GetProjectById(string id)
        {
            var projects = LoadProjects();
            return projects.FirstOrDefault(p => p.Id == id);
        }


        public string UpdateProject(Project request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var project = data.Projects.FirstOrDefault(p => p.Id == request.Id);

            if (project == null) return null;

            project.Name = request.Name;
            project.Status = request.Status;
            project.Budget = request.Budget;
            project.Technologies_Used = request.Technologies_Used;

            // Save back to JSON file
            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return "Records Updated Successfully....!!!!";
        }



        public string AddProject(Project request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var existing = data.Projects.FirstOrDefault(p => p.Id == request.Id);
            if (existing != null) return null;

            data.Projects.Add(request);

            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return "Project Added Successfully....!!!!";
        }

        public string DeleteProject(Project request)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var project = data.Projects.FirstOrDefault(p => p.Id == request.Id);

            // If project not found return null
            if (project == null) return null;

            data.Projects.Remove(project);

            var updatedJson = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, updatedJson);

            return $"Project '{project.Name}' Deleted Successfully....!!!!";
        }


        public List<Project> GetAllActiveStatusProjects()
        {
            // ✅ Copy same pattern as your other methods
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var result = data.Projects
                .Where(p => p.Status == "Active")
                .ToList();

            if (result.Count == 0) return null;
            return result;
        }


        public List<ProjectWithEmployeeCount> GetProjectsWithEmployeeCount()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var result = new List<ProjectWithEmployeeCount>();

            foreach (var project in data.Projects)
            {

                var employeeCount = data.Employees
                    .Count(e => e.Assigned_Projects
                    .Any(ap => ap.Project_Id == project.Id));

                result.Add(new ProjectWithEmployeeCount
                {
                    Id = project.Id,
                    Name = project.Name,
                    Status = project.Status,
                    Budget = project.Budget,
                    Employee_Count = employeeCount
                });
            }

            if (result.Count == 0) return null;
            return result;
        }



        public List<Project> GetHighBudgetProject()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Json", "company-data.json");
            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<RootData>(jsonString, options);

            var result = data.Projects
                .Where(p => p.Budget > 300000)
                .ToList();

            if (result.Count == 0) return null;
            return result;
        }



    } 
}

using BasketIQ.API.Models.CompanyData;

namespace BasketIQ.API.Interfaces.CompanyData
{
    public interface IProjectInterface
    {
        List<Project> GetAllProjects();
        Project GetProjectById(string id);

        string UpdateProject(Project request);

        string AddProject(Project request);

        string DeleteProject(Project request);

        List<Project> GetAllActiveStatusProjects();
        List<ProjectWithEmployeeCount> GetProjectsWithEmployeeCount();

        List<Project> GetHighBudgetProject();

        List<Project> GetMaintenanceProjects();
    }
}
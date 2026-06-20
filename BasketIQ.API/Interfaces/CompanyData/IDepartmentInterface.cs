using BasketIQ.API.Models.CompanyData;

namespace BasketIQ.API.Interfaces.CompanyData
{
    public interface IDepartmentInterface
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(string id);

        string AddDepartment(Department request);

        string UpdateDepartment(Department request);

        string DeleteDepartment(Department request);

        List<Department> GetHighBudgetDepartments();
        string UpdateDepartmentBudget(string id, double budget);
    }
}

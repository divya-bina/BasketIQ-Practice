using BasketIQ.API.Models.CompanyData;
using BasketIQ.API.Services.CompanyData;

namespace BasketIQ.API.Interfaces.CompanyData
{
    public interface IEmployeeInterface
    {
        EmployeeWithDepartmentResponse GetEmployeeDetailsById(string id);
        List<EmployeeWithDepartmentResponse> GetEmployeeDetails();
        List<EmployeeWithCategoryResponse> GetAllEmployeesWithCategory();
        List<EmployeeWithProjectResponse> GetAllEmployeesWithProject();
        List<Employee> GetRemoteEmployees();
        List<Employee> GetSeattleEmployees();
        List<Employee> GetEmployeeWithHighSalary();
        List<Employee> GetEmployeesJoinedAfter2022();
        List<Employee> GetExperiencedEmployees();
        List<HighestPaidEmployee> GetHighestPaidEmployeePerDepartment();





    }
}
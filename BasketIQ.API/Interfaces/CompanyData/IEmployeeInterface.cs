using BasketIQ.API.Models.CompanyData;

namespace BasketIQ.API.Interfaces.CompanyData
{
    public interface IEmployeeInterface
    {
        EmployeeWithDepartmentResponse GetEmployeeDetails(string id);
    }
}
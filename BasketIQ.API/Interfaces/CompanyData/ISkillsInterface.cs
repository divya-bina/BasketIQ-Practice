using BasketIQ.API.Models.CompanyData;

namespace BasketIQ.API.Interfaces.CompanyData
{
    public interface ISkillsInterface
    {
        List<SkillsCatalog> GetBackendSkills();
    }
}
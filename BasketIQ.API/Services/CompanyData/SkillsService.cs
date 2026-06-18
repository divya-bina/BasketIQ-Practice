using BasketIQ.API.Interfaces.CompanyData;
using BasketIQ.API.Models.CompanyData;
using System.Text.Json;

namespace BasketIQ.API.Services.CompanyData
{
    public class SkillsService : ISkillsInterface
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

        public List<SkillsCatalog> GetBackendSkills()
        {
            var data = LoadRootData();

            var result = data.Skills_Catalog
                .Where(s => s.Category == "Backend")
                .ToList();

            if (result.Count == 0) return null;
            return result;
        }
    }
}
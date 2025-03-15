using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public interface IHealthTipssInterface
    {
        public Task<List<Diseases>> GetDiseaseWithTips();
        public Task<List<Diseases>> GetTipsForParticularDisease(string DiseaseName);
        public Task<Diseases> PostDiseaseWIthTips(HealthTipsRequestDto healthTipsDto);
        public Task<Diseases> UpdateDiseaseWithTips(int Id,HealthTipsUpdateDto healthTipsDto);
    }
}

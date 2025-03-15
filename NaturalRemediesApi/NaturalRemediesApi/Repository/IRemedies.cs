using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public interface IRemedies
    {
        Task<List<Diseases>> GetRemedies();
        Task<List<Diseases>> GetRemedyByDiseaseName(string diseaseName);
        Task<Diseases> PostDiseaseWithRemedies(RemediesPostDto diseases);  
        Task<Diseases> UpdateRemedies(int Id,RemediesPostDto diseases);

        Task<Diseases> DeleteRemedy(int Id);

    }
}

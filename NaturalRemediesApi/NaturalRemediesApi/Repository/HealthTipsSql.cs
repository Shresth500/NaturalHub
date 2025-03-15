using Microsoft.EntityFrameworkCore;
using NaturalRemediesApi.Data;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public class HealthTipsSql : IHealthTipssInterface
    {
        ApplicationDbContext _context;
        public HealthTipsSql(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Diseases>> GetDiseaseWithTips()
        {
            var diseasewithTips = await _context.Diseases.Include(x => x.HealthTips).ToListAsync();
            return diseasewithTips;
        }

        public async Task<List<Diseases>> GetTipsForParticularDisease(string DiseaseName)
        {
            var diseasewithTips = await _context.Diseases.Include(x => x.HealthTips).Where(y => y.Name.Contains(DiseaseName)).ToListAsync();
            return diseasewithTips;
        }

        public async Task<Diseases> PostDiseaseWIthTips(HealthTipsRequestDto healthTipsDto)
        {
            var tips = healthTipsDto.Tips;
            var getdisease = await _context.Diseases.Where(x => x.Name ==  healthTipsDto.Name).FirstOrDefaultAsync();
            if(getdisease == null)
            {
                await _context.Diseases.AddAsync(new Diseases
                {
                    Name = healthTipsDto.Name,
                    HealthTips = new List<HealthTips>()
                });
            }
            var healthtips = new List<HealthTips>();
            foreach (var tip in tips) {
                var data = await _context.HealthTips.AddAsync(new HealthTips
                {
                    DiseaseId = getdisease.Id,
                    TipName = tip.Name,
                });
                await _context.SaveChangesAsync();
            }
            var result = await _context.Diseases.Include(y => y.HealthTips).Where(x => x.Id == getdisease.Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Diseases> UpdateDiseaseWithTips(int Id, HealthTipsUpdateDto healthTipsDto)
        {
            var getdisease = await _context.Diseases.Where(x => x.Id == Id).FirstOrDefaultAsync();
            var tips = healthTipsDto.Tips;
            foreach (var tip in tips)
            {
                var data = await _context.HealthTips.AddAsync(new HealthTips
                {
                    DiseaseId = getdisease.Id,
                    TipName = tip.Name,
                });
                await _context.SaveChangesAsync();
            }
            var result = await _context.Diseases.Include(y => y.HealthTips).Where(x => x.Id == getdisease.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}

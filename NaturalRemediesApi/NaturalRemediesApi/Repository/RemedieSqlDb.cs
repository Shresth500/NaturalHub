using Microsoft.EntityFrameworkCore;
using NaturalRemediesApi.Data;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public class RemedieSqlDb : IRemedies
    {
        private readonly ApplicationDbContext _context;
        public RemedieSqlDb(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Diseases> DeleteRemedy(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Diseases>> GetRemedies()
        {
            var data = await _context.Diseases.Include(a => a.Remedies).ThenInclude(b => b.NaturalRemedies).ToListAsync();
            return data;
        }

        public async Task<List<Diseases>> GetRemedyByDiseaseName(string DiseaseName)
        {
            var data = await _context.Diseases.Where(x => x.Name.Contains(DiseaseName)).Include(y => y.Remedies).ThenInclude(a => a.NaturalRemedies).ToListAsync();
            return data;
        }

        public async Task<Diseases> PostDiseaseWithRemedies(RemediesPostDto diseases)
        {
            var remedies = diseases.RemedyPost;
            List<Remedies> RemedyDto = new List<Remedies>();
            foreach (var d in remedies)
            {
                var remedy = await _context.NaturalRemedies.Where(x => x.Name == d.Name).FirstOrDefaultAsync();
                if (remedy == null)
                {
                    var value = new NaturalRemedies
                    {
                        Name = d.Name,
                    };
                    await _context.NaturalRemedies.AddAsync(value);
                    await _context.SaveChangesAsync();

                }
            }
            var getdisease = await _context.Diseases.Where(x => x.Name == diseases.Name).FirstOrDefaultAsync();
            if (getdisease != null)
            {
                await _context.Diseases.AddAsync(new Diseases
                {
                    Name = diseases.Name,
                    Description = diseases.Description,
                    Preparation = diseases.Preparation,
                    Usage = diseases.Usage,
                    Benefits = diseases.Benefits,
                    Remedies = RemedyDto,
                    HealthTips = new List<HealthTips>()
                });
            }
            else
            {
                getdisease.Description = diseases.Description;
                getdisease.Benefits = diseases.Benefits;
                getdisease.Preparation = diseases.Preparation;
                getdisease.Usage = getdisease.Usage;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            var data = await _context.Diseases.Where(x => x.Name == diseases.Name).FirstOrDefaultAsync();
            foreach (var d in remedies)
            {
                var remedy = await _context.NaturalRemedies.Where(x => x.Name == d.Name).FirstOrDefaultAsync();
                await _context.Remedies.AddAsync(
                    new Remedies
                    {
                        NaturalRemediesId = remedy.Id,
                        DiseasesId = data.Id
                    }
                );
                await _context.SaveChangesAsync();
            }
            data = await _context.Diseases.Where(x => x.Name == diseases.Name).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Diseases> UpdateRemedies(int Id, RemediesPostDto diseases)
        {
            var remedies = diseases.RemedyPost;
            List<Remedies> RemedyDto = new List<Remedies>();
            foreach (var d in remedies)
            {
                var remedy = await _context.NaturalRemedies.Where(x => x.Name == d.Name).FirstOrDefaultAsync();
                if (remedy == null)
                {
                    var value = new NaturalRemedies
                    {
                        Name = d.Name,
                    };
                    await _context.NaturalRemedies.AddAsync(value);
                    await _context.SaveChangesAsync();

                }
            }

            var disease = await _context.Diseases.Include(y => y.Remedies).Where(x => x.Id ==  Id).FirstOrDefaultAsync();
            var data = await _context.Remedies.Where(x => x.DiseasesId == disease.Id).ToListAsync();
            foreach (var item in data)
            {
                _context.Remedies.Remove(item);
                await _context.SaveChangesAsync();
            }
            foreach (var d in remedies)
            {
                var remedy = await _context.NaturalRemedies.Where(x => x.Name == d.Name).FirstOrDefaultAsync();
                await _context.Remedies.AddAsync(
                    new Remedies
                    {
                        NaturalRemediesId = remedy.Id,
                        DiseasesId = disease.Id
                    }
                );
                await _context.SaveChangesAsync();
            }
            disease = await _context.Diseases.Where(x => x.Name == diseases.Name).FirstOrDefaultAsync();
            return disease;
        }
    }
}

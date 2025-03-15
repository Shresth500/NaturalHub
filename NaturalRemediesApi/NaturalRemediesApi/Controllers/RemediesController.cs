using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalRemediesApi.Mappings;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;
using NaturalRemediesApi.Repository;

namespace NaturalRemediesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemediesController : ControllerBase
    {
        private readonly IRemedies _remedies;
        private readonly IMapper _mapper;

        public RemediesController(IRemedies remedies,IMapper mapper)
        {
            _remedies = remedies;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRemedies()
        {
            var data = await _remedies.GetRemedies();
            var Remedies = _mapper.Map<List<RemediesDto>>(data);
            return Ok(Remedies);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> GetRemediesByDiseaseName([FromQuery] string DiseaseName)
        {
            var data = await _remedies.GetRemedyByDiseaseName(DiseaseName);
            var Remedy = _mapper.Map<List<RemediesDto>>(data);
            return Ok(Remedy);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostRemedies([FromBody] RemediesPostDto Remedies)
        {
            var data = await _remedies.PostDiseaseWithRemedies(Remedies);
            var DiseaseRemedy = _mapper.Map<RemediesDto>(data);
            return Ok(DiseaseRemedy);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRemedies([FromRoute] int id,[FromBody] RemediesPostDto Remedies)
        {
            var data = await _remedies.UpdateRemedies(id, Remedies);
            var remedy = _mapper.Map<RemediesDto>(data);
            return Ok(remedy);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.DTO;
using NaturalRemediesApi.Repository;

namespace NaturalRemediesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthTipsController : ControllerBase
    {
        private readonly IHealthTipssInterface _healthtips;
        private readonly IMapper _mapper;

        public HealthTipsController(IHealthTipssInterface healthtips, IMapper mapper)
        {
            _healthtips = healthtips;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getHealthTips()
        {
            var data = await _healthtips.GetDiseaseWithTips();
            var result = _mapper.Map<List<HealthTipsResponseDto>>(data);
            return Ok(result);
        }
        [HttpGet("search")]
        [Authorize]

        public async Task<IActionResult> getHealthTipsForDisease([FromQuery] string DiseaseName)
        {
            var data = await _healthtips.GetTipsForParticularDisease(DiseaseName);
            var result = _mapper.Map<List<HealthTipsResponseDto>>(data);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostHealthTipsWithDisease(HealthTipsRequestDto healthtipsrequest)
        {
            var data = await _healthtips.PostDiseaseWIthTips(healthtipsrequest);
            var result = _mapper.Map<HealthTipsResponseDto>(data);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatetTips([FromRoute] int id, [FromBody] HealthTipsUpdateDto healthtipsrequest)
        {
            var data = await _healthtips.UpdateDiseaseWithTips(id, healthtipsrequest);
            var result = _mapper.Map<HealthTipsResponseDto>(data);
            return Ok(result);
        }
    }
}

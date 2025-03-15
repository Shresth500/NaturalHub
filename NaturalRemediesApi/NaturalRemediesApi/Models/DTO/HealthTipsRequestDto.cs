namespace NaturalRemediesApi.Models.DTO
{
    public class HealthTipsRequestDto
    {
        public string Name { get; set; }
        public List<TipsDto> Tips { get; set; }
    }
    public class TipsDto
    {
        public string Name { get; set; }
    }
}

namespace NaturalRemediesApi.Models.DTO
{
    public class HealthTipsUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TipsDto> Tips { get; set; }
    }
}

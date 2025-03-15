namespace NaturalRemediesApi.Models.DTO
{
    public class HealthTipsResponseDto
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public List<TipsResponseDto> Tips { get; set; }
    }
    public class TipsResponseDto
    {
        public int TipId { get; set; }
        public string TipName { get; set; }
    }
}

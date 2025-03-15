namespace NaturalRemediesApi.Models.DTO
{
    public class RemediesPostDto
    {
        public string Name { get; set; }
        public List<RemedyPost>? RemedyPost { get; set; }
        public string Description { get; set; }
        public string Benefits { get; set; }
        public string Preparation { get; set; }
        public string Usage { get; set; }
    }

    public class RemedyPost
    {
        public string Name { get; set; }
    }

    public class RemediesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RemedyDto> Remedies { get; set; }
        public string Description { get; set; }
        public string Benefits {  get; set; }
        public string Preparation { get; set; }
        public string Usage { get; set; }

    }

    public class RemedyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

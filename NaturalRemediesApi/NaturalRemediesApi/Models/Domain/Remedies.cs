namespace NaturalRemediesApi.Models.Domain
{
    public class Remedies
    {
        public int NaturalRemediesId { get; set; }
        public int DiseasesId { get; set; }

        public Diseases Diseases { get; set; }
        public NaturalRemedies NaturalRemedies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NaturalRemediesApi.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Username {  get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}

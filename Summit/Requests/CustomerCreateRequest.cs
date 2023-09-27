using System.ComponentModel.DataAnnotations;

namespace Summit.Models
{
    public class CustomerCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}

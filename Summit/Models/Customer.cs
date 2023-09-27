using Summit.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summit.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("client_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or null.");

            var hashedPassword = SecretHasher.Hash(password);
            PasswordHash = hashedPassword;
        }

        public bool VerifyPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(PasswordSalt))
                return false;

            return SecretHasher.Verify(password, PasswordHash);
        }
    }
}

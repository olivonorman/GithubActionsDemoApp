using System.ComponentModel.DataAnnotations;

namespace GithubActionsDemoApp.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public required string Nombre { get; set; }
    }
}

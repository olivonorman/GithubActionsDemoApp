using GithubActionsDemoApp.Entidades;

namespace GithubActionsDemoApp.Models
{
    public class PersonasIndex
    {
        public IEnumerable<Persona> Personas { get; set; } = new List<Persona>();
    }
}

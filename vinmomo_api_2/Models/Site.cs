using System.Text.Json.Serialization;

namespace vinmomo_api_2.Models
{
    public class Site
    {
        public int Id { get; set; }
        public string Ville { get; set; } = "";

        // Supprime la boucle JSON
        [JsonIgnore]
        public List<Salarie> Salaries { get; set; } = new();
    }
}

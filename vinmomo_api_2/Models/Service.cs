using System.Text.Json.Serialization;

namespace vinmomo_api_2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";

        // Supprime la boucle JSON
        [JsonIgnore]
        public List<Salarie> Salaries { get; set; } = new();
    }
}

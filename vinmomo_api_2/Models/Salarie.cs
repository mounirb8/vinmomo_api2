using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinmomo_api_2.Models
{
    public class Salarie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        // Clés étrangères
        public int ServiceId { get; set; }
        public int SiteId { get; set; }

        // Relations de navigation
        public Service Service { get; set; }
        public Site Site { get; set; }
    }
}

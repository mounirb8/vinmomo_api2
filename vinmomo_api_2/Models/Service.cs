using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinmomo_api_2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        // Relation 1-n : un service contient plusieurs salariés
        public List<Salarie> Salaries { get; set; }
    }
}

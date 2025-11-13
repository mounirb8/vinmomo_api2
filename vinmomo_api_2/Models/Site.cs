using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinmomo_api_2.Models;
    public class Site
    {
        public int Id { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }

        // Relation 1-n : un site contient plusieurs salariés
        public List<Salarie> Salaries { get; set; }
    }


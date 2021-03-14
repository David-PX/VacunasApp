using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class Vacunas
    {
        public Vacunas()
        {
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int id {get; set;}
        public string nombre {get; set;}
        public string marca {get; set;}
        public long cantidad {get; set;}
        public bool disponibilidad {get; set;}

        public int? primeradosis_id { get; set; }

        [ForeignKey(nameof(primeradosis_id))]
        [InverseProperty("Vacunas")]
        public virtual PrimeraDosis PrimeraDosis {get; set;}

        public int? segundadosis_id { get; set; }
        
        [ForeignKey(nameof(segundadosis_id))]
        [InverseProperty("Vacunas")]
        public virtual SegundaDosis SegundaDosis {get; set;}

        [InverseProperty("Vacunas")]
        [JsonIgnore]
        public virtual ICollection<Personas> Personas {get; set;}
    }
}

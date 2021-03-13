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
            Persona = new HashSet<Personas>();
        }

        [Key]
        public int vacuna_id {get; set;}
        public string nombre {get; set;}
        public string marca {get; set;}
        public long cantidad {get; set;}
        public bool disponibilidad {get; set;}

        [InverseProperty("Vacunas")]
        [JsonIgnore]
        public virtual ICollection<Personas> Persona {get; set;}
    }
}

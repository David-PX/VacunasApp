using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class SegundaDosis
    {
        public SegundaDosis()
        {
            Vacunas = new HashSet<Vacunas>();
        }

        [Key]
        public int id {get; set;}
        public bool recibida {get; set;}
        public DateTime fechaRecibida {get; set;} 

        [InverseProperty("SegundaDosis")]
        [JsonIgnore]
        public virtual ICollection<Vacunas> Vacunas {get; set;}
    }
}
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class Provincias
    {
        public Provincias()
        {
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int id {get; set;}
        public string nombre {get; set;}
        public int? pais_id {get; set;}

        [ForeignKey(nameof(pais_id))]
        [InverseProperty("Provincias")]
        public virtual Pais Pais {get; set;}
        [InverseProperty("Provincias")]
        [JsonIgnore]
        public virtual ICollection<Personas> Personas {get; set;}
    }    
}
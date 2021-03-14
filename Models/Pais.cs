using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class Pais
    {
        public Pais()
        {
            Provincias = new HashSet<Provincias>();
        }

        [Key]
        public int id {get; set;}
        public string nombre {get; set;}

        [InverseProperty("Pais")]
        public virtual ICollection<Provincias> Provincias {get; set;}
    }
}
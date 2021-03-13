using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class Personas
    {
        [Key]
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public int? vacuna_id { get; set; }

        [ForeignKey(nameof(vacuna_id))]
        [InverseProperty("Personas")]
        public virtual Vacunas Vacunas {get; set;}

        public int? provincia_id { get; set; }

        [ForeignKey(nameof(provincia_id))]
        [InverseProperty("Personas")]
        public virtual Provincias Provincias {get; set;}

        public int? signosodiacal_id {get; set;}

        [ForeignKey(nameof(signosodiacal_id))]
        [InverseProperty("Personas")]
        public virtual SignosSodiacales SignosSodiacales {get; set;} 
    }
}

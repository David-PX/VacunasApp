using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacunasApp.Models
{
    public class Personas
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime vacuna1 { get; set; }
        public DateTime vacuna2 { get; set; }
        public string provincia { get; set; }
        public string signoZodiacal { get; set; }

    }
}

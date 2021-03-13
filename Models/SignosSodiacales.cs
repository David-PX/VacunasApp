using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacunasApp.Models
{
    public class SignosSodiacales
    {
        public SignosSodiacales()
        {
            SignoSodiacal = new HashSet<SignosSodiacales>();
        }

        [Key]
        public int signosodiacal_id {get; set;}
        public string nombre {get; set;}
        public DateTime fechaInicio {get; set;}
        public DateTime fechaFinal {get; set;}

        [InverseProperty("SignosSodiacales")]
        [JsonIgnore]
        public virtual ICollection<SignosSodiacales> SignoSodiacal {get; set;}
    }
}
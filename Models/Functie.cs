using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    public class Functie
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Display(Name = "Funcție")]
        public string Nume { get; set; }

        public string Descriere { get; set; }

        public ICollection<Angajat> Angajati { get; set; }
    }
}

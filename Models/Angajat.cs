using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    public class Angajat
    {
        [Key]
        public long  Id { get; set; }
        [Required]
        public long Marca { get; set; }
        [Required]
        public string Nume { get; set; }
        public int Salariu { get; set; }

        //Legatura cu Functie
        public long IdFunctie { get; set; }
        [ForeignKey("IdFunctie")]
        public Functie Functie { get; set; }

        //Legatura cu Departament
        public long IdDepartament { get; set; }
        
        [ForeignKey("IdDepartament")]
        public Departament Departament { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    public class Departament
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long Cod { get; set; }
        [MaxLength(10)]
        [Display(Name = "Departament")]
        public string Nume { get; set; }


        public long? IdMagazin { get; set; }
        //[InverseProperty("Id")]
        [ForeignKey("IdMagazin")]
        public Magazin Magazin { get; set; }


        //filiala la care se gaseste departamentul curent

        public ICollection<Angajat> Angajati { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    public class Stoc
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Cantitate { get; set; }
        public float Marime { get; set; }

        public long IdMagazin { get; set; }
        [ForeignKey("IdMagazin")] //proprietatea Id al clasei Magazin
        public Magazin Magazin { get; set; }

        public long IdProdus { get; set; }
        [ForeignKey("IdProdus")] //proprietatea Id al clasei Produs
        public Produs Produs { get; set; }

    }
}

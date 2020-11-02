using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    public class Comanda
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Cantitate { get; set; }
        public DateTime Data_Comanda { get; set; }
        public DateTime Data_Livrare { get; set; }

        public long IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        public long IdStoc { get; set; }
        [ForeignKey("IdStoc")]
        public Stoc StocProdus { get; set; }
    }
}

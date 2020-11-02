using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;


namespace CTPapuci.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
    }
}

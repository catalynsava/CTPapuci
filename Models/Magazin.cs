using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CTPapuci.Models
{
    [Table(name:"Unitate")]
    public class Magazin
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName="nvarchar(20)")]
        public long Cod { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Nume { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Locație")]
        public string Locatie { get; set; }

        public ICollection<Departament> Departamente { get; set; }
    }
}

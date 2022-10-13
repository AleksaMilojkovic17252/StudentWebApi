using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace FaziTest.Models
{
    public partial class Kur
    {
        /*public Kur()
        {
            Ocenas = new HashSet<Ocena>();
        }*/

        [Key]
        [Column("kod",TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string Kod { get; set; }

        [Column("ime",TypeName ="varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Ime { get; set; }

        [Column("opis",TypeName ="varchar(1000)")]
        [MaxLength(1000)]
        [Required]
        public string Opis { get; set; }

        [JsonIgnore]
        public virtual List<Ocena> Ocenas { get; set; }
    }
}

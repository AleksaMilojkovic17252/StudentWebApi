using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace FaziTest.Models
{
    public partial class Ocena
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ocena",TypeName = "int")]
        [Required]
        public int Ocena1 { get; set; }

        [Column("studentId", TypeName = "int")]
        [Required]
        public int StudentId { get; set; }

        [Column("kursKod", TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string KursKod { get; set; }

        [ForeignKey(nameof(KursKod))]
        public virtual Kur KursKodNavigation { get; set; }

        [ForeignKey(nameof(StudentId))]
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}

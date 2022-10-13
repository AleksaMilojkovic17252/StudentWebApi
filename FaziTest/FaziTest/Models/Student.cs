using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FaziTest.Models
{
    public partial class Student
    {
        /*public Student()
        {
            Ocenas = new HashSet<Ocena>();
        }*/

        [Key]
        [Column("studentId",TypeName="int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Column("ime",TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Ime { get; set; }

        [Column("prezime", TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Prezime { get; set; }

        [Column("grad", TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Grad { get; set; }

        [Column("drzava", TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Drzava { get; set; }

        [Column("datumRodjenja", TypeName ="DATE")]
        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Column("pol", TypeName = "varchar(2)")]
        [MaxLength(2)]
        public string Pol { get; set; }


        public virtual List<Ocena> Ocenas { get; set; }
    }
}

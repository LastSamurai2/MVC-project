using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models
{
    public class CopyOfTheBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Consumption { get; set; }
        public Books Book { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models
{
    public class Books
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public int Rating { get; set; }

        public Authors Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        public ICollection<CopyOfTheBook> CpBooks { get; set; }


    }
}

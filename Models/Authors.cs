using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models
{
    public class Authors : IValidatableObject
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength=3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        public ICollection<Books> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == null || Surname == null)
                {
                yield return new ValidationResult("Obydwa pola muszą być wypełnione");
            }
        }
    }
}

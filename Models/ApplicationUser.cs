using Library3.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Age { get; set; }

        [Required]
        [MinimumAge(18)]
        [DisplayName("Data urodzenia")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}

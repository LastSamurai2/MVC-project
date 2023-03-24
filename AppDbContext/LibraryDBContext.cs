using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library3.AppDbContext
{
    public class LibraryDBContext:IdentityDbContext<IdentityUser>
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options):
            base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<CopyOfTheBook> CpBooks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

}
}

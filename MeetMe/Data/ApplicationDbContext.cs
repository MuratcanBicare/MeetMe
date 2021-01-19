using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetMe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // identitydbcontext'i benim oluşturduğum ApplicationUser sınıfıyla miras al
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings  { get; set; }
    }
}

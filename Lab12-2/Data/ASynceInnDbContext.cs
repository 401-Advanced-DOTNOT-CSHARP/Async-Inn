using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12_2.Models;

namespace Lab12_2.Data
{
    public class ASynceInnDbContext : DbContext
    {
        public ASynceInnDbContext(DbContextOptions<ASynceInnDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}

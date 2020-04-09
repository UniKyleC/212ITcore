using HarrisContactWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWeb.Data
{
    public class HarrisDbContext : DbContext
    {
        //Setting the 'options' context as dbcontext
        public HarrisDbContext(DbContextOptions<HarrisDbContext> options) : base(options) 
        {
        }

        //Creating the DbSet (Database sets) for each class, using their variables as context
        public DbSet<personalContact> personalContacts { get; set; }
        public DbSet<businessContact> businessContacts { get; set; }
    }
}

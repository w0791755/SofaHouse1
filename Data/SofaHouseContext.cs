using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SofaHouse.Models;

namespace SofaHouse.Data
{
    public class SofaHouseContext : IdentityDbContext
    {
        public SofaHouseContext(DbContextOptions<SofaHouseContext> options)
            : base(options)
        {

        }

        public DbSet<Sofa> Sofa { get; set; }
    }
}


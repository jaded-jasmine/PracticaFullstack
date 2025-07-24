using Microsoft.EntityFrameworkCore;
using PracticaFullstack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFullstack.Context
{

    [Table("cats")]
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

    }
}


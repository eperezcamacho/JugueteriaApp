using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BussinessLogic.Data
{
    public class JugueteriaDbContext: DbContext
    {
        public JugueteriaDbContext(DbContextOptions<JugueteriaDbContext> options)
        : base(options) { }
        public DbSet<Producto> Producto { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
    }
}

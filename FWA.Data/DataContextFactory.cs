using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace FWA.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FWA;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DataContext(optionsBuilder.Options);
        }

    }
}

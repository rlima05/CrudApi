using CrudApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Infra
{
    public class CrudApiContext : DbContext
    {
        public CrudApiContext(DbContextOptions<CrudApiContext> options)
            :base(options)
        {

        }

        public CrudApiContext()
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}

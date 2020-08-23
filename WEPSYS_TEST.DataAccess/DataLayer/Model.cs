using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WEPSYS_TEST.DataAccess.DataEntities;

namespace WEPSYS_TEST.DataAccess.DataLayer
{
    public class TestContext : DbContext
    {
        public DbSet<DePermiso> Permisos { get; set; }
        public DbSet<DeTipoPermiso> TipoPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=test.db");
    }
}
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Test.Entity
{
    public class AppDbConText : DbContext
    {
        public DbSet<Chua> Chuas { get; set; }
        public DbSet<DaoTrang> DaoTrangs { get; set; }
        public DbSet<DonDangKy> DonDangKys { get; set; }
        public DbSet<KieuThanhVien> KieuThanhViens { get; set; }
        public DbSet<PhatTu> PhatTus { get; set; }
        public DbSet<PhatTuDaoTrang> PhatTuDaoTrangs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = minhpii; Database = Test; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}

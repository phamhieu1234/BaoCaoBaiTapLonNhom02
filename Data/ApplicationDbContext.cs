using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaoCaoBaiTapLonNhom02.Models;
using BaoCaoBaiTapLonNhom01.Models;
namespace BaoCaoBaiTapLonNhom02.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaoCaoBaiTapLonNhom02.Models.SinhVien> SinhVien { get; set; } = default!;

        public DbSet<BaoCaoBaiTapLonNhom02.Models.Nhom> Nhom { get; set; } = default!;

        public DbSet<BaoCaoBaiTapLonNhom02.Models.Cathi> Cathi { get; set; } = default!;

        public DbSet<BaoCaoBaiTapLonNhom01.Models.DangNhap> DangNhap { get; set; } = default!;
    }
}

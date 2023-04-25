using System.ComponentModel.DataAnnotations;
namespace BaoCaoBaiTapLonNhom02.Models
{
    public class Nhom
    {
        [Key]
        public string? MaNhom{get; set;}
        public string? TenNhom{get; set;}
    }
}
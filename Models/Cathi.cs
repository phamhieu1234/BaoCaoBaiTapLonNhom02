using System.ComponentModel.DataAnnotations;
namespace BaoCaoBaiTapLonNhom02.Models
{
    public class Cathi
    {
        [Key]
        public string? MaCathi{get; set;}
        public string? TenCathi{get; set;}
    }
}
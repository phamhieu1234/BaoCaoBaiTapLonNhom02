using System.ComponentModel.DataAnnotations;
namespace BaoCaoBaiTapLonNhom01.Models;

    public class DangNhap
    {
        [Key]
        public int UserID{get; set;}
        [Required(ErrorMessage= "Yêu cầu nhập username!")]
        public string username{get; set;}

        [Display(Name="Mật Khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu!")]
        public string Password{get; set;}
    }

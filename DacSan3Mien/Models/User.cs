using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class User
    {
        public int id { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [EmailAddress(ErrorMessage = "{0} sai định dạng!")]
        public string email { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string birthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string gender { get; set; }

        [NotMapped]
        public List<System.Web.Mvc.SelectListItem> listGender { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string phone { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string address { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu nằm trong khoảng 6 đến 20 ký tự!")]
        public string password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Mật khẩu chưa khớp!")]
        [NotMapped]
        public string confirmPassword { get; set; }

        public string role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DacSan3Mien.Models
{
    public class Product
    {
        public int id { get; set; }

        [Display(Name = "Tên SP")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string name { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string image { get; set; }
        
        //public Nullable<double> price { get; set; }
        [Display(Name = "Giá")]
        [Range(1000, 900000000, ErrorMessage ="{0} phải nằm trong khoảng từ {1} tới {2} vnd")]
        public float price { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string status { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string description { get; set; }
        
        //public Nullable<int> regionID { get; set; }
        [Display(Name = "Vùng miền")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public int regionId { get; set; }

        //public Nullable<int> orderId { get; set; }

        [NotMapped]
        public List<System.Web.Mvc.SelectListItem> listRegion { get; set; }

        public virtual Region Region { get; set; }
    }
}
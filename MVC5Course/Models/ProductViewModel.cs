using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class ProductViewModel
    {
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }

        [Display(Name = "產品名稱")]
        [Required(ErrorMessage = "商品名稱必填")]
        public string ProductName { get; set; }

        [Display(Name = "金額")]
        [Required(ErrorMessage = "金額必填")]
        [Range(0, 10000, ErrorMessage = "最小0最大10000")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "啟用設定")]
        [Required(ErrorMessage = "啟用設定必填")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "庫存數量")]
        [Required(ErrorMessage = "庫存數量必填")]
        [Range(0, 10000, ErrorMessage = "最小0最大10000")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> Stock { get; set; }

    }
}
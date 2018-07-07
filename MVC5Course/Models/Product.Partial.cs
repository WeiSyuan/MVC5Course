namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }


        [Display(Name = "產品名稱")]
        [Required(ErrorMessage = "商品名稱必填")]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
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
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}

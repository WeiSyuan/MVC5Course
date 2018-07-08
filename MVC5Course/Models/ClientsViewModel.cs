using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC5Course.Models.InputValidations;

namespace MVC5Course.Models
{
    //模型驗證範例
    public partial class ClientsViewModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            //if(this.ClientId==0)
            //{
            //    //通常P.K，為0代表著正在執行「新增」動作
            //}

            if (this.Latitude.HasValue != this.Longitude.HasValue)
            {

                yield return new ValidationResult("經緯度必須同時填寫", new string[] { "Latitude", "Longitude" });
            }
        }
    }




    public partial class ClientsViewModel
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string LastName { get; set; }

        [StringLength(1, ErrorMessage = "欄位長度不得大於 1 個字元")]
        public string Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<double> CreditRating { get; set; }

        [StringLength(7, ErrorMessage = "欄位長度不得大於 7 個字元")]
        public string XCode { get; set; }
        public Nullable<int> OccupationId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string TelephoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string Street1 { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string Street2 { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string ZipCode { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string Notes { get; set; }

        [身份證字號]
        [StringLength(10, ErrorMessage = "欄位長度不得大於 10 個字元")]
        public string Idnumber { get; set; }


        public virtual Occupation Occupation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
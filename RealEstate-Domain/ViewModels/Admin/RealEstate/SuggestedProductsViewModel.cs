using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.ViewModels.Admin.RealEstate
{
    public class SuggestedProductsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} نمی تواند خالی وارد شود")]
        [Display(Name = "عنوان")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} نمی تواند خالی وارد شود")]
        [Display(Name = "متراژ")]
        public int Metrage { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "{0} نمی تواند خالی وارد شود")]
        [Display(Name = "قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} نمی تواند خالی وارد شود")]
        [Display(Name = "آدرس")]
        [MaxLength(500)]
        public string Address { get; set; }
    }
}

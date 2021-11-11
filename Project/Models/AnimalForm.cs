using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class AnimalForm
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Name field must be filled.")]
        [Display(Name = "Enter Name:")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Numbers in Name field are not allowed/ max length is 20 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age field must be filled.")]
        [Display(Name = "Enter Age:")]
        [Range(0, 50, ErrorMessage = "Please enter age between 0-50")]
        public int? Age { get; set; }

        [Display(Name = "Enter PictureSource:")]
        public IFormFile PictureSource { get; set; }

        [Required(ErrorMessage = "Description field must be filled.")]
        [Display(Name = "Enter Description:")]
        [StringLength(300)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category Id field must be filled.")]
        [Display(Name = "Enter CategoryId:")]
        [Range(0, 5)]
        public int CategoryId { get; set; }

    }
}

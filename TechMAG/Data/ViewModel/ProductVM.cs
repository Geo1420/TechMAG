using System.ComponentModel.DataAnnotations;

namespace TechMAG.Data.ViewModel
{
    public class ProductVM
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Product name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Product Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "ImageURL is required")]
        [Display(Name = "Product ImageURL")]
        public string? ImageURL { get; set; }
        [Display(Name = "Product Screen Size")]
        public string? ScreenSize { get; set; }
        [Display(Name = "Product Operating System")]
        public string? OperatingSystem { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Product Amount")]
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public float Discount { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Product Category")]
        public ProductCategory ProductCategory { get; set; }

        public int ProducerId { get; set; }

    }
}

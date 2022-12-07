using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechMAG.Data;

namespace TechMAG.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }

        public string? ImageURL { get; set; }
        public string? ScreenSize { get; set; }
        public string? OperatingSystem { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public float Discount { get; set; }
        public ProductCategory ProductCategory { get; set; }

        //Relationships
        //ProductImgs
        public List<ProductImage>? ProductImages { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer? Producer { get; set; }
    }
}

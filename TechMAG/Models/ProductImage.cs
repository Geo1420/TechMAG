using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechMAG.Data.Base;

namespace TechMAG.Models
{
    public class ProductImage: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? ProductImageURL { get; set; }
        public DateTime? CreatedDate { get; set; }
        ////Relationships
        //public int ProductId { get; set; }
        //[ForeignKey("ProductId")]
        //public Product? Product { get; set; }

    }
}

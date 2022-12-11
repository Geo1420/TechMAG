using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechMAG.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string? ProductImageURL { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

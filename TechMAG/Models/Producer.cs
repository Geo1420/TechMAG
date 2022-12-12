using System.ComponentModel.DataAnnotations;
using TechMAG.Data.Base;

namespace TechMAG.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? ImageURL { get; set; }
        public string? Name { get; set; }
        public string? Desciption { get; set; }
        public string? HomeURL { get; set; }
        //Relationships
        public List<Product>? Products { get; set; }
    }
}

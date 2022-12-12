using TechMAG.Models;

namespace TechMAG.Data.ViewModel
{
    public class ProductDropDownVM
    {
        public ProductDropDownVM()
        {
            Producers = new List<Producer>();
        }
        public List<Producer>? Producers { get; set; }
    }
}

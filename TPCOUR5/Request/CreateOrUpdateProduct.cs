using TPCOUR5.Models;

namespace TPCOUR5.Request
{
    public class CreateOrUpdateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public int Stock { get; set; }
        public int SalePrice { get; set; }

        public Guid CategoryId { get; set; }

        public Guid MarqueId { get; set; }
    }
}


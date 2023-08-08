using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace tparf.Domain.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        [Required]
        public virtual Manufacturer Manufacturer { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductProperty> Properties { get; set; }
    }
}

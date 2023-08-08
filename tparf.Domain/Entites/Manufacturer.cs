namespace tparf.Domain.Entites
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

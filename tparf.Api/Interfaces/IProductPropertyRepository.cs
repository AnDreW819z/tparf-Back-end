using tparf.Domain.Entites;

namespace tparf.Interfaces
{
    public interface IProductPropertyRepository
    {
        bool ProductPropertyExists(int productPropertyId);
        bool CreateProductProperty(int productId,ProductProperty productProperty);
        bool Save();
    }
}

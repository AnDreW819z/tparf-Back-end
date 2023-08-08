using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tparf.Data;
using tparf.Interfaces;
using tparf.Domain.Entites;

namespace tparf.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateProduct(int manufacturerId, int subcategoryId, Product product)
        {
            _context.Add(product);
            return Save();
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Where(o => o.Id == productId).Include(x => x.Category).Include(x => x.Manufacturer).FirstOrDefault();
        }

        public ICollection<Product> GetProductByManufacturer(int manufacturerId)
        {
            return _context.Products.Where(p => p.Manufacturer.Id == manufacturerId).ToList();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.Category.Id == categoryId).ToList();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.Include(x =>x.Category).ToList();
        }

        public ICollection<User> GetUserByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(o => o.Id == productId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<ProductProperty> GetProductPropertyByProduct(int productId)
        {
            return _context.ProductProperties.Where(p => p.Product.Id == productId).ToList();
        }
    }
}

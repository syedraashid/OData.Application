using OData.Model;
using System;

namespace Odata.Client
{
    public class Services
    {
        private readonly DataContext _context;

        public Services(string serviceUrl)
        {
            _context = new DataContext(new Uri(serviceUrl));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ExecuteAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ExecuteAsync();
        }

        public IEnumerable<Product> GetFilteredProductsAsync(int minprice)
        {
            return  _context.Products.Where(p => p.Price > minprice).ToList();
        }

        public  List<Category> GetFilteredCategoriesAsync(string name)
        {
            return  _context.Categories.Where(c => c.CategoryName.Contains(name)).ToList();
        }

        public  List<Product> GetSortedProductsAsync(bool orderByPriceAscending = true)
        {
            var query = orderByPriceAscending
                ? _context.Products.OrderBy(p => p.Price)
                : _context.Products.OrderByDescending(p => p.Price);

            return  query.ToList();
        }

        public  List<Product> GetTopProduct(int skip, int take = 1)
        {
            return  _context.Products.OrderByDescending(_ => _.Rating).Skip(skip).Take(take).ToList();
        }
    }

}

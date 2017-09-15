using OData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.DataAccess
{
    public interface IProductRepository:IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
        void Save();
    }
}

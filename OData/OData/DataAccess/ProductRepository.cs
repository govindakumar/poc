using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OData.Models;
using System.Data.Entity;

namespace OData.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private ProductsContext context;

        public ProductRepository(ProductsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductByID(int id)
        {
            return context.Products.Find(id);
        }

        public void InsertProduct(Product student)
        {
            context.Products.Add(student);
        }

        public void DeleteProduct(int studentID)
        {
            Product student = context.Products.Find(studentID);
            context.Products.Remove(student);
        }

        public void UpdateProduct(Product student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using Newtonsoft.Json;
using OData.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace OData.Controllers
{
    public class Productscontroller:ODataController
    {
        Models.ProductsContext db = new Models.ProductsContext();
        private bool ProductExists(int key)
        {
            return db.Products.Any(p => p.Id == key);
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("pocs.redis.cache.windows.net,abortConnect=false,ssl=true,password=tQNvBdL/Ldzg2VkV7OxmYJ7rRVu8X9hpg6gDNn6W9V4=,ConnectTimeout=10000");
        });
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        public IDatabase cacheDB { get; set; }
        public Productscontroller()
        {
            cacheDB = Connection.GetDatabase();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        #region GET
        //Route URi: http://localhost:1876/Products
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var product = new Product { Id = 1, Name = "Super Car", Category = "Toy", Price = 100, Supplier = new Supplier { Id = 1, Name = "Satyam Suppliers" }, SupplierId = 1 };
            
            List<Product> lst = new List<Product>();
            lst.Add(product);
            cacheDB.StringSet("p1", JsonConvert.SerializeObject(lst));
            if (product==null)
            return db.Products;
            return lst.AsQueryable() ;
        }

        //Route URi: http://localhost:1876/Products(1)
        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = db.Products.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        
        #endregion GET

        #region POST
        public async Task<IHttpActionResult> Post(Product product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            product = new Product() { Name = "Racing Car", Category = "Toy", Price = 1000, SupplierId = 1 };
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Created(product);
        }
        #endregion POST

        #region Update
        //PUT:- Replaces the entire entity so to use PUT user have to pass the entire entity.
        //PATCH:- It is a partial update. Here user should send only the fields which they want to update.
        //* Patch is prefered update operation for ODATA.
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Product update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        #endregion Update

        #region Delete
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion Delete

        #region Entity Relation
        //This method is to get the entity relation data.
        //Route URi: http://localhost:1876/Products(1)/Supplier
        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = db.Products.Where(m => m.Id == key).Select(m => m.Supplier);
            return SingleResult.Create(result);
        }

        #endregion Entity Relation

        #region Action/Function

        /* Functions are useful for returning information that does not correspond directly to an entity or collection.
        Action used for the following purpose.
        1.Complex transactions.
        2.Manipulating several entities at once.
        3.Allowing updates only to certain properties of an entity.
        4.Sending data that is not an entity.
        */
        [HttpPost]
        public async Task<IHttpActionResult> Rate([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int rating = (int)parameters["Rating"];
            db.Ratings.Add(new ProductRating
            {
                ProductID = key,
                Rating = rating
            });

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpGet]
        public IHttpActionResult MostExpensive()
        {
            var product = db.Products.Max(x => x.Price);
            return Ok(product);
        }

        //[HttpGet]
        //[ODataRoute("Products/GetSalesTaxRate(PostalCode={postalCode})")]
        //public IHttpActionResult GetSalesTaxRate([FromODataUri] int postalCode)
        //{
        //    double rate = 5.6;  // Use a fake number for the sample.
        //    return Ok(rate);
        //}

        #endregion Action/Function

    }
}
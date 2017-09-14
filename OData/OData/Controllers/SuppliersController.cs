using OData.Models;
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

namespace OData.Controllers
{
    public class SuppliersController: ODataController
    {
        Models.ProductsContext db = new Models.ProductsContext();

        private bool SupplierExists(int key)
        {
            return db.Suppliers.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #region GET
        [EnableQuery]
        public IQueryable<Supplier> Get()
        {
            var supplier = db.Suppliers;
            return supplier;
        }

        [EnableQuery]
        public SingleResult<Supplier> Get([FromODataUri] int key)
        {
            IQueryable<Supplier> result = db.Suppliers.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

       
        #endregion GET

        #region POST
        public async Task<IHttpActionResult> Post(Supplier supplier)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            supplier = new Supplier() { Id = 1, Name = "Shyam Suppliers" };
            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();
            return Created(supplier);
        }
        #endregion POST

        #region Update
        //PUT:- Replaces the entire entity so to use PUT user have to pass the entire entity.
        //PATCH:- It is a partial update. Here user should send only the fields which they want to update.
        //* Patch is prefered update operation for ODATA.
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Supplier> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Suppliers.FindAsync(key);
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
                if (!SupplierExists(key))
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
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Supplier update)
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
                if (!SupplierExists(key))
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
            var supplier = await db.Suppliers.FindAsync(key);
            if (supplier == null)
            {
                return NotFound();
            }
            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion Delete

        #region Entity Relation

        // Route URI: http://localhost:1876/Suppliers(1)/
        // I have a doubt here ideally it should be getting called using http://localhost:1876/Suppliers(1)/Products but
        // its not working need to check.  
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }
        
        // Not implemented the ref deletion and creation.

        //[AcceptVerbs("POST", "PUT")]
        //public async Task<IHttpActionResult> CreateRef([FromODataUri] int key,
        //string navigationProperty, [FromBody] Uri link)
        //{
        //    var product = await db.Products.SingleOrDefaultAsync(p => p.Id == key);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    switch (navigationProperty)
        //    {
        //        case "Supplier":
        //            // Note: The code for GetKeyFromUri is shown later in this topic.
        //            var relatedKey = Helpers.GetKeyFromUri<int>(Request, link);
        //            var supplier = await db.Suppliers.SingleOrDefaultAsync(f => f.Id == relatedKey);
        //            if (supplier == null)
        //            {
        //                return NotFound();
        //            }

        //            product.Supplier = supplier;
        //            break;

        //        default:
        //            return StatusCode(HttpStatusCode.NotImplemented);
        //    }
        //    await db.SaveChangesAsync();
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        #endregion Entity Relation
    }
}
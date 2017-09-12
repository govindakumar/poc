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
    public class Productscontroller:ODataController
    {
        Models.ProductsContext db = new Models.ProductsContext();
        private bool ProductExists(int key)
        {
            return db.Products.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #region GET
        [EnableQuery]
        public IQueryable<Products> Get()
        {
            return db.Products;
        }

        [EnableQuery]
        public SingleResult<Products> Get([FromODataUri] int key)
        {
            IQueryable<Products> result = db.Products.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
        #endregion GET

        #region POST
        public async Task<IHttpActionResult> Post(Products product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Created(product);
        }
        #endregion POST

        #region Update
        //PUT:- Replaces the entire entity so to use PUT user have to pass the entire entity.
        //PATCH:- It is a partial update. Here user should send only the fields which they want to update.
        //* Patch is prefered update operation for ODATA.
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Products> product)
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
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Products update)
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

    }
}
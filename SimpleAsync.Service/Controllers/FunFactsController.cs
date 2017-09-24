using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleAsync.Library;

namespace SimpleAsync.Service.Controllers
{
    public class FunFactsController : ApiController
    {
        private SimpleDb db = new SimpleDb();

        // GET: api/FunFacts
        public IQueryable<FunFact> GetFunFacts()
        {
            return db.FunFacts;
        }

        // GET: api/FunFacts/5
        [ResponseType(typeof(FunFact))]
        public async Task<IHttpActionResult> GetFunFact(int id)
        {
            FunFact funFact = await db.FunFacts.FindAsync(id);
            if (funFact == null)
            {
                return NotFound();
            }

            return Ok(funFact);
        }

        // PUT: api/FunFacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFunFact(int id, FunFact funFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funFact.Id)
            {
                return BadRequest();
            }

            db.Entry(funFact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunFactExists(id))
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

        // POST: api/FunFacts
        [ResponseType(typeof(FunFact))]
        public async Task<IHttpActionResult> PostFunFact(FunFact funFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FunFacts.Add(funFact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = funFact.Id }, funFact);
        }

        // DELETE: api/FunFacts/5
        [ResponseType(typeof(FunFact))]
        public async Task<IHttpActionResult> DeleteFunFact(int id)
        {
            FunFact funFact = await db.FunFacts.FindAsync(id);
            if (funFact == null)
            {
                return NotFound();
            }

            db.FunFacts.Remove(funFact);
            await db.SaveChangesAsync();

            return Ok(funFact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FunFactExists(int id)
        {
            return db.FunFacts.Count(e => e.Id == id) > 0;
        }
    }
}
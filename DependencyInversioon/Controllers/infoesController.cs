using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DependencyInversioon.Models;

namespace DependencyInversioon.Controllers
{
    public class infoesController : ApiController
    {
        private uttaraon_neerajEntities1 db = new uttaraon_neerajEntities1();

        // GET: api/infoes
        public IQueryable<info> Getinfoes()
        {
            return db.infoes;
        }

        // GET: api/infoes/5
        [ResponseType(typeof(info))]
        public IHttpActionResult Getinfo(int id)
        {
            info info = db.infoes.Find(id);
            if (info == null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content= new StringContent(String.Format("Your Search id not available {0}",id)),
                    ReasonPhrase="Request Data not Found on behalf of this is"


                };
                throw new HttpResponseException(msg);
                    
                return NotFound();
            }

            return Ok(info);
        }

        // PUT: api/infoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinfo(int id, info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info.id)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infoExists(id))
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

        // POST: api/infoes
        [ResponseType(typeof(info))]
        public IHttpActionResult Postinfo(info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.infoes.Add(info);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = info.id }, info);
        }

        // DELETE: api/infoes/5
        [ResponseType(typeof(info))]
        public IHttpActionResult Deleteinfo(int id)
        {
            info info = db.infoes.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            db.infoes.Remove(info);
            db.SaveChanges();

            return Ok(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool infoExists(int id)
        {
            return db.infoes.Count(e => e.id == id) > 0;
        }
    }
}
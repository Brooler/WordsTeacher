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
using WordsTeacher.WebApi.Models;

namespace WordsTeacher.WebApi.Controllers
{
    //http://localhost:37533/
    public class WordBooksController : ApiController
    {
        private WordsTeacherContext db = new WordsTeacherContext();

        // GET: api/WordBooks
        public IQueryable<WordBook> GetWordBooks()
        {
            return db.WordBooks;
        }

        // GET: api/WordBooks/5
        [ResponseType(typeof(WordBook))]
        public async Task<IHttpActionResult> GetWordBook(int id)
        {
            WordBook wordBook = await db.WordBooks.FindAsync(id);
            if (wordBook == null)
            {
                return NotFound();
            }

            return Ok(wordBook);
        }

        // PUT: api/WordBooks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWordBook(int id, WordBook wordBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordBook.Id)
            {
                return BadRequest();
            }

            db.Entry(wordBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordBookExists(id))
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

        // POST: api/WordBooks
        [ResponseType(typeof(WordBook))]
        public async Task<IHttpActionResult> PostWordBook(WordBook wordBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WordBooks.Add(wordBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = wordBook.Id }, wordBook);
        }

        // DELETE: api/WordBooks/5
        [ResponseType(typeof(WordBook))]
        public async Task<IHttpActionResult> DeleteWordBook(int id)
        {
            WordBook wordBook = await db.WordBooks.FindAsync(id);
            if (wordBook == null)
            {
                return NotFound();
            }

            db.WordBooks.Remove(wordBook);
            await db.SaveChangesAsync();

            return Ok(wordBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordBookExists(int id)
        {
            return db.WordBooks.Count(e => e.Id == id) > 0;
        }
    }
}
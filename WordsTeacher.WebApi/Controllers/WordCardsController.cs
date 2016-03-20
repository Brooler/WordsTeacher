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
    public class WordCardsController : ApiController
    {
        private WordsTeacherContext db = new WordsTeacherContext();

        // GET: api/WordCards
        public IQueryable<WordCard> GetWordCards()
        {
            return db.WordCards;
        }

        // GET: api/WordCards/5
        [ResponseType(typeof(WordCard))]
        public async Task<IHttpActionResult> GetWordCard(int id)
        {
            WordCard wordCard = await db.WordCards.FindAsync(id);
            if (wordCard == null)
            {
                return NotFound();
            }

            return Ok(wordCard);
        }

        // PUT: api/WordCards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWordCard(int id, WordCard wordCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordCard.Id)
            {
                return BadRequest();
            }

            db.Entry(wordCard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordCardExists(id))
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

        // POST: api/WordCards
        [ResponseType(typeof(WordCard))]
        public async Task<IHttpActionResult> PostWordCard(WordCard wordCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WordCards.Add(wordCard);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = wordCard.Id }, wordCard);
        }

        // DELETE: api/WordCards/5
        [ResponseType(typeof(WordCard))]
        public async Task<IHttpActionResult> DeleteWordCard(int id)
        {
            WordCard wordCard = await db.WordCards.FindAsync(id);
            if (wordCard == null)
            {
                return NotFound();
            }

            db.WordCards.Remove(wordCard);
            await db.SaveChangesAsync();

            return Ok(wordCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordCardExists(int id)
        {
            return db.WordCards.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WordsTeacher.UwpClient.Models
{
    public static class WordBooksApiRequest
    {
        //GET: get word books list
        public static async Task<IEnumerable<WordBook>> GetWordBooksList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/wordbooks");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<WordBook> books = await response.Content.ReadAsAsync<IEnumerable<WordBook>>();
                    return books;
                }
                return null;
            }
        }
        //GET: get word book by id
        public static async Task<WordBook> GetWordBook(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/wordbooks/" + id);
                if (response.IsSuccessStatusCode)
                {
                    WordBook book = await response.Content.ReadAsAsync<WordBook>();
                    return book;
                }
                return null;
            }
        }
        //POST: add word book
        public static async Task AddWordBook(WordBook book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.PostAsJsonAsync("api/wordbooks", book);
            }
        }
        //PUT: update word book
        public static async Task UpdateWordBook(int id, WordBook book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.PutAsJsonAsync("api/wordbooks/" + id, book);
            }
        }
        //DELETE: delete word book
        public static async Task DeleteWordBook(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.DeleteAsync("api/wordbooks/" + id);
            }
        }
    }

    public static class WordCardsApiRequest
    {
        //GET: get word cards list
        public static async Task<IEnumerable<WordCard>> GetWordCardsList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/wordcards");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<WordCard> cards = await response.Content.ReadAsAsync<IEnumerable<WordCard>>();
                    return cards;
                }
                return null;
            }
        }
        //GET: get word card by id
        public static async Task<WordCard> GetWordCard(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/wordcards/" + id);
                if (response.IsSuccessStatusCode)
                {
                    WordCard card = await response.Content.ReadAsAsync<WordCard>();
                    return card;
                }
                else return null;
            }
        }
        //POST: add word card
        public static async Task AddWordCard(WordCard card)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.PostAsJsonAsync("api/wordcards", card);
            }
        }
        //PUT: update word card
        public static async Task UpdateWordCard(int id, WordCard card)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.PutAsJsonAsync("api/wordcards/" + id, card);
            }
        }
        //DELETE: delete word card
        public static async Task DeleteWordCard(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37533/");
                await client.DeleteAsync("api/wordcards/" + id);
            }
        }
    }
}

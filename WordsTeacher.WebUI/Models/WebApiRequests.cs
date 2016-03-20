using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WordsTeacher.WebApi.Models;

namespace WordsTeacher.WebUI.Models
{
    public static class WordBooksApiRequest
    {
        //GET: get word books list
        public static async Task<IEnumerable<WordBook>> GetWordBooksList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress=new Uri("http://localhost:37533/");
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
                HttpResponseMessage response = await client.GetAsync("api/wordbooks/"+id);
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
                client.BaseAddress=new Uri("http://localhost:37533/");
                await client.PutAsJsonAsync("api/wordbooks/" + id, book);
            }
        }
        //DELETE: delete word book
        public static async Task DeleteWordBook(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress=new Uri("http://localhost:37533/");
                await client.DeleteAsync("api/wordbooks/" + id);
            }
        }
    }
}

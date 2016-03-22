using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class EditWordCardViewModel
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public List<string> Books { get; } = new List<string>();
        public IEnumerable<WordBook> books { get; set; }
        public async Task BooksInitialize()
        {
            books = await WordBooksApiRequest.GetWordBooksList();
            foreach (var item in books)
            {
                Books.Add(item.Title);
            }
        }  
    }
}

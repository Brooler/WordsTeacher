using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<WordBook> books { get; set; }
        public async Task BooksInitialize()
        {
            books=new ObservableCollection<WordBook>();
            foreach (var item in await WordBooksApiRequest.GetWordBooksList())
            {
                books.Add(item);
            }
        }  
    }
}

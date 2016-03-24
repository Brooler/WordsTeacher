using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class DeleteWordBookViewModel
    {
        public ObservableCollection<WordBook> Books { get; set; }
        public WordBook Book { get; set; }

        public async Task TitlesInitializer()
        {
            Books = new ObservableCollection<WordBook>();
            foreach (var item in await WordBooksApiRequest.GetWordBooksList())
            {
                Books.Add(item);
            }
        }
    }
}

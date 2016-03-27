using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<WordBookItemsViewModel> Books { get; set; } 
    }
}

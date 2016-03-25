using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class WordBookItemsViewModel 
    {
        public WordBook Book { get; set; }
        public int WordsNumber { get; set; }
    }
}

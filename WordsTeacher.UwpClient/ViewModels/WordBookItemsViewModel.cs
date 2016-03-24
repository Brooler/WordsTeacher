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
        public string Title { get; set; }
        public string InputLanguage { get; set; }
        public string OutputLanguage { get; set; }
        public int WordsNumber { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}

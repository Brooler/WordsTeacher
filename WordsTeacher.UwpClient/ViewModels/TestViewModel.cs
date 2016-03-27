using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;
using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class TestViewModel
    {
        public List<WordCard> Words { get; set; }
        public WordBook Book { get; set; }
        public WordCard CurrentWord { get; set; }
    }
}

using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class WordBookItemsViewModel 
    {
        public WordBook Book { get; set; }
        public int WordsNumber { get; set; }
        public int LearnedWords { get; set; }
    }
}

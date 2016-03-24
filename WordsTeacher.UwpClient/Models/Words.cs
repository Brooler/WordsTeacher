using System;

namespace WordsTeacher.UwpClient.Models
{
    public class WordBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InputLanguage { get; set; }
        public string OutputLanguage { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }

    public class WordCard
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            return String.Format("{0}({1})", Word, Translation);
        }
    }
}

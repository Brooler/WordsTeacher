namespace WordsTeacher.WebApi.Models
{
    public class WordBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InputLanguage { get; set; }
        public string OutputLanguage { get; set; }
    }

    public class WordCard
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public int Score { get; set; }
    }
}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WordsTeacher.UwpClient.Models;
using WordsTeacher.UwpClient.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateWordBookPage : Page
    {
        public CreateBookViewModel VM;
        private WordBook book;
        private bool IsNewBook { get; set; }
        public CreateWordBookPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {
                IsNewBook = true;
                VM=new CreateBookViewModel();
            }
            else
            {
                book = e.Parameter as WordBook;
                IsNewBook = false;
                VM=new CreateBookViewModel()
                {
                    Title=book.Title, InputLang = book.InputLanguage, OutputLang = book.OutputLanguage
                };
            }
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsNewBook)
            {
                WordBook model = new WordBook
                {
                    Title = VM.Title,
                    InputLanguage = VM.InputLang,
                    OutputLanguage = VM.OutputLang
                };
                LoadDataProgress.IsActive = true;
                await WordBooksApiRequest.AddWordBook(model);
                LoadDataProgress.IsActive = false;
            }
            else
            {
                book.Title = VM.Title;
                book.InputLanguage = VM.InputLang;
                book.OutputLanguage = VM.OutputLang;
                LoadDataProgress.IsActive = true;
                await WordBooksApiRequest.UpdateWordBook(book.Id, book);
                LoadDataProgress.IsActive = false;
            }
        }

        
    }
}

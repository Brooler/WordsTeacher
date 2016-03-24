using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WordsTeacher.UwpClient.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateWordBookPage : Page
    {
        public CreateWordBookPage()
        {
            this.InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            WordBook book = new WordBook()
            {
                Title = this.Title.Text,
                InputLanguage = this.InputLangage.Text,
                OutputLanguage = this.OutputLanguage.Text
            };
            LoadDataProgress.IsActive = true;
            await WordBooksApiRequest.AddWordBook(book);
            LoadDataProgress.IsActive = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage));
        }
    }
}

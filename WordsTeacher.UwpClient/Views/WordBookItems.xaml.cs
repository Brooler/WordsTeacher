using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
    public sealed partial class WordBookItems : Page
    {
        private ObservableCollection<WordBookItemsViewModel> Books { get; set; } = new ObservableCollection<WordBookItemsViewModel>();

        public WordBookItems()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadingBar.IsIndeterminate = true;
            LoadingBar.ShowPaused = false;
            await BooksInitialize();
            LoadingBar.IsIndeterminate = false;
            LoadingBar.Visibility = Visibility.Collapsed;
        }

        private async Task BooksInitialize()
        {
            IEnumerable<WordCard> cards = await WordCardsApiRequest.GetWordCardsList();
            foreach (var item in await WordBooksApiRequest.GetWordBooksList())
            {
                var book = new WordBookItemsViewModel()
                {
                    Book=item,
                    WordsNumber = cards.Where(m => m.BookId == item.Id).Count()
                };
                Books.Add(book);
            }
        }
        //Add Button
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateWordCardPage));
        }
        //Edit Button
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateWordBookPage), 
                ((WordBookItemsViewModel)BooksList.SelectedItem).Book);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem != null)
            {
                Header.Text = BooksList.SelectedItem.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage));
        }
    }
}

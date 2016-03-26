using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WordsTeacher.UwpClient.Models;
using WordsTeacher.UwpClient.ViewModels;
using WordsTeacher.UwpClient.Views;

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
        //Edit Button (HyperLink)
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            WordBook model = Books.FirstOrDefault(m => m.Book.Id == (int)((HyperlinkButton) sender).Tag).Book;
            Frame.Navigate(typeof (CreateWordBookPage), model);
        }
        //Add Button (HyperLink)
        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            WordBook model = Books.FirstOrDefault(m => m.Book.Id == (int) ((HyperlinkButton) sender).Tag).Book;
            Frame.Navigate(typeof (CreateWordCardPage), model);
        }

        private void HyperlinkButton_Click_2(object sender, RoutedEventArgs e)
        {
            WordBook model = Books.FirstOrDefault(m => m.Book.Id == (int)((HyperlinkButton)sender).Tag).Book;
            Frame.Navigate(typeof (DeleteWordBookPage), model);
        }

        private void BooksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof (WordCardItems), BooksList.SelectedItem);
        }

        private void BooksList_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(WordCardItems), (BooksList.SelectedItem as WordBookItemsViewModel).Book);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateWordBookPage));
        }
    }
}

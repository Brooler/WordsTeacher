using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await BooksInitialize();
        }

        private async Task BooksInitialize()
        {
            IEnumerable<WordCard> cards = await WordCardsApiRequest.GetWordCardsList();
            foreach (var item in await WordBooksApiRequest.GetWordBooksList())
            {

                var book = new WordBookItemsViewModel()
                {
                    Title = item.Title,
                    InputLanguage = item.InputLanguage,
                    OutputLanguage = item.OutputLanguage,
                    WordsNumber = cards.Where(m => m.BookId == item.Id).Count()
                };
                Books.Add(book);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (CreateWordCardPage));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (CreateWordBookPage));
        }
    }
}

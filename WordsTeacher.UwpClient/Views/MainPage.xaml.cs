using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WordsTeacher.UwpClient.Models;
using WordsTeacher.UwpClient.ViewModels;
using WordsTeacher.UwpClient.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<WordBookItemsViewModel> Books { get; set; } = new ObservableCollection<WordBookItemsViewModel>();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadingProgress.IsIndeterminate = true;
            LoadingProgress.ShowPaused = false;
            LoadingProgress.ShowError = false;
            foreach (var item in await WordBooksApiRequest.GetWordBooksList())
            {
                IEnumerable<WordCard> cards =
                    (await WordCardsApiRequest.GetWordCardsList()).Where(m => m.BookId == item.Id);
                Books.Add(new WordBookItemsViewModel
                {
                    Book=item,
                    WordsNumber = cards.Count(),
                    LearnedWords = cards.Where(m=>m.Score==100).Count()
                });
            }
            LoadingProgress.ShowPaused = true;
            LoadingProgress.Visibility=Visibility.Collapsed;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (WordBookItems));
        }

        private async void ListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            WordBook book = (BooksList.SelectedItem as WordBookItemsViewModel).Book;
            List<WordCard> cards = (await WordCardsApiRequest.GetWordCardsList()).Where(m=>m.BookId==book.Id).ToList();
            if (cards != null)
            {
                while (cards.Count > 10)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(0, cards.Count());
                    cards.Remove(cards[index]);
                }
                TestViewModel model = new TestViewModel
                {
                    Book = book,
                    Words = cards
                };
                Frame.Navigate(typeof (TestPage), model);
            }
        }
    }
}

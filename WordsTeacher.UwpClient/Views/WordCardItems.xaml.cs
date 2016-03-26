using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WordsTeacher.UwpClient.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WordCardItems : Page
    {
        private ObservableCollection<WordCard> WordCards = new ObservableCollection<WordCard>();
        private int BookId;
        public WordCardItems()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadingProgress.IsIndeterminate = true;
            LoadingProgress.ShowPaused = false;
            LoadingProgress.ShowError = false;
            foreach (var item in
                    (await WordCardsApiRequest.GetWordCardsList())
                    .Where(m => m.BookId == 
                    (e.Parameter as WordBook).Id))
            {
                WordCards.Add(item);
            }
            Header.Text = (e.Parameter as WordBook).Title;
            BookId = (e.Parameter as WordBook).Id;
            LoadingProgress.ShowPaused = true;
            LoadingProgress.Visibility = Visibility.Collapsed;
        }
        //Edit Button
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            WordCard model = WordCards.FirstOrDefault(m => m.Id == (int) ((HyperlinkButton) sender).Tag);
            Frame.Navigate(typeof (CreateWordCardPage), model);
        }
        //Delete Button
        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            WordCard model = WordCards.FirstOrDefault(m => m.Id == (int)((HyperlinkButton)sender).Tag);
            Frame.Navigate(typeof (DeleteWordCard), model);
        }
        //Add Button (AppBar)
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateWordCardPage), await WordBooksApiRequest.GetWordBook(BookId));
        }
        //Edit Button (AppBar)
        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (CreateWordBookPage), await WordBooksApiRequest.GetWordBook(BookId));
        }
    }
}

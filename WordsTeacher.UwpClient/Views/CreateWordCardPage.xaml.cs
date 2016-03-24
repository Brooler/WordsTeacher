using System;
using System.Collections.Generic;
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
using WordsTeacher.UwpClient.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateWordCardPage : Page
    {
        EditWordCardViewModel VM = new EditWordCardViewModel();
        public CreateWordCardPage()
        {
            this.InitializeComponent();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadingListRing.IsActive = true;
            await VM.BooksInitialize();
            LoadingListRing.IsActive = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            WordCard card = new WordCard()
            {
                Score=0,
                Word = VM.Word,
                Translation = VM.Translation,
                BookId = VM.books.FirstOrDefault(m=>m.Title==BookSelect.SelectedItem.ToString()).Id
            };
            Header.Text = "Loading...";
            await WordCardsApiRequest.AddWordCard(card);
            Header.Text = "Ready!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage));
        }
    }
}

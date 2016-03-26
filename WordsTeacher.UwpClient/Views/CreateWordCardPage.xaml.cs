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
using WordsTeacher.UwpClient.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateWordCardPage : Page
    {
        WordCard VM;
        private bool IsNewCard;
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
            VM = e.Parameter as WordCard;
            if (VM != null)
            {
                WordBookTitle.Text = (await WordBooksApiRequest.GetWordBooksList()).FirstOrDefault(m => m.Id == VM.Id).Title;
                IsNewCard = false;
            }
            else
            {
                VM = new WordCard();
                VM.BookId = (e.Parameter as WordBook).Id;
                WordBookTitle.Text = (e.Parameter as WordBook).Title;
                IsNewCard = true;
            }
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SubmitDataProgress.IsActive = true;
            if (IsNewCard)
            {
                await WordCardsApiRequest.AddWordCard(VM);
                Frame.Navigate(typeof (WordCardItems), await WordBooksApiRequest.GetWordBook(VM.BookId));
            }
            else
            {
                await WordCardsApiRequest.UpdateWordCard(VM.Id, VM);
                Frame.Navigate(typeof(WordBookItems));
            }
            SubmitDataProgress.IsActive = false;
        }
        
    }
}

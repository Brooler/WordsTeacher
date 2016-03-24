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

namespace WordsTeacher.UwpClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeleteWordBookPage : Page
    {
        DeleteWordBookViewModel VM = new DeleteWordBookViewModel();
        public DeleteWordBookPage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadBooksTitle.IsActive = true;
            await VM.TitlesInitializer();
            LoadBooksTitle.IsActive = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            WordBook book = (WordBook)BookSelector.SelectedItem;
            DeleteProgress.IsActive = true;
            await WordBooksApiRequest.DeleteWordBook(book.Id);
            DeleteProgress.IsActive = false;
            ResultText.Text = String.Format("{0} was deleted.", book.Title);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage));
        }
    }
}

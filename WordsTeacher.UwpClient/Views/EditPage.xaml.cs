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
using WordsTeacher.UwpClient.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsTeacher.UwpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        public EditPage()
        {
            this.InitializeComponent();
        }

        private void AddWordBook_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (CreateWordBookPage));
        }

        private void AddWordCard_Click(object sender, RoutedEventArgs e)
        {
            //this.LoadingBar.ShowPaused = false;
            this.Frame.Navigate(typeof (CreateWordCardPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.LoadingBar.ShowPaused = false;
            this.Frame.Navigate(typeof (WordBookItems));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (DeleteWordBookPage));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (DeleteWordCard));
        }
    }
}

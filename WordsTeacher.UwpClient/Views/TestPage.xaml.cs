using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class TestPage : Page
    {
        private TestViewModel VM = new TestViewModel();
        private int ScoreValue { get; set; } = 10;
        public TestPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            VM = e.Parameter as TestViewModel;
            CurrentCardSelect();
        }

        private void CurrentCardSelect()
        {
            Random rnd = new Random();
            VM.CurrentWord = VM.Words[rnd.Next(VM.Words.Count)];
            VM.Words.Remove(VM.CurrentWord);
        }
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsRightAnswer(TranslationText.Text))
            {
                NextItem.Background = new SolidColorBrush(Colors.LightGreen);
                ScoreUp();
            }
            else
            {
                NextItem.Background=new SolidColorBrush(Colors.LightCoral);
            }
            AnswerButton.Visibility = Visibility.Collapsed;
            NextItem.Visibility=Visibility.Visible;
            TranslationText.IsReadOnly = true;
        }

        private bool IsRightAnswer(string answer)
        {
            if (VM.CurrentWord.Translation == answer) return true;
            else return false;
        }

        private async void ScoreUp()
        {
            VM.CurrentWord.Score += ScoreValue;
            await WordCardsApiRequest.UpdateWordCard(VM.CurrentWord.Id, VM.CurrentWord);
        }

        private void NextItem_Click(object sender, RoutedEventArgs e)
        {
            if (CanSelectNextItem())
            {
                CurrentCardSelect();
                ViewRefresh();
            }
            else
            {
                Frame.Navigate(typeof (MainPage));
            }
        }

        private void ViewRefresh()
        {
            NextItem.Visibility=Visibility.Collapsed;
            AnswerButton.Visibility=Visibility.Visible;
            WordText.Text = VM.CurrentWord.Word;
            TranslationText.IsReadOnly = false;
            TranslationText.Text = "";
        }

        private bool CanSelectNextItem()
        {
            if (!(VM.Words.Count == 0)) return true;
            else return false;
        }
    }
}

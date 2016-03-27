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
        private bool IsFirstSubmitClick = true;
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

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsRightAnswer() && IsFirstSubmitClick)
            {
                SubmitButton.Background = new SolidColorBrush(Colors.LightGreen);
                TranslationText.IsReadOnly = true;
                IsFirstSubmitClick = false;
            }
            else if (IsFirstSubmitClick)
            {
                SubmitButton.Background = new SolidColorBrush(Colors.LightCoral);
                TranslationText.IsReadOnly = true;
                IsFirstSubmitClick = false;
            }
            if (!IsFirstSubmitClick)
            {
                SubmittingProgress.IsActive = true;
                if (IsRightAnswer())
                {
                    VM.CurrentWord.Score += 10;
                    await WordCardsApiRequest.UpdateWordCard(VM.CurrentWord.Id, VM.CurrentWord);
                }
                if (VM.Words.Count > 0)
                {
                    CurrentCardSelect();
                }
                WordText.Text = VM.CurrentWord.Word;
                IsFirstSubmitClick = true;
                SubmittingProgress.IsActive = false;
                TranslationText.IsReadOnly = false;
            }
        }

        private void CurrentCardSelect()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, VM.Words.Count);
            VM.CurrentWord = VM.Words[index];
            VM.Words.Remove(VM.Words[index]);
        }
        private bool IsRightAnswer()
        {
            if (TranslationText.Text == VM.CurrentWord.Translation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

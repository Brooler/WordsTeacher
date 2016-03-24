using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsTeacher.UwpClient.Models;

namespace WordsTeacher.UwpClient.ViewModels
{
    public class DeleteWordCardsViewModel
    {
        public ObservableCollection<WordCard> Cards { get; set; }

        public async Task CardsInitializer()
        {
            Cards=new ObservableCollection<WordCard>();
            foreach (var item in await WordCardsApiRequest.GetWordCardsList())
            {
                Cards.Add(item);
            }
        } 
    }
}

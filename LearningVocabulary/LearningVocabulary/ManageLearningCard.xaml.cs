using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LearningVocabularyLib;
namespace UngDungHocTu
{
    /// <summary>
    /// Interaction logic for ManageLearningCard.xaml
    /// </summary>
    public partial class ManageLearningCard : Window
    {
        public ManageLearningCard()
        {
            InitializeComponent();

            //Binding gridDeck with data
            Global.Deck.BalanceLearningCardWithUnlearnedCard();
            RefreshGridDeck();
        }

        private void RefreshGridDeck()
        {
            gridDecks.ItemsSource = null;
            gridDecks.ItemsSource = Global.Deck.LearningCards;
        }
        private void butCreateRandomList_Click(object sender, RoutedEventArgs e)
        {
            Global.Deck.ResetLearningDeckWithRandomCards();
            RefreshGridDeck();
        }

        private void butAddCardFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            AddCardFromDatabase _addCardFromDatabase = new AddCardFromDatabase();
            _addCardFromDatabase.ShowDialog();
            int count;
            if (_addCardFromDatabase.SelectionCards != null)
            {
                count = 0;
                foreach (Card card in _addCardFromDatabase.SelectionCards)
                {
                    if (Global.Deck.LearningCards.Count < Global.Setting.WordLimit)
                    {
                        Global.Deck.MoveUnlearnedCardToLearningDeck(card);
                        count++;
                    }
                }
                MessageBox.Show("Đã thêm " + count.ToString() + " từ vào danh sách học !");
                RefreshGridDeck();
            }
        }

        private void butFillListWithRandomCard_Click(object sender, RoutedEventArgs e)
        {
            Global.Deck.BalanceLearningCardWithUnlearnedCard();
            RefreshGridDeck();
        }

        private void butReturnDatabase_Click(object sender, RoutedEventArgs e)
        {
            foreach(Card card in gridDecks.SelectedItems)
            {
                Global.Deck.MoveLearningCardToUnlearnedDeck(card);
            }
            RefreshGridDeck();
        }
    }
}

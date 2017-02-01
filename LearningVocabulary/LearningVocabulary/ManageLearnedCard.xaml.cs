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
    /// Interaction logic for ManageLearnedCard.xaml
    /// </summary>
    public partial class ManageLearnedCard : Window
    {
        public ManageLearnedCard()
        {
            InitializeComponent();
            gridDecks.ItemsSource = Global.Deck.LearnedCards;
        }

        private void butMoveBackToDatabase_Click(object sender, RoutedEventArgs e)
        {
            int count;
            count = 0;
            
                foreach (Card card in gridDecks.SelectedItems)
                {
                    count++;
                    Global.Deck.MoveBackLearnedCardToUnlearnedDeck(card);
                }
                MessageBox.Show("Đã chuyển " + count.ToString() + " từ đã nhớ về CSDL từ !");
                gridDecks.ItemsSource = null;
                gridDecks.ItemsSource = Global.Deck.LearnedCards;
            this.Close();   
        }
    }
}

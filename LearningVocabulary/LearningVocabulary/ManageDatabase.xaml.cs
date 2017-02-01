using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LearningVocabularyLib;
using UngDungHocTu;
namespace LearningVocabulary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManageDatabase : Window
    {
        
        public ManageDatabase()
        {
            
            InitializeComponent();
            RefreshGridDeck();

        }

        private void RefreshGridDeck()
        {
            gridDecks.ItemsSource = null;
            gridDecks.ItemsSource = Global.Deck.UnlearnedCards;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Deck.BalanceLearningCardWithUnlearnedCard();
            Global.Deck.SaveDataToXMLFile("Store.xml");
        }

        private void butImportDatabase_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            
            string fileName;
            dialog.Filter = "XML |*.xml";
            if (dialog.ShowDialog()== true)
            {
                fileName = dialog.FileName;
                MessageBox.Show("Đã nhập " + Global.Deck.ImportDatabase(fileName).ToString() + " từ mới !");

                //gridDecks.Items.Refresh();
                RefreshGridDeck();
            }

        }

        private void butExportDatabase_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            string fileName;
            dialog.Filter = "XML |*.xml";
            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;
                Global.Deck.SaveDataToXMLFile(fileName);
            }
        }

        private void butCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtPronunication.Text);
        }

        private void butManageLearnedCard_Click(object sender, RoutedEventArgs e)
        {
            ManageLearnedCard _manageLearnedCard = new ManageLearnedCard();
            _manageLearnedCard.ShowDialog();
            RefreshGridDeck();

        }

        private void butManageLearningCard_Click(object sender, RoutedEventArgs e)
        {
            ManageLearningCard _manageLearningCard = new ManageLearningCard();
            _manageLearningCard.ShowDialog();
            RefreshGridDeck();
        }

        private void butPronunication_Click(object sender, RoutedEventArgs e)
        {
            PronunciationWindow pronunciationWindow = new PronunciationWindow();
            pronunciationWindow.Show();
        }

    }
}

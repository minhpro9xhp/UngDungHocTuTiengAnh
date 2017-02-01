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
using LearningVocabulary;

namespace UngDungHocTu
{
  
    public partial class ManageWindow : Window
    {
        Card _selectedCard = new Card();
        string _selectedDeck = "LearningCards";
        string _alphabetical_order = "ascending_order";
        private BitmapImage _ascending_order_icon = new BitmapImage(new Uri(System.IO.Path.GetFullPath("Resources/Buttons/ascending_order.png")));
        private BitmapImage _descending_order_icon = new BitmapImage(new Uri(System.IO.Path.GetFullPath("Resources/Buttons/descending_order.png")));

        // Can cai thien ham matchWord de tim chinh xac hon
        private bool matchWord(string _word, string _finding_word)
        {
            if (_word.ToLower().Contains(_finding_word.ToLower())) return true;
            else return false;
        }

        private Border _border_card_UI(Card _card)
        {
            StackPanel _stackPanel = new StackPanel();
            _stackPanel.Children.Add(new TextBlock() { Text = _card.Word, FontSize = 22 });
            _stackPanel.Children.Add(new TextBlock() { Text = _card.Pronunication, Foreground = Brushes.Gray, Margin = new Thickness(20, 0, 0, 3) });
            _stackPanel.Children.Add(new TextBlock() { Text = _card.FirstMeaning, Foreground = Brushes.Gray, Margin = new Thickness(25, 0, 0, 3) });
            Border _border = new Border();
            _border.Child = _stackPanel;
            _border.MouseEnter += _border_MouseEnter;
            _border.MouseLeave += _border_MouseLeave;
            _border.MouseLeftButtonDown += _border_MouseLeftButtonDown;

            return _border;
        }

        //Sap xep Deck theo ascending_order hoac descending_order
        private void SortDeck(string deck, string order)
        {
            switch(deck){
                case "LearningCards": 
                    if (order == "descending_order") Global.Deck.LearningCards.Sort(delegate (Card x, Card y) { return y.Word.CompareTo(x.Word); });
                    else Global.Deck.LearningCards.Sort(delegate (Card x, Card y) { return x.Word.CompareTo(y.Word); });
                    break;
                case "UnlearnedCards":
                    if (order == "descending_order") Global.Deck.UnlearnedCards.Sort(delegate (Card x, Card y) { return y.Word.CompareTo(x.Word); });
                    else Global.Deck.UnlearnedCards.Sort(delegate (Card x, Card y) { return x.Word.CompareTo(y.Word); });
                    break;
                case "LearnedCards":
                    if (order == "descending_order") Global.Deck.LearnedCards.Sort(delegate (Card x, Card y) { return y.Word.CompareTo(x.Word); });
                    else Global.Deck.LearnedCards.Sort(delegate (Card x, Card y) { return x.Word.CompareTo(y.Word); });
                    break;
                default: return;
            }
        }

        //Cap nhat toan bo deck
        private void UpdateUI(string cmd)
        {
            switch (cmd)
            {
                case "LearningCards":
                    {
                        stackPanelLearningCard.Children.Clear();

                        // Sort LearningCards

                        SortDeck("LearningCards", _alphabetical_order);

                        // Khoi tao cac card tren giao dien 
                        for (int i = 0; i < Global.Deck.LearningCards.Count; i++)
                        {
                            Card _card = Global.Deck.LearningCards[i];

                            Border _border = _border_card_UI(_card);
                            string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                            _border.Uid = "border_" + _word;

                            stackPanelLearningCard.Children.Add(_border);
                            stackPanelLearningCard.Children.Add(new Separator());

                        }
                        textBlockLearningCardCount.Text = "CSDL: " + Global.Deck.LearningCards.Count.ToString() + " từ";
                    }
                    break;

                case "UnlearnedCards":
                    {
                        // Reset
                        stackPanelUnlearnedCard.Children.Clear();

                        // Sort
                        SortDeck("UnlearnedCards", _alphabetical_order);

                        // Create
                        for (int i = 0; i < Global.Deck.UnlearnedCards.Count; i++)
                        {
                            Card _card = Global.Deck.UnlearnedCards[i];

                            Border _border = _border_card_UI(_card);
                            string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                            _border.Uid = "border_" + _word;

                            stackPanelUnlearnedCard.Children.Add(_border);
                            stackPanelUnlearnedCard.Children.Add(new Separator());

                        }
                        textBlockUnlearnedCardCount.Text = "CSDL: " + Global.Deck.UnlearnedCards.Count.ToString() + " từ";
                    }
                    break;
                case "LearnedCards":
                    {
                        // Reset
                        stackPanelLearnedCard.Children.Clear();

                        // Sort
                        SortDeck("LearnedCards", _alphabetical_order);

                        // Create
                        for (int i = 0; i < Global.Deck.LearnedCards.Count; i++)
                        {
                            Card _card = Global.Deck.LearnedCards[i];

                            Border _border = _border_card_UI(_card);
                            string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                            _border.Uid = "border_" + _word;

                            stackPanelLearnedCard.Children.Add(_border);
                            stackPanelLearnedCard.Children.Add(new Separator());

                        }
                        textBlockLearnedCardCount.Text = "CSDL: " + Global.Deck.LearnedCards.Count.ToString() + " từ";
                    }
                    break;
                default: return;
            }
        }

        //Cap nhat deck voi che do tim kiem
        private void UpdateUI(string cmd, string finding_word)
        {
            switch (cmd)
            {
                case "LearningCards":
                    {
                        stackPanelLearningCard.Children.Clear();

                        // Sort LearningCards names in ascending order
                        SortDeck("LearningCards", _alphabetical_order);

                        // Khoi tao cac card tren giao dien 
                        for (int i = 0; i < Global.Deck.LearningCards.Count; i++)
                        {
                            Card _card = Global.Deck.LearningCards[i];
                            if (matchWord(_card.Word, finding_word))
                            {
                                Border _border = _border_card_UI(_card);
                                string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                                _border.Uid = "border_" + _word;

                                stackPanelLearningCard.Children.Add(_border);
                                stackPanelLearningCard.Children.Add(new Separator());
                            }

                        }
                        textBlockLearningCardCount.Text = "CSDL: " + Global.Deck.LearningCards.Count.ToString() + " từ";
                    }
                    break;

                case "UnlearnedCards":
                    {
                        // Reset
                        stackPanelUnlearnedCard.Children.Clear();

                        // Sort
                        SortDeck("UnlearnedCards", _alphabetical_order);

                        // Create
                        for (int i = 0; i < Global.Deck.UnlearnedCards.Count; i++)
                        {
                            Card _card = Global.Deck.UnlearnedCards[i];

                            if (matchWord(_card.Word, finding_word))
                            {
                                Border _border = _border_card_UI(_card);
                                string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                                _border.Uid = "border_" + _word;

                                stackPanelUnlearnedCard.Children.Add(_border);
                                stackPanelUnlearnedCard.Children.Add(new Separator());
                            }

                        }
                        textBlockUnlearnedCardCount.Text = "CSDL: " + Global.Deck.UnlearnedCards.Count.ToString() + " từ";
                    }
                    break;
                case "LearnedCards":
                    {
                        // Reset
                        stackPanelLearnedCard.Children.Clear();

                        // Sort
                        SortDeck("LearnedCards", _alphabetical_order);

                        // Create
                        for (int i = 0; i < Global.Deck.LearnedCards.Count; i++)
                        {
                            Card _card = Global.Deck.LearnedCards[i];

                            if (matchWord(_card.Word, finding_word))
                            {
                                Border _border = _border_card_UI(_card);
                                string _word = ((TextBlock)((StackPanel)_border.Child).Children[0]).Text;

                                _border.Uid = "border_" + _word;

                                stackPanelLearnedCard.Children.Add(_border);
                                stackPanelLearnedCard.Children.Add(new Separator());
                            }

                        }
                        textBlockLearnedCardCount.Text = "CSDL: " + Global.Deck.LearnedCards.Count.ToString() + " từ";
                    } break;
                default: return;
            }
        }

        private void updateStackPanelEditCard_UI(object sender)
        {
            //reset
            updateStackPanelEditCard_UI(new Card());

            //xac dinh card dua tren element UI
            Border _border = (Border)sender;
            string _word = _border.Uid.Split('_')[1];

            switch (getCurrentTabControlCard())
            {
                case "LearningCards":
                    {
                        for(int i = 0; i < Global.Deck.LearningCards.Count; i++)
                        {
                            if(Global.Deck.LearningCards[i].Word == _word)
                            {
                                updateStackPanelEditCard_UI(Global.Deck.LearningCards[i]);
                                _selectedCard = Global.Deck.LearningCards[i];
                                break;
                            }
                        } break;
                    }
                case "UnlearnedCards":
                    {
                        for (int i = 0; i < Global.Deck.UnlearnedCards.Count; i++)
                        {
                            if (Global.Deck.UnlearnedCards[i].Word == _word)
                            {
                                updateStackPanelEditCard_UI(Global.Deck.UnlearnedCards[i]);
                                _selectedCard = Global.Deck.UnlearnedCards[i];
                                break;
                            }
                        }
                        break;
                    }
                case "LearnedCards":
                    {
                        for (int i = 0; i < Global.Deck.LearnedCards.Count; i++)
                        {
                            if (Global.Deck.LearnedCards[i].Word == _word)
                            {
                                updateStackPanelEditCard_UI(Global.Deck.LearnedCards[i]);
                                _selectedCard = Global.Deck.LearnedCards[i];
                                break;
                            }
                        }
                        break;
                    }
            }

        }

        //<!-- Hieu ung khi tuong tuong voi card_UI
        private void _border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Border)sender).Background = Brushes.LightGreen;

            updateStackPanelEditCard_UI(sender);
            stackPanelEditCard.IsEnabled = true;
            changeDockPanelButton("dockPanelEditCard");
        }
        private void _border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = Brushes.White;
            ((Border)sender).Background = null;
        }
        private void _border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = Brushes.LightGreen;
        }
        //-->

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Deck.BalanceLearningCardWithUnlearnedCard();
            Global.Deck.SaveDataToXMLFile("Store.xml");
        }

        private void tabControlCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI(getCurrentTabControlCard());
        }

        private string getCurrentTabControlCard()
        {
            switch (tabControlCard.SelectedIndex)
            {
                case 0: return "LearningCards";
                case 1: return "UnlearnedCards";
                case 2: return "LearnedCards";
                default: return null;
            }
        }

        private void findingButton_Click(object sender, RoutedEventArgs e)
        {
            string finding_word = findingTextBox.Text.ToLower();
            switch (tabControlCard.SelectedIndex)
            {
                case 0: UpdateUI("LearningCards", finding_word); break;
                case 1: UpdateUI("UnlearnedCards", finding_word); break;
                case 2: UpdateUI("LearnedCards", finding_word); break;
                default: return;
            }
        }
        private void findingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string finding_word = findingTextBox.Text.ToLower();
            switch (tabControlCard.SelectedIndex)
            {
                case 0: UpdateUI("LearningCards", finding_word); break;
                case 1: UpdateUI("UnlearnedCards", finding_word); break;
                case 2: UpdateUI("LearnedCards", finding_word); break;
                default: return;
            }
        }
        
        public ManageWindow()
        {
            InitializeComponent();
            UpdateUI(getCurrentTabControlCard());
        }

        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (_selectedDeck)
            {
                case "LearningCards":
                    Global.Deck.LearningCards.Remove(_selectedCard);
                    break;
                case "UnlearnedCards":
                    Global.Deck.UnlearnedCards.Remove(_selectedCard);
                    break;
                case "LearnedCards":
                    Global.Deck.LearnedCards.Remove(_selectedCard);
                    break;
                default: return;
            }

            UpdateUI(_selectedDeck);
            updateStackPanelEditCard_UI(new Card());
            stackPanelEditCard.IsEnabled = false;
        }

        private void butSaveCard_Click(object sender, RoutedEventArgs e)
        {

            Card _card = getCardFromStackPanelEditCard();

            if(_card.Word == null || _card.Word == "")
            {
                return;
            }

            switch (getCurrentTabControlCard())
            {
                case "LearningCards":
                    {
                        Global.Deck.LearningCards.Remove(_selectedCard);
                        Global.Deck.LearningCards.Add(_card);
                    }
                    break;
                case "UnlearnedCards":
                    {
                        Global.Deck.UnlearnedCards.Remove(_selectedCard);
                        Global.Deck.UnlearnedCards.Add(_card);
                    }
                    break;
                case "LearnedCards":
                    {
                        Global.Deck.LearnedCards.Remove(_selectedCard);
                        Global.Deck.LearnedCards.Add(_card);
                    }
                    break;
                default: return;
            }

            _selectedCard = _card;

            UpdateUI(getCurrentTabControlCard());

            changeDockPanelButton("dockPanelNewCard");
            updateStackPanelEditCard_UI(new Card());
            stackPanelEditCard.IsEnabled = false;

        }

        private void butCancelSaveCard_Click(object sender, RoutedEventArgs e)
        {
            changeDockPanelButton("dockPanelNewCard");
            stackPanelEditCard.IsEnabled = false;
            updateStackPanelEditCard_UI(new Card());
        }

        private void butImportDatabase_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            string fileName;
            dialog.Filter = "XML |*.xml";
            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;
                MessageBox.Show("Đã nhập " + Global.Deck.ImportDatabase(fileName).ToString() + " từ mới !");
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

        private void butPronunciationWindow_Click(object sender, RoutedEventArgs e)
        {
            PronunciationWindow pronunciationWindow = new PronunciationWindow();
            pronunciationWindow.ShowDialog();
        }

        private void butCreateNewCard_Click(object sender, RoutedEventArgs e)
        {
            Card _card = getCardFromStackPanelEditCard();

            switch (tabControlCard.SelectedIndex)
            {
                case 0:
                    {
                        Global.Deck.LearningCards.Add(_card);
                        UpdateUI("LearningCards");
                    }
                    break;
                case 1:
                    {
                        Global.Deck.UnlearnedCards.Add(_card);
                        UpdateUI("UnlearnedCards");
                    }
                    break;
                case 2:
                    {
                        Global.Deck.LearnedCards.Add(_card);
                        UpdateUI("LearnedCards");
                    }
                    break;
                default: return;
            }

            stackPanelEditCard.IsEnabled = true;
            updateStackPanelEditCard_UI(new Card());
            changeDockPanelButton("dockPanelNewCard");
        }

        private void butCancelCreateNewCard_Click(object sender, RoutedEventArgs e)
        {
            stackPanelEditCard.IsEnabled = false;
            updateStackPanelEditCard_UI(new Card());
            changeDockPanelButton("dockPanelNewCard");
        }

        private void butExitManageWindow_Click(object sender, RoutedEventArgs e)
        {
            Global.Deck.BalanceLearningCardWithUnlearnedCard();
            Global.Deck.SaveDataToXMLFile("Store.xml");
            Close();
        }

        private void butNewCard_Click(object sender, RoutedEventArgs e)
        {
            stackPanelEditCard.IsEnabled = true;
            updateStackPanelEditCard_UI(new Card());
            changeDockPanelButton("dockPanelCreateCard");
        }

        private void butSetting_Click(object sender, RoutedEventArgs e)
        {
            new SettingWindow().Show();
        }

        private void butAbout_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
        }

        private void butAlphabeticalOrder_Click(object sender, RoutedEventArgs e)
        {
            if (butAlphabeticalOrder_icon.Source == _ascending_order_icon)
            {
                _alphabetical_order = "descending_order";
                UpdateUI(getCurrentTabControlCard());
                butAlphabeticalOrder_icon.Source = _descending_order_icon;
            }
            else
            {
                _alphabetical_order = "ascending_order";
                UpdateUI(getCurrentTabControlCard());
                butAlphabeticalOrder_icon.Source = _ascending_order_icon;
            }
        }


        private Card getCardFromStackPanelEditCard()
        {
            return new Card()
            {
                Word = textBoxEditWord.Text,
                Pronunication = textBoxEditPronunciation.Text,
                FirstExample = textBoxEditFirstExample.Text,
                FirstMeaning = textBoxEditFirstMeaning.Text,
                SecondMeaning = textBoxEditSecondMeaning.Text,
                SecondExample = textBoxEditSecondExample.Text,
                ThirdExample = textBoxEditThirdExample.Text,
                ThirdMeaning = textBoxEditThirdMeaning.Text,
            };
        }

        private void updateStackPanelEditCard_UI(Card _card)
        {
            textBoxEditWord.Text = _card.Word;
            textBoxEditPronunciation.Text = _card.Pronunication;
            textBoxEditFirstExample.Text = _card.FirstExample;
            textBoxEditFirstMeaning.Text = _card.FirstMeaning;
            textBoxEditSecondMeaning.Text = _card.SecondMeaning;
            textBoxEditSecondExample.Text = _card.SecondExample;
            textBoxEditThirdExample.Text = _card.ThirdExample;
            textBoxEditThirdMeaning.Text = _card.ThirdMeaning;
        }

        private void changeDockPanelButton(string cmd)
        {
            switch (cmd)
            {
                case "dockPanelCreateCard": {
                        dockPanelCreateCard.Visibility = Visibility.Visible;
                        dockPanelEditCard.Visibility = Visibility.Collapsed;
                        dockPanelNewCard.Visibility = Visibility.Collapsed;
                    } break;
                case "dockPanelNewCard": {
                        dockPanelCreateCard.Visibility = Visibility.Collapsed;
                        dockPanelEditCard.Visibility = Visibility.Collapsed;
                        dockPanelNewCard.Visibility = Visibility.Visible;
                    } break;
                case "dockPanelEditCard": {
                        dockPanelCreateCard.Visibility = Visibility.Collapsed;
                        dockPanelEditCard.Visibility = Visibility.Visible;
                        dockPanelNewCard.Visibility = Visibility.Collapsed;
                    } break;
                default: return;
            }
        }
    }
}

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
using System.IO;
using System.Collections;

namespace UngDungHocTu
{
    /// <summary>
    /// Interaction logic for PronunciationWindow.xaml
    /// </summary>
    public partial class PronunciationWindow : Window
    {
        string _word = "";
        ArrayList _separatedPositions = new ArrayList();
        ArrayList _syllabes = new ArrayList();

        private void UpdateSyllabesList()
        {
            _syllabes.Clear();
            _separatedPositions.Sort();
            int _pointer = 0;
            for(int i = 0; i < _separatedPositions.Count; i++)
            {
                _syllabes.Add(_word.Substring(_pointer, (int)_separatedPositions[i] - _pointer + 1));
                _pointer = (int)_separatedPositions[i] + 1;
            }
            _syllabes.Add(_word.Substring(_pointer, _word.Length - _pointer));
        }

        private void ResetUI()
        {
            //su dung ham nay khi co tu moi trong textBox

            stackPanelWord.Children.Clear();
            stackPanelSyllabes.Children.Clear();
            _separatedPositions.Clear();
            _syllabes.Clear();
            textBlockCountSyllabes.Text = null;
            

            for (int i = 0; i < _word.Length; i++)
            {
                //Chu cai trong tu
                TextBlock _textBlock = new TextBlock
                {
                    Text = _word[i].ToString(),

                };
                stackPanelWord.Children.Add(_textBlock);

                //Dau gach phan cach
                if (i != _word.Length - 1)
                {
                    Rectangle _textSelect = new Rectangle()
                    {
                        Uid = i.ToString(),
                    };
                    _textSelect.MouseLeftButtonDown += _textSelect_MouseLeftButtonDown;
                    _textSelect.MouseEnter += _textSelect_MouseEnter;
                    _textSelect.MouseLeave += _textSelect_MouseLeave;

                    stackPanelWord.Children.Add(_textSelect);
                }
            }
        }

        private void UpdateUI()
        {
            textBlockCountSyllabes.Text = _syllabes.Count.ToString();

            stackPanelSyllabes.Children.Clear();
            for(int i = 0; i < _syllabes.Count; i++)
            {
                Border _border = new Border();
                TextBlock _textBlock = new TextBlock() { Text = (string)_syllabes[i], };
                _border.Child = _textBlock;
                stackPanelSyllabes.Children.Add(_border);
            }
        }

        private void _textSelect_MouseLeave(object sender, MouseEventArgs e)
        {
            //tim hieu them ve style.trigger
            if (((Rectangle)sender).Fill != Brushes.Green) ((Rectangle)sender).Fill = Brushes.White;     
        }

        private void _textSelect_MouseEnter(object sender, MouseEventArgs e)
        {
            //tim hieu them ve style.trigger
            if (((Rectangle)sender).Fill != Brushes.Green) ((Rectangle)sender).Fill = Brushes.LightGreen;    
        }

        private void _textSelect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Neu chua chia cat tai vi tri nay
            if (((Rectangle)sender).Fill != Brushes.Green)
            {
                ((Rectangle)sender).Fill = Brushes.Green;
               
                _separatedPositions.Add(int.Parse(((Rectangle)sender).Uid));
            }
            else
            {
                ((Rectangle)sender).Fill = Brushes.White;
                
                _separatedPositions.Remove(int.Parse(((Rectangle)sender).Uid)); 
            }

            UpdateSyllabesList();
            UpdateUI();
        }

        public PronunciationWindow()
        {
            InitializeComponent();

            ResetUI();

            
        }

        private void textBoxWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            _word = textBoxWord.Text;
            ResetUI();
        }
    }
}

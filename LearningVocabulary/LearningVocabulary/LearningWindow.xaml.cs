using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LearningVocabularyLib;
using System.Speech.Synthesis;
using System.Windows.Controls;
using UngDungHocTu;

namespace LearningVocabulary
{
    public partial class LearningWindow : Window
    {
        private Card _currentCard;
        private bool _displayMeaning = true;
        private bool _isMouseOverWord;
        private System.Windows.Threading.DispatcherTimer _timerAutoChangeWord;
        private SpeechSynthesizer _speech;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private void UpdateBackground()
        {
            string fullPath;
            try
            {
                fullPath = System.IO.Path.GetFullPath(Global.Setting.BackgroundImageUri);
                backgroundImage.ImageSource = new BitmapImage(new Uri(fullPath));
            }
            catch(Exception)
            {

                //file not exist. Return to default option
                Global.Setting.ResetToDefaultSetting();
                fullPath = System.IO.Path.GetFullPath(Global.Setting.BackgroundImageUri);
                backgroundImage.ImageSource = new BitmapImage(new Uri(fullPath));
                
            }
            Global.Setting.BackgroundImageUri = fullPath;

        }

        private void UpdateMeaning()
        {
            if (_currentCard != null)
            {
                //Display revision date
                if (_currentCard.Revision > 0)
                {
                    this.txtWord.ToolTip = "Từ " + _currentCard.Word + " cần được ôn tập trước thời điểm " + _currentCard.ReviewDate.ToString();
                }
                else
                {
                    this.txtWord.ToolTip = null;
                }
                //Check if pass the revision date
                
                if (DateTime.Now > _currentCard.ReviewDate && _currentCard.Revision >0)
                {
                    this.txtWord.Foreground = Brushes.Red;
                }
                else
                {
                    this.txtWord.Foreground = Brushes.Black;
                }
                this.txtWord.Text = _currentCard.Word;

                if (_currentCard.Pronunication != "")
                {
                    if (_currentCard.Pronunication.Contains("/"))
                    {
                        txtPronunication.Text = _currentCard.Pronunication;
                    }
                    else
                    {
                        txtPronunication.Text = "/" + _currentCard.Pronunication + "/";
                    }
                        txtPronunication.Visibility = Visibility.Visible;
                }
                else
                {
                    txtPronunication.Visibility = Visibility.Collapsed;
                }

                if (_displayMeaning || _isMouseOverWord)
                {
                    int countMeaning = 1;
                    if(_currentCard.FirstMeaning !="")
                    {
                        txtFirstMeaning.Text = countMeaning.ToString() + ". " + _currentCard.FirstMeaning;
                        if(_currentCard.FirstExample != "")
                        {
                            txtFirstMeaning.Foreground = Brushes.Blue; 
                            txtFirstMeaning.ToolTip = _currentCard.FirstExample;
                            
                        }
                        else
                        {
                            txtFirstMeaning.Foreground = Brushes.Black;
                            txtFirstMeaning.ToolTip = null;
                        }
                        txtFirstMeaning.Visibility = Visibility.Visible;
                        countMeaning++;
                    }
                    else
                    {
                        txtFirstMeaning.Visibility = Visibility.Collapsed;
                    }

                    if(_currentCard.SecondMeaning !="")
                    {
                        txtSecondMeaning.Text = countMeaning.ToString() + " ." + _currentCard.SecondMeaning;
                        
                        if(_currentCard.SecondExample != "")
                        {
                            txtSecondMeaning.ToolTip = _currentCard.SecondExample;
                            txtSecondMeaning.Foreground = Brushes.Blue;
                        }
                        else
                        {
                            txtSecondMeaning.Foreground = Brushes.Black;
                            txtSecondMeaning.ToolTip = null;
                        }

                        txtSecondMeaning.Visibility = Visibility.Visible;
                        countMeaning++;
                    }
                    else
                    {
                        txtSecondMeaning.Visibility = Visibility.Collapsed;
                    }
                    
                    if(_currentCard.ThirdMeaning !="")
                    {
                        txtThirdMeaning.Text = countMeaning.ToString() + ". " + _currentCard.ThirdMeaning;
                        if (_currentCard.ThirdExample != "")
                        {
                            txtThirdMeaning.ToolTip = _currentCard.ThirdExample;
                            txtThirdMeaning.Foreground = Brushes.Blue;

                        }
                        else
                        {
                            txtThirdMeaning.Foreground = Brushes.Black;
                            txtThirdMeaning.ToolTip = null;
                        }

                        txtThirdMeaning.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        txtThirdMeaning.Visibility = Visibility.Collapsed;
                    }
                    
                }
                else
                {
                    txtFirstMeaning.Text = "";
                    txtFirstMeaning.Visibility = Visibility.Collapsed;

                    txtSecondMeaning.Text = "";
                    txtSecondMeaning.Visibility = Visibility.Collapsed;

                    txtThirdMeaning.Text = "";
                    txtThirdMeaning.Visibility = Visibility.Collapsed;
                }

            }
            else
            {
                this.txtWord.Text = "Bạn đã học hết từ trong CSDL";
                txtFirstMeaning.Text = "";
                txtSecondMeaning.Text = "";
                txtThirdMeaning.Text = "";
            }
        }
        private void UpdateUI()
        {
            //Update Information
            txtTotalCard.Text = "CSDL: " + Global.Deck.Count.ToString() + " từ";

            UpdateMeaning();

            if (Global.Deck.LastLearningCard != null)
            {
                txtLastCard.Text = Global.Deck.LastLearningCard.Word;
            }
            else
            {
                txtLastCard.Text = "";
            }
            if (Global.Deck.NextLearningCard != null)
            {
                txtNextCard.Text = Global.Deck.NextLearningCard.Word;
            }
            else
            {
                txtNextCard.Text = "";
            }

            UpdateBackground();

        }

        public LearningWindow()
        {
            InitializeComponent();
            
            Global.Setting.LoadSettingDataFromXMLFile("Setting.xml");
            Global.Deck.LoadDataFromXMLFile("Store.xml");
            Global.Deck.BalanceLearningCardWithUnlearnedCard();

            _currentCard = Global.Deck.GetNextReviewCard();
            _displayMeaning = Global.Setting.ChkDisplayMeaning;
            

            //Set up timer

            _timerAutoChangeWord = new System.Windows.Threading.DispatcherTimer();
            _timerAutoChangeWord.Tick += dispatcherTimer_Tick;
            _timerAutoChangeWord.Stop();
            if(Global.Setting.TimeToChangeWord !=0)
            {
                _timerAutoChangeWord.Interval = TimeSpan.FromSeconds(Global.Setting.TimeToChangeWord);
                _timerAutoChangeWord.Start();
            }

            //Set up Speech
            _speech = new SpeechSynthesizer();

            //Set up NotifyIcon
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Icon = new System.Drawing.Icon(System.IO.Path.GetFullPath("Resources\\appicon.ico"), 48, 48);
            _notifyIcon.Text = "Ứng Dụng Học Từ";
            _notifyIcon.Click += _notifyIcon_Click;    
            _notifyIcon.Visible = true;
            UpdateUI();
            UpdateBackground();
            

        }

        private void _notifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Move next word
            if (_currentCard != null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(2));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }
    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void butFeedback5_Click(object sender, RoutedEventArgs e)
        {
            if(_currentCard!=null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(5));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }

        private void butFeedback4_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCard != null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(4));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }

        private void butFeedback3_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCard != null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(3));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }

        private void butFeedback2_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCard != null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(2));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }

        private void butFeedback1_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCard != null) Global.Deck.UpdateReviewDate(_currentCard, new Feedback(1));
            _currentCard = Global.Deck.GetNextReviewCard();
            UpdateUI();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Remove Notify Icon
            _notifyIcon.Visible = false;

            Global.Deck.SaveDataToXMLFile("Store.xml");
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            /*
            ManageDatabase mainWindow = new ManageDatabase();
            mainWindow.ShowDialog();
            */
            new ManageWindow().ShowDialog();
            _timerAutoChangeWord.Stop();
            if (Global.Setting.TimeToChangeWord != 0)
            {
                _timerAutoChangeWord.Start();
            }
            
        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedbackPanel.Visibility = Visibility.Visible;
            blueBar.Visibility = Visibility.Visible;
            _isMouseOverWord = true;
            UpdateUI();
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            butFeedbackPanel.Visibility = Visibility.Collapsed;
            blueBar.Visibility = Visibility.Collapsed;
            _isMouseOverWord = false;
            UpdateUI();
        }

        private void butAbout_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().Show();
            UpdateUI();
        }

        private void butSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            _timerAutoChangeWord.Stop();
            settingWindow.ShowDialog();

            //Reset Setting
            _displayMeaning = Global.Setting.ChkDisplayMeaning;
            
            //Reset timer
            if (Global.Setting.TimeToChangeWord != 0)
            {
                _timerAutoChangeWord.Interval = TimeSpan.FromSeconds(Global.Setting.TimeToChangeWord);
                _timerAutoChangeWord.Start();
            }

            Global.Deck.BalanceLearningCardWithUnlearnedCard();

            UpdateUI(); 
        }

        private void butSpeak_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void imgSpeak_MouseEnter(object sender, MouseEventArgs e)
        {
            if(_currentCard!= null)
            {
                _speech.Speak(_currentCard.Word);
            }
            
        }

        private void butMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // 32,29,26,23,22
        private int butMaxSize = 32;
        private int butMinSize = 22;
        
        private void resetButtonSize()
        {
            butFeedback1.MaxHeight = butMinSize;
            butFeedback2.MaxHeight = butMinSize;
            butFeedback3.MaxHeight = butMinSize;
            butFeedback4.MaxHeight = butMinSize;
            butFeedback5.MaxHeight = butMinSize;

        }
        private void butFeedback5_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedback5.MaxHeight = butMaxSize;
            butFeedback4.MaxHeight = butMaxSize - 3;
            butFeedback3.MaxHeight = butMaxSize - 6;
            butFeedback2.MaxHeight = butMaxSize - 9;
            butFeedback1.MaxHeight = butMaxSize - 10;

        }

        private void butFeedback5_MouseLeave(object sender, MouseEventArgs e)
        {
            resetButtonSize();
        }

        private void butFeedback4_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedback5.MaxHeight = butMaxSize - 3;
            butFeedback4.MaxHeight = butMaxSize;
            butFeedback3.MaxHeight = butMaxSize - 3;
            butFeedback2.MaxHeight = butMaxSize - 6;
            butFeedback1.MaxHeight = butMaxSize - 9;
        }

        private void butFeedback4_MouseLeave(object sender, MouseEventArgs e)
        {
            resetButtonSize();
        }

        private void butFeedback3_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedback5.MaxHeight = butMaxSize - 6;
            butFeedback4.MaxHeight = butMaxSize - 3;
            butFeedback3.MaxHeight = butMaxSize;
            butFeedback2.MaxHeight = butMaxSize - 3;
            butFeedback1.MaxHeight = butMaxSize - 6;
        }

        private void butFeedback3_MouseLeave(object sender, MouseEventArgs e)
        {
            resetButtonSize();
        }

        private void butFeedback2_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedback5.MaxHeight = butMaxSize - 9;
            butFeedback4.MaxHeight = butMaxSize - 6;
            butFeedback3.MaxHeight = butMaxSize - 3;
            butFeedback2.MaxHeight = butMaxSize;
            butFeedback1.MaxHeight = butMaxSize - 3;
        }

        private void butFeedback2_MouseLeave(object sender, MouseEventArgs e)
        {
            resetButtonSize();
        }

        private void butFeedback1_MouseEnter(object sender, MouseEventArgs e)
        {
            butFeedback5.MaxHeight = butMaxSize - 10;
            butFeedback4.MaxHeight = butMaxSize - 9;
            butFeedback3.MaxHeight = butMaxSize - 6;
            butFeedback2.MaxHeight = butMaxSize - 3;
            butFeedback1.MaxHeight = butMaxSize;
        }

        private void butFeedback1_MouseLeave(object sender, MouseEventArgs e)
        {
            resetButtonSize();
        }
    }
}

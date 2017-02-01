using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using LearningVocabularyLib;
using System.Diagnostics;

namespace LearningVocabulary
{

    public partial class SettingWindow : Window
    {
        private bool _displayMeaning = true;
        private int _wordLimit;
        private string _backgroundImageUri;
        private double _backgroundImageOpacity;
        private int _timeToChangeWord;
        private bool _isStartUpWithWindow;
        private bool _isCreateDesktopIcon;
        private void UpdateUI()
        {
            chkDisplayMeaning.IsChecked = _displayMeaning;

            chkRunWhenStartup.IsChecked = _isStartUpWithWindow;
            chkCreateDesktopIcon.IsChecked = _isCreateDesktopIcon;
            cmbWordLimit.SelectedItem = _wordLimit;
            cmbAutoChangeWordTime.SelectedItem = _timeToChangeWord;

            textBoxBackgroundImage.Text = _backgroundImageUri;
            previewBackgroundImage.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(_backgroundImageUri)));
            

        }
        public SettingWindow()
        {
            InitializeComponent();

            _displayMeaning = Global.Setting.ChkDisplayMeaning;
            chkDisplayMeaning.IsChecked = _displayMeaning;
            _wordLimit = Global.Setting.WordLimit;
            _backgroundImageUri = Global.Setting.BackgroundImageUri;
            _timeToChangeWord = Global.Setting.TimeToChangeWord;
            _isStartUpWithWindow = Global.Setting.IsStartUpWithWindow;
            _isCreateDesktopIcon = Global.Setting.ChkCreateDesktopIcon;
            _backgroundImageOpacity = Global.Setting.BackgroundImageOpacity;


            //Init combo Word Limit
            int i;
            for(i=2; i<=100; i++)
            {
                cmbWordLimit.Items.Add(i);
            }

            //Init combo Change Word Time
            for(i=0; i < 3600; i=i+5)
            {
                cmbAutoChangeWordTime.Items.Add(i);
            }
            
              

            UpdateUI();

        }

        private void chkDisplayMeaning_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)chkDisplayMeaning.IsChecked != _displayMeaning)
            {
                _displayMeaning = (bool)chkDisplayMeaning.IsChecked;
                UpdateUI();
            }
        }

        private void chkDisplayMeaning_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)chkDisplayMeaning.IsChecked != _displayMeaning)
            {
                _displayMeaning = (bool)chkDisplayMeaning.IsChecked;
                UpdateUI();
            }
        }

        private void butResetSetting_Click(object sender, RoutedEventArgs e)
        {

            Global.Setting = new Setting();
            Global.Setting.ResetToDefaultSetting();
            _wordLimit = Global.Setting.WordLimit;
            _displayMeaning = Global.Setting.ChkDisplayMeaning;
            _backgroundImageUri = Global.Setting.BackgroundImageUri;
            _backgroundImageOpacity = Global.Setting.BackgroundImageOpacity;
            _isCreateDesktopIcon = Global.Setting.ChkCreateDesktopIcon;
            _isStartUpWithWindow = Global.Setting.IsStartUpWithWindow;
            UpdateUI();
        }

        private void butBackgroundImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.InitialDirectory = System.IO.Path.GetFullPath("Resources/Background");
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 

                _backgroundImageUri = dlg.FileName;
                //textBoxBackgroundImage.Text = dlg.FileName; --> this line is wrong
            }

            UpdateUI();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Global.Setting.ChkDisplayMeaning = _displayMeaning;
            Global.Setting.WordLimit = _wordLimit;
            Global.Setting.BackgroundImageUri = _backgroundImageUri;
            Global.Setting.BackgroundImageOpacity = sliderBackgroundImageOpacity.Value;
            Global.Setting.TimeToChangeWord = _timeToChangeWord;
            Global.Setting.IsStartUpWithWindow = _isStartUpWithWindow;
            Global.Setting.ChkCreateDesktopIcon = _isCreateDesktopIcon;
            Global.Setting.SaveSettingDataToXMLFile("Setting.xml");
        }

        private void cmbWordLimit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _wordLimit = (int)cmbWordLimit.SelectedItem;
        }

        private void cmbAutoChangeWordTime_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _timeToChangeWord = (int)cmbAutoChangeWordTime.SelectedItem;
        }

        private void chkRunWhenStartup_Checked(object sender, RoutedEventArgs e)
        {
            Global.Setting.IsStartUpWithWindow = true;
            Global.Setting.MakeProgramStartWithWindow(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
            _isStartUpWithWindow = true;
            
            
        }

        private void chkRunWhenStartup_Unchecked(object sender, RoutedEventArgs e)
        {
            Global.Setting.IsStartUpWithWindow = false;
            Global.Setting.RemoveProgramStartWithWindow();
            _isStartUpWithWindow = false;
        }

        private void chkCreateDesktopIcon_Checked(object sender, RoutedEventArgs e)
        {
            Global.Setting.ChkCreateDesktopIcon = true;
            Global.Setting.CreateShortcutFile(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            _isCreateDesktopIcon = true;
        }

        private void chkCreateDesktopIcon_Unchecked(object sender, RoutedEventArgs e)
        {
            Global.Setting.ChkCreateDesktopIcon = false;
            Global.Setting.DeleteShortCutFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            _isCreateDesktopIcon = false;
        }

        private void sliderBackgroundImageOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            previewBackgroundImage.Opacity = sliderBackgroundImageOpacity.Value;
            _backgroundImageOpacity = sliderBackgroundImageOpacity.Value - (sliderBackgroundImageOpacity.Value % 0.1);
            textBlockBackgroundImageOpacity.Text = (_backgroundImageOpacity * 100).ToString() + '%';

        }
    }
}

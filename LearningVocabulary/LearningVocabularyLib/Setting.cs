using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using Shell32;
using IWshRuntimeLibrary;


namespace LearningVocabularyLib
{
    [XmlRoot("Setting")]
    public class Setting
    {
        public bool ChkDisplayMeaning;
        public bool ChkCreateDesktopIcon;
        public bool IsStartUpWithWindow;
        public int WordLimit;

        public string BackgroundImageUri;
        public double BackgroundImageOpacity;

        public int TimeToChangeWord; //in seconds

        public void SaveSettingDataToXMLFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName, false);
            XmlSerializer xmlWriter = new XmlSerializer(typeof(Setting));
            xmlWriter.Serialize(writer, this);
            writer.Close();
        }

        public void LoadSettingDataFromXMLFile(string fileName)
        {
            StreamReader reader;
            try
            { 
                    reader = new StreamReader(fileName);

                    XmlSerializer xmlReader = new XmlSerializer(typeof(Setting));
                    Setting tempSetting = (Setting)xmlReader.Deserialize(reader);

                    //Copy data from XML file to this object
                    this.ChkDisplayMeaning = tempSetting.ChkDisplayMeaning;
                    this.WordLimit = tempSetting.WordLimit;
                    this.TimeToChangeWord = tempSetting.TimeToChangeWord;

                    

                //Validate backgroundImageUri
                if (!System.IO.File.Exists(tempSetting.BackgroundImageUri))
                {
                    tempSetting.BackgroundImageUri = AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\Backgrounds\\11.jpg";
                }
                    this.BackgroundImageUri = tempSetting.BackgroundImageUri;
                    this.BackgroundImageOpacity = tempSetting.BackgroundImageOpacity;
                    this.IsStartUpWithWindow = tempSetting.IsStartUpWithWindow;
                    this.ChkCreateDesktopIcon = tempSetting.ChkCreateDesktopIcon;
                    reader.Close();

            }
            catch (Exception)
            {
                ResetToDefaultSetting();
                SaveSettingDataToXMLFile(fileName);
            }

        }
        public void ResetToDefaultSetting()
        {
            this.BackgroundImageUri = System.IO.Path.GetFullPath("Resources/Backgrounds/1.jpg");
            this.BackgroundImageOpacity = 1;
            this.ChkDisplayMeaning = true;
            this.ChkCreateDesktopIcon = true;
            this.IsStartUpWithWindow = false;
            this.WordLimit = 30;
            this.TimeToChangeWord = 0; //seconds
        }
        public void CreateShortcutFile(string appPath, string appName, string destinationPath)
        {
            WshShell wsh = new WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(destinationPath
             + "\\Ung Dung Hoc Tu.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = appPath + appName;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "Ứng Dụng Học Từ";
            shortcut.WorkingDirectory = appPath;
            shortcut.IconLocation = appPath + "/Resources/appicon.ico";
            shortcut.Save();
        }
        
        public void DeleteShortCutFile(string destinationPath)
        {
            if (System.IO.File.Exists(destinationPath + "/" + "Ung Dung Hoc Tu.lnk"))
            {
                System.IO.File.Delete(destinationPath + "/" + "Ung Dung Hoc Tu.lnk");
            }
        }

        
        public void MakeProgramStartWithWindow(string appPath, string appName)
        {
            CreateShortcutFile(appPath, appName, Environment.GetFolderPath(Environment.SpecialFolder.Startup));

            //string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

        }
        public void RemoveProgramStartWithWindow()
        {
            DeleteShortCutFile(Environment.GetFolderPath(Environment.SpecialFolder.Startup));

        }
    }
}

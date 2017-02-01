using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningVocabularyLib
{
    public class Global
    {
        public static Setting Setting;
        public static Deck Deck;
        
        static Global()
        {
            Setting = new Setting();
            Setting.LoadSettingDataFromXMLFile("Setting.xml");
            
            Deck = new Deck(Setting);
        }

        

    }
}

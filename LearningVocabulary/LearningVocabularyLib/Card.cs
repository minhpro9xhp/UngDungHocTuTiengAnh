using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LearningVocabularyLib
{
    [XmlRoot("Card")]
    public class Card
    {
        private string _word;
        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        private string _pronunication;
        public string Pronunication
        {
            get { return _pronunication; }
            set { _pronunication = value; }
        }

        private string _firstMeaning;
        public string FirstMeaning
        {
            get { return _firstMeaning; }
            set { _firstMeaning = value; }
        }
        private string _firstExample;
        public string FirstExample
        {
            get { return _firstExample; }
            set { _firstExample = value; }
        }
        private string _secondMeaning;
        public string SecondMeaning
        {
            get { return _secondMeaning; }
            set { _secondMeaning = value; }
        }
        private string _secondExample;
        public string SecondExample
        {
            get { return _secondExample; }
            set { _secondExample = value; }
        }
        private string _thirdMeaning;

        public string ThirdMeaning
        {
            get { return _thirdMeaning; }
            set { _thirdMeaning = value; }
        }
        public string _thirdExample;
        public string ThirdExample
        {
            get { return _thirdExample; }
            set { _thirdExample = value; }
        }


        public int Revision;



        public DateTime ReviewDate;

        public double EF;
        
                   
        public Card()
        {
            Word = "";
            Pronunication = "";
            FirstMeaning = "";
            FirstExample = "";
            SecondMeaning = "";
            SecondExample = "";
            ThirdMeaning = "";
            ThirdExample = "";
            Revision = 0;
            ReviewDate = System.DateTime.Now;
            EF = 2.5F;
        }
        public void ResetEF()
        {
            this.Revision = 0;
            this.ReviewDate = System.DateTime.Now;
            this.EF = 2.5F;
        }
        public void UpdateReviewDate(Feedback feedback)
        {
            if (this.Revision == 1)
            {
                this.ReviewDate = this.ReviewDate.AddDays(1);
            }
            else if (this.Revision == 2)
            {
                this.ReviewDate = this.ReviewDate.AddDays(6);
            }
            else
            {
                double nextReviewDay;

                
                this.EF = this.EF - 0.8 + 0.28 * feedback.Value - 0.02 * feedback.Value * feedback.Value;
                if (this.EF < 1.3F) this.EF = 1.3F;
                                   
                nextReviewDay = 6 * Math.Pow(this.EF, this.Revision - 2);
                this.ReviewDate = this.ReviewDate.AddDays(nextReviewDay);
            }
        }
    }
    

}

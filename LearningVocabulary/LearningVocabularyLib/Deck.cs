using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace LearningVocabularyLib
{
    [XmlRoot("Deck")]
    public class Deck
    {
        public List<Card> LearningCards;
        public List<Card> LearnedCards;
        public List<Card> DeletedCards;
        public List<Card> UnlearnedCards;
        public Setting Setting;
        public int Count
        {
            get { return LearningCards.Count + UnlearnedCards.Count; }
        }
        private Card _lastLearningCard;
        private Card _currentLearningCard;
        public Card CurrentLearningCard
        {
            get { return _currentLearningCard; }
            set { _currentLearningCard = value; }
        }
        private Card _nextLearningCard;
        public Card NextLearningCard
        {
            get { return _nextLearningCard; }
            set { _nextLearningCard = value; }
        }
        public Card LastLearningCard
        {
            get { return _lastLearningCard; }
            set { _lastLearningCard = value; }
        }
        
        public Deck()
        {
            LearningCards = new List<Card>();
            LearnedCards = new List<Card>();
            DeletedCards = new List<Card>();
            UnlearnedCards = new List<Card>();
            _currentLearningCard = null;
            _lastLearningCard = null;
        }
        
        public Deck(Setting setting)
        {
            this.Setting = setting;
            LearningCards = new List<Card>();
            LearnedCards = new List<Card>();
            DeletedCards = new List<Card>();
            UnlearnedCards = new List<Card>();
            _currentLearningCard = null;
            _lastLearningCard = null;

            //Set up Random mechanism
            _random = new Random((int)(DateTime.Now.Ticks % 10000));
        }
            
        public void SaveDataToXMLFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            XmlSerializer xmlWriter = new XmlSerializer(typeof(Deck));
            xmlWriter.Serialize(writer, this);
            writer.Close();
        }
        public void LoadDataFromXMLFile(string fileName)
        {
            StreamReader reader;
            if (File.Exists(fileName))
            {
                reader = new StreamReader(fileName);

                XmlSerializer xmlReader = new XmlSerializer(typeof(Deck));
                Deck tempDeck = (Deck)xmlReader.Deserialize(reader);

                //Copy data from XML file to this object
                this.LearningCards = tempDeck.LearningCards;
                this.LearnedCards = tempDeck.LearnedCards;
                this.DeletedCards = tempDeck.DeletedCards;
                this.UnlearnedCards = tempDeck.UnlearnedCards;
                this.LastLearningCard = tempDeck.LastLearningCard;
                reader.Close();
            }
            else SaveDataToXMLFile(fileName);
        }
        private delegate int CompareReviseDate(Card a, Card b);
        
        public void DeleteCard(Card card)
        {
            LearningCards.Remove(card);
        }
        public Card GetCardByIndex(int index)
        {
            return LearningCards[index];
        }
        public Card GetCardByWord(string Word)
        {
            foreach(Card card in LearningCards)
            {
                if (card.Word == Word)
                {
                    return card;
                }
            }
            return null;
        }
        public List<Card> GetLearningCards()
        {
            return this.LearningCards;
        }
        public Card GetNextReviewCard()
        {
            this.LearningCards.Sort((Card x, Card y) => x.ReviewDate.CompareTo(y.ReviewDate));
            this.LastLearningCard = this.CurrentLearningCard;
            if (this.LearningCards.Count != 0)
            {
                this.CurrentLearningCard = this.LearningCards[0];
                if(this.Count >=2)
                {
                    this.NextLearningCard = this.LearningCards[1];
                }
                else
                {
                    this.NextLearningCard = null;
                }
            }
            else
            {
                this.CurrentLearningCard = null;
                this.NextLearningCard = null;
            }
            return this.CurrentLearningCard;
        }
        public void BalanceLearningCardWithUnlearnedCard()
        {
            if (LearningCards.Count <= Setting.WordLimit)
            {
                while (LearningCards.Count < Setting.WordLimit && UnlearnedCards.Count > 0 && LearningCards.Count < this.UnlearnedCards.Count)
                {
                    Card tempCard = GetARandomCardFromUnlearnedDeck();
                    if (!LearningCards.Contains(tempCard))
                    {
                        tempCard.ResetEF();
                        LearningCards.Add(tempCard);
                        UnlearnedCards.Remove(tempCard);
                    }
                }
            }
            else
            {
                while(LearningCards.Count > Setting.WordLimit)
                {
                    Card tempCard;
                    tempCard = LearningCards[LearningCards.Count - 1];
                    UnlearnedCards.Add(tempCard);
                    LearningCards.RemoveAt(LearningCards.Count - 1);
                }
            }
        }
        public void UpdateReviewDate(Card card, Feedback feedback)
        {
            card.Revision++;
            switch (feedback.Value)
            {
                case 5:
                    LearnedCards.Add(card);
                    LearningCards.Remove(card);
                    BalanceLearningCardWithUnlearnedCard();
                    break;
                case 4:
                case 3:
                    card.UpdateReviewDate(feedback);
                    break;
                case 2:
                case 1:
                case 0: 
                    //Consider new word
                    card.ResetEF();
                    card.UpdateReviewDate(feedback);
                    break;
            }
            
        }
        public void MoveBackLearnedCardToUnlearnedDeck(Card learnedCard)
        {
            //TODO: add to check if learned card are in Learned Deck
            learnedCard.ResetEF();
            this.UnlearnedCards.Add(learnedCard);
            this.LearnedCards.Remove(learnedCard);
        }
        public void MoveLearningCardToUnlearnedDeck(Card learningCard)
        {
            UnlearnedCards.Add(learningCard);
            LearningCards.Remove(learningCard);

        }
        public void MoveUnlearnedCardToLearningDeck(Card unlearnedCard)
        {
            unlearnedCard.ResetEF();
            LearningCards.Add(unlearnedCard);
            UnlearnedCards.Remove(unlearnedCard);
        }
        
        public int ImportDatabase(string fileName)
        {
            int count;
            count = 0;
            try
            {
                Deck tempDeck = new Deck(Global.Setting);
                tempDeck.LoadDataFromXMLFile(fileName);
                tempDeck.LearningCards.AddRange(tempDeck.UnlearnedCards);
                tempDeck.LearningCards.AddRange(tempDeck.LearnedCards);

                foreach(Card card1 in tempDeck.LearningCards)
                {
                    if(!(LearningCards.Contains(card1) || UnlearnedCards.Contains(card1) || LearnedCards.Contains(card1)))
                    {
                        UnlearnedCards.Add(card1);
                        count++;
                    }
                }
            }
            catch(Exception)
            {
                return 0 ;
            }
            return count;
        }

        private Random _random;
        public Card GetARandomCardFromUnlearnedDeck()
        {
            int index = _random.Next(UnlearnedCards.Count);
            return UnlearnedCards[index];
        }
        public void ResetLearningDeckWithRandomCards()
        {
            foreach (Card card in this.LearningCards)
            {
                UnlearnedCards.Add(card);
            }
            LearningCards = new List<Card>();

            int i;
            Card randomCard;
            for(i=0; i<this.Setting.WordLimit; i++)
            {
                do {
                    randomCard = GetARandomCardFromUnlearnedDeck();
                }
                while (LearningCards.Contains(randomCard));
                LearningCards.Add(randomCard);
                UnlearnedCards.Remove(randomCard);
            }
        }
    }
    

    public class Program
    {
        public static void Main()
        {

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningVocabularyLib;
using System.Threading;
namespace LearningVocabularyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Test Desk, Card
        public void TestMethod1()
        {
            Deck desk = new Deck();
            Card card1 = new Card() { Word = "word1", FirstMeaning = "Meaning1" };
            Thread.Sleep(500);
            Card card2 = new Card() { Word = "word2", FirstMeaning = "Meaning2" };
            Thread.Sleep(500);
            Card card3 = new Card() { Word = "word3", FirstMeaning = "Meaning3" };
            Thread.Sleep(500);
            Card card4 = new Card() { Word = "word4", FirstMeaning = "Meaning4" };
            Thread.Sleep(500);
            Card card5 = new Card() { Word = "word5", FirstMeaning = "Meaning5" };

            desk.AddCard(card1);
            desk.AddCard(card2);
            desk.AddCard(card3);
            desk.AddCard(card4);
            desk.AddCard(card5);

            Card tempCard;

            tempCard = desk.GetNextReviewCard();
            Feedback feedback = new Feedback(4);
            desk.UpdateReviewDate(tempCard, feedback);
            for (int i=0; i<3; i++)
            {
                tempCard = desk.GetNextReviewCard();
                feedback = new Feedback(5);
                desk.UpdateReviewDate(tempCard, feedback);
                
            }
            feedback = new Feedback(3);
            desk.UpdateReviewDate(tempCard, feedback);
            desk.SaveDataToXMLFile("Store.xml");
            desk.LoadDataFromXMLFile("Store.xml");
            Assert.AreEqual(desk.GetNextReviewCard().Word, "word5");
        }
        
    }
}

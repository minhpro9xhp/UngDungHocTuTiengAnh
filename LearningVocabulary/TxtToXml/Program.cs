using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LearningVocabularyLib;
using System.Collections;

namespace TxtToXml
{
    class Program
    {
        static int[] _separatedPositions = { 1, 4 };
        static string _word = "designer";
        static ArrayList syllabes = new ArrayList();

        static void addSyllabe(string word, int index, int last_pos)
        {
            if (index > _separatedPositions.Length - 1)
            {
                syllabes.Add(word.Substring(0, word.Length));
                return;
            }
            else
            {
                syllabes.Add(word.Substring(0, _separatedPositions[index] - last_pos + 1));
                addSyllabe(word.Substring(_separatedPositions[index] + 1), index + 1, _separatedPositions[index] + 1);
            }
        }

        static void Main(string[] args)
        {
            addSyllabe(_word, 0, 0);  
            for(int i = 0; i < syllabes.Count; i++)
            {
                Console.WriteLine(syllabes[i]);
            }
            Console.ReadLine();
        }
        
    }
}

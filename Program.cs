using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace ExamenC_sharp
{
    class Translator
    {

        public enum TypeTrans { English_Ukrnian, Ukranian_English };
        TypeTrans NameTranslator;
        Dictionary<string, List<string>> wordsDict = new Dictionary<string, List<string>>();
        public Translator(TypeTrans type = TypeTrans.English_Ukrnian)
        {
            this.NameTranslator = type;
        }

        public List<string> this[string word]
        {
            get => wordsDict[word];
            set => wordsDict[word] = value;

        }

        public void AddWord(string word, params string[] translate)
        {
            if (!wordsDict.ContainsKey(word))
            {
                wordsDict.Add(word, translate.ToList<string>());
            }
            else
            {
                wordsDict[word].AddRange(translate);
            }
        }

        public void print()
        {
            foreach (var i in wordsDict)
            {

                Console.WriteLine($" {i.Key} : {String.Join(" ", i.Value)}");

            }
        }


        public void DelKey(string word)
        {
            if (wordsDict.ContainsKey(word))
            {
                wordsDict.Remove(word);
            }
        }
        public bool DelValue(string word, string value)
        {
            if (wordsDict.ContainsKey(word))
            {
                if (wordsDict[word].Count > 1)
                {
                    wordsDict[word].Remove(value);
                    return true;
                }
            }
            return false;
        }
       public void WriteTranslator(string fname)
        {
            using (StreamWriter sw = new StreamWriter(fname, false, System.Text.Encoding.Default))
            {
                foreach (var i in wordsDict)
                {
                    sw.WriteLine($"{i.Key} {String.Join(" ", i.Value)}");
                   // sw.WriteLine($"{String.Join(" ", i.Value)}")
                }
            }
        }

        public void ReadTranslator(string fname)
        {
            using (StreamReader sr = new StreamReader(fname, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                   Console.WriteLine($"{String.Join(" ", line)}");
                }
            }
        }


    }




    class Program
    {
        static void Main(string[] args)
        {


            Translator trans = new Translator(Translator.TypeTrans.English_Ukrnian);
            trans.AddWord("eat", "їжа", "пожива");
            trans.AddWord("bike", "велосипед");
            trans.AddWord("apply", "яблуко");
            trans.AddWord("vadim", "вадим");
            trans.AddWord("eat", "хавчик");
            trans.print();
           
            trans.DelKey("bike");
            Console.WriteLine("deleted");
            trans.print();


             string fname = "translator.txt";
             Console.WriteLine("write");
             trans.WriteTranslator(fname);
             Console.WriteLine("read");
             trans.ReadTranslator(fname);
            
            

            /* int quanWord = 0;
             Console.WriteLine("Enter quan word to add translator");
             string word;

              params string[] translator;
                 for (int i = 0; i < quanWord; i++)
                 {
                     Console.WriteLine("enter word");
                     word = Console.ReadLine();

                 }*/

             Dictionary<string, int> result = new Dictionary<string, int>();
             string text = "вадим жив в сарнах и жив в ривному вадим хароший и живе в сарнах";
             string[] arrWords = text.Split(' ');
             foreach(var i in arrWords)
             {
                 Console.WriteLine(i);
             }
             foreach(var  i in arrWords)
             {
                 if (!result.ContainsKey(i))
                 {
                     result.Add(i, arrWords.Count(x => x == i));
                 }
             }
             foreach(var i in result)
             {
                 Console.WriteLine(i);
             }





        }
    }
}

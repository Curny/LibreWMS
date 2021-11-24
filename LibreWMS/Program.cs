using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// WHAT HAS BEEN DONE LATELY:
//
// 2021-11-24, Curny:
// Menu expanded
// Menu Search/List all articles ->  I started to format theoutput

namespace LibreWMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Menu main = new Menu("Main");

            
            // all that in the comment is some trial-code from the very first runs... will be removed later :)))
            //
            //Console.WriteLine(Helper.GetVersion());
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < args.Length; i++)
            //{
            //    sb.Append(args[i]);
            //}
            //Console.WriteLine($"Aufruf: { sb.ToString() }");

            //Console.WriteLine($"ConnectionString: { Helper.CnnVal("SampleDB") }");
            //List<Article> articles = new List<Article>();
            //Console.Write("Enter Article name: ");
            //string request = Console.ReadLine();


            //DB db = new DB();
            ////articles = db.GetArticleByNamePart(request);
            //articles = db.GetArticleByExactName(request);

            //foreach (var article in articles)
            //{

            //        Console.WriteLine(article.WeightInfo);

            //}

            
            


            //article = db.GetArticle(request);

            //Console.WriteLine(article.ToString());

        }
    }
}

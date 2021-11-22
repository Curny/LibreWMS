using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace LibreWMS
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Menu main = new Menu("Main");
            


            //article = db.GetArticle(request);

            //Console.WriteLine(article.ToString());

        }
    }
}

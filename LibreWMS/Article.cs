using System;
using System.Collections.Generic;
namespace LibreWMS
{
    public class Article : MeasuresAndWeights
    {
        public long ArticleDBID { get; set; }
        public string ArticleIsActive { get; set; }
        public long ArticleNr { get; set; }
        public string ArticleEANGTIN { get; set; }
        public string ArticleName { get; set; }
        public int ArticleAmountInStock { get; set; }
        public string ArticleStockPlace { get; set; }
        public string ArticleDescription { get; set; }
        public DateTime ArticleCreatedOnDateTime { get; set; }
        public string ArticleCreatedBy { get; set; }
        public DateTime ArticleModifiedOnDateTime { get; set; }
        public string ArticleModifiedBy { get; set; }
        public int ArticleAmountWarning { get; set; }
        public int ArticleAmountReorderLevel { get; set; }
        public int ArticleGroupID { get; set; }

        public string CompactInfo1
        {
            get
            {
                return $"{ ArticleName } { ArticleNr }";
            }
        }

        public string StockInfo1
        {
            get
            {
                
                string cutArtName = string.Empty;

                if (!string.IsNullOrEmpty(ArticleName) && ArticleName.Length < 15)
                {
                    int add = 15 - ArticleName.Length;
                    cutArtName = ArticleName;
                    for (int i = ArticleName.Length; i <= 15; i++)
                    {
                        cutArtName += " ";
                    }
                }
                else if (!string.IsNullOrEmpty(ArticleName) && ArticleName.Length > 15)
                {
                    cutArtName = ArticleName[0..13] + "...";
                }
                else if (string.IsNullOrEmpty(ArticleName))
                {
                    cutArtName = "NO ARTICLE NAME";
                }
                else if (ArticleName.Length == 15)
                {
                    cutArtName = ArticleName + " ";
                }

                string cutEanGtin = string.Empty;
                if (!string.IsNullOrEmpty(ArticleEANGTIN) && ArticleEANGTIN.Length < 13)
                {
                    int add = 13 - ArticleEANGTIN.Length;
                    cutEanGtin = ArticleEANGTIN;
                    for (int i = ArticleEANGTIN.Length; i < 13; i++)
                    {
                        cutEanGtin += " ";
                    }
                }
                else if (!string.IsNullOrEmpty(ArticleEANGTIN) && ArticleEANGTIN.Length > 13)
                {
                    cutEanGtin = ArticleEANGTIN[0..10] + "..."; 
                }
                else if (string.IsNullOrEmpty(ArticleEANGTIN))
                {
                    cutEanGtin = "0000000000000";
                }
                else if (ArticleEANGTIN.Length == 13)
                {
                    cutEanGtin = ArticleEANGTIN;
                }

                // dynamically set appropriate string length for the output-table's column of amount in stock
                string amountInStock = string.Empty;
                for (int i = 0; i < (11 - ArticleAmountInStock.ToString().Length); i++)
                {
                    amountInStock += " ";
                }
                amountInStock += ArticleAmountInStock.ToString();
                // done

                // dynamically set appropriate string length for the output-table's column of stock place
                string stockPlace = string.Empty;
                for (int i = 0; i < (16 - ArticleStockPlace.Length); i++)
                {
                    stockPlace += " ";
                }
                stockPlace += ArticleStockPlace;
                // done

                // dynamically set appropritate string length for Article is active yes or no
                string isActive = ArticleIsActive;
                
                for (int i = ArticleIsActive.Length; i < Menu.HeaderOfColumnIsActive.Length; i++)
                {
                    isActive += " ";
                }                                
                //done


                // dynamically set appropriate string length for the output-table's column of gross weight
                string grossWeightkg = string.Empty;
                for (int i = 0; i < (11 - ArticleWeightGross.ToString().Length); i++)
                {
                    grossWeightkg += " ";
                }
                grossWeightkg += ArticleWeightGross.ToString();
                // done

                // dynamically set appropriate string length for the output-table's column of net weight
                string netWeightkg = string.Empty;
                for (int i = 0; i < (11 - ArticleWeightNet.ToString().Length); i++)
                {
                    netWeightkg += " ";
                }
                netWeightkg += ArticleWeightNet.ToString();
                // done



                // generate string for the output-table (header is in Menu.cs)                
                string output = $" | { ArticleNr.ToString("00000000") } | { cutArtName } " 
                        + $"| { cutEanGtin } | { amountInStock } "
                        + $"| { stockPlace } | { grossWeightkg } | { netWeightkg } | { isActive } |"; 
                
                return output;
                
            }
        }

        public string WeightInfo
        {
            get
            {
                return $"{ArticleName} (Nr: { ArticleNr }) Gross: { ArticleWeightGross }  Net: { ArticleWeightNet }";
            }
        }

        public Article()
        {
        }

        public static void Create()
        {
            Article newArticle = new Article();

                    
                    Console.WriteLine("\n Enter data for new article:\n\n");
                    
                    Console.Write(" >> Article number..... : ");
                    _ = ( long.TryParse(Console.ReadLine(), out long nr) ? newArticle.ArticleNr = nr : 0);
                    Console.Write(" >> Article name....... : ");
                    newArticle.ArticleName = Console.ReadLine();
                    Console.Write(" >> Article description : ");
                    newArticle.ArticleDescription = Console.ReadLine();
                    Console.Write(" >> Article EAN / GTIN (max. 13 chars)  : ");
                    string inputEAN = Console.ReadLine();
                    _ = inputEAN.Length <= 13 ? newArticle.ArticleEANGTIN = inputEAN : newArticle.ArticleEANGTIN = inputEAN[0..13];
                    //newArticle.ArticleEANGTIN = Console.ReadLine();
                    Console.Write(" >> Article stock place : ");
                    newArticle.ArticleStockPlace = Console.ReadLine();
                    Console.Write(" >> Article gross weight: ");
                    _ = ( double.TryParse(Console.ReadLine(), out double gwt) ? newArticle.ArticleWeightGross = gwt : newArticle.ArticleWeightGross = 0.0);
                    Console.Write(" >> Article net weight  : ");
                    _ = ( double.TryParse(Console.ReadLine(), out double nwt) ? newArticle.ArticleWeightNet = nwt : newArticle.ArticleWeightNet = 0.0);
                    newArticle.ArticleWeightTara = (newArticle.ArticleWeightGross - newArticle.ArticleWeightNet);
                    Console.WriteLine($" >> Article tare weight : { newArticle.ArticleWeightTara.ToString() } ");
                    Console.Write(" >> Article height...... : ");
                    _ = ( double.TryParse(Console.ReadLine(), out double ht) ? newArticle.ArticleHeight = ht : newArticle.ArticleHeight = 0.0);
                    Console.Write(" >> Article length...... : ");
                    _ = ( double.TryParse(Console.ReadLine(), out double ln) ? newArticle.ArticleLength = ln : newArticle.ArticleLength = 0.0);
                    Console.Write(" >> Article width....... : ");
                    _ = ( double.TryParse(Console.ReadLine(), out double wd) ? newArticle.ArticleWidth = wd : newArticle.ArticleWidth = 0.0);
                    Console.Write(" >> Article measure unit (cms, inches....) : ");
                    newArticle.ArticleMeasureUnit = Console.ReadLine();
                    newArticle.ArticleVolume = newArticle.ArticleHeight * newArticle.ArticleLength * newArticle.ArticleWidth;
                    Console.WriteLine($" >> Article volume  : { newArticle.ArticleVolume.ToString() } { newArticle.ArticleMeasureUnit.ToString() } ");
                    Console.Write(" >> Article active (yes/no) : ");
                    string input = Console.ReadLine();
                        switch (input.ToLower())
                        {
                            case "yes":
                            case "y":
                            case "j":
                                newArticle.ArticleIsActive = "yes";
                                break;
                            
                            case "no":
                            case "n":
                                newArticle.ArticleIsActive = "no";
                                break;
                            
                            default:
                            break;
                        }
                    Console.Write(" >> Article amount in stock  : ");
                    _ = ( int.TryParse(Console.ReadLine(), out int ais) ? newArticle.ArticleAmountInStock = ais : newArticle.ArticleAmountInStock = 0);
                    Console.Write(" >> Article reorder amount   : ");
                    _ = ( int.TryParse(Console.ReadLine(), out int rol) ? newArticle.ArticleAmountReorderLevel = rol : newArticle.ArticleAmountReorderLevel = 0);
                    Console.Write(" >> Article low stock warn   : ");
                    _ = ( int.TryParse(Console.ReadLine(), out int lsw) ? newArticle.ArticleAmountWarning = lsw : newArticle.ArticleAmountWarning = 0);
                    
                    //TODO
                    newArticle.ArticleCreatedBy = "System";
                    newArticle.ArticleGroupID = 1;

                    newArticle.ArticleCreatedOnDateTime = DateTime.Now;

                    Console.Write("\n\n\n Save new article (y/n)? ");
                    string saveData = Console.ReadLine();
                    if (saveData.ToLower() == "y")
                    {
                        DB sna = new DB();
                        sna.AddNewArticle(newArticle);

                        Console.WriteLine("\n\n New article stored in database.");
                    }
        }

        public static void ListAll()
        {
            
                    List<Article> articles = new List<Article>();
                    DB db = new DB();
                    articles = db.GetAllArticles();
                    
                    
                    Console.WriteLine($" | Art. nr. | Art. name        | EAN / GTIN    | amnt avlble | Location         |   Gross kgs |     Net kgs | {Menu.HeaderOfColumnIsActive} |");
                    Console.WriteLine(" |----------|------------------|---------------|-------------|------------------|-------------|-------------|--------|");
                    foreach (var article in articles)
                    {
                        System.Console.WriteLine(article.StockInfo1);
                    }
                    
                    System.Console.WriteLine($"\n\n\t>>> Total amount of articles in database: { articles.Count.ToString() } <<<");
        }

        public static void ListActive()
        {
            List<Article> activeArticles = new List<Article>();
                    DB gaa = new DB();
                    activeArticles = gaa.GetActiveArticles();
                    
                    
                    Console.WriteLine($" | Art. nr. | Art. name        | EAN / GTIN    | amnt avlble | Location         |   Gross kgs |     Net kgs | {Menu.HeaderOfColumnIsActive} |");
                    Console.WriteLine(" |----------|------------------|---------------|-------------|------------------|-------------|-------------|--------|");
                    foreach (var article in activeArticles)
                    {
                        System.Console.WriteLine(article.StockInfo1);
                    }
                    
                    System.Console.WriteLine($"\n\n\t>>> Total amount of active articles in database: { activeArticles.Count.ToString() } <<<");
        }

        public static void ListInactive()
        {
            List<Article> inactiveArticles = new List<Article>();
                    DB gia = new DB();
                    inactiveArticles = gia.GetInactiveArticles();
                    
                    
                    Console.WriteLine($" | Art. nr. | Art. name        | EAN / GTIN    | amnt avlble | Location         |   Gross kgs |     Net kgs | {Menu.HeaderOfColumnIsActive} |");
                    Console.WriteLine(" |----------|------------------|---------------|-------------|------------------|-------------|-------------|--------|");
                    foreach (var iarticle in inactiveArticles)
                    {
                        System.Console.WriteLine(iarticle.StockInfo1);
                    }
                    
                    System.Console.WriteLine($"\n\n\t>>> Total amount of active articles in database: { inactiveArticles.Count.ToString() } <<<");
        }

    } // end of class
} // end of namespace

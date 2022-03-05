﻿using System;
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
                    cutArtName = ArticleName[0..14] + "...";
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
    }
}

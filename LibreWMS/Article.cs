using System;
namespace LibreWMS
{
    public class Article : MeasuresAndWeights
    {
        public long ArticleDBID { get; set; }
        public string ArticleIsActive { get; set; }
        public long ArticleNumber { get; set; }
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
                return $"{ ArticleName } { ArticleNumber }";
            }
        }

        public string StockInfo1
        {
            get
            {
                
                string cutArtName = string.Empty;

                if (ArticleName.Length < 15)
                {
                    int add = 15 - ArticleName.Length;
                    cutArtName = ArticleName;
                    for (int i = ArticleName.Length; i <= 15; i++)
                    {
                        cutArtName += " ";
                    }
                }
                else if (ArticleName.Length > 15)
                {
                    cutArtName = ArticleName[0..14] + "...";
                }
                                
                string output = $" | { ArticleNumber.ToString("00000000") } | { cutArtName } " 
                        + $"| { string.Format("0000000000000", ArticleEANGTIN) } | { ArticleAmountInStock }\t "
                        + $"| { ArticleStockPlace }\t | { ArticleWeightGross } kg\t | { ArticleWeightNet } kg |"; 
                
                return output;
                
            }
        }

        public string WeightInfo
        {
            get
            {
                return $"{ArticleName} (Nr: { ArticleNumber }) Gross: { ArticleWeightGross }  Net: { ArticleWeightNet }";
            }
        }

        public Article()
        {
        }
    }
}

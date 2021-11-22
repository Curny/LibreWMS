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

using System;
namespace LibreWMS
{
    public class MeasuresAndWeights
    {
        public double ArticleLength { get; set; }
        public double ArticleWidth { get; set; }
        public double ArticleHeight { get; set; }
        public double ArticleVolume { get; set; }
        public string ArticleMeasureUnit { get; set; }

        public double ArticleWeightNet { get; set; }
        public double ArticleWeightGross { get; set; }
        public double ArticleWeightTara { get; set; }

        
        public MeasuresAndWeights()
        {
        }
    }
}

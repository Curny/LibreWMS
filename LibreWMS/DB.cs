using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibreWMS
{
    public class DB
    {

        public List<Article> GetAllArticles()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
                {
                
                 var output = connection.Query<Article>($"select * from Article").ToList();                
                 return output;
                
                }
            }
            catch (System.Exception)
            {            
                throw;
            }
           
        }

        public List<Article> GetActiveArticles()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
                {
                
                 var output = connection.Query<Article>($"select * from Article where ArticleIsActive='yes'").ToList();                
                 return output;
                
                }
            }
            catch (System.Exception)
            {            
                throw;
            }           
        }

        public List<Article> GetInactiveArticles()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
                {
                
                 var output = connection.Query<Article>($"select * from Article where ArticleIsActive='no'").ToList();                
                 return output;                
                }
            }
            catch (System.Exception)
            {            
                throw;
            }
           
        }

        public List<Article> GetArticleByNamePart(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {                
                var output = connection.Query<Article>($"select * from Article where ArticleName like '%{ name }%'").ToList();
                //TODO with procedure: var output = connection.Query<Article>("dbo.GetArticle @ArticleName", new { ArticleName = name }).ToList();
                return output;
            }
        }

        public List<Article> GetArticleByExactName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {            
                var output = connection.Query<Article>($"select * from Article where ArticleName = '{ name }'").ToList();
                //TODO with procedure: var output = connection.Query<Article>("dbo.GetArticle @ArticleName", new { ArticleName = name }).ToList();
                return output;
            }
        }


        public void AddNewArticle(Article newArt)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
                {
                    
                    var sqlStatement = @"
                    INSERT INTO Article
                        (ArticleIsActive,
                        ArticleNr,
                        ArticleEANGTIN,
                        ArticleName,
                        ArticleAmountInStock,
                        ArticleStockPlace,
                        ArticleDescription,
                        ArticleCreatedOnDateTime,
                        ArticleCreatedBy,                        
                        ArticleWeightNet,
                        ArticleWeightGross,
                        ArticleWeightTara,
                        ArticleLength,
                        ArticleWidth,
                        ArticleHeight,
                        ArticleVolume,
                        ArticleMeasureUnit,
                        ArticleAmountWarning,
                        ArticleAmountReorderLevel,
                        ArticleGroupID)

                        VALUES (@ArticleIsActive,
                                @ArticleNr,
                                @ArticleEANGTIN,
                                @ArticleName,
                                @ArticleAmountInStock,
                                @ArticleStockPlace,
                                @ArticleDescription,
                                @ArticleCreatedOnDateTime,
                                @ArticleCreatedBy,
                                @ArticleWeightNet,
                                @ArticleWeightGross,
                                @ArticleWeightTara,
                                @ArticleLength,
                                @ArticleWidth,
                                @ArticleHeight,
                                @ArticleVolume,
                                @ArticleMeasureUnit,
                                @ArticleAmountWarning,
                                @ArticleAmountReorderLevel,
                                @ArticleGroupID)
                    ";

                    connection.Execute(sqlStatement, newArt);
                
                }
            }).Start();
        }
        /* TODO
        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                List<Person> people = new List<Person>();

                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });

                connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);

            }
        }
        */
    }
}

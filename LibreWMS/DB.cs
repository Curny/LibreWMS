using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                
                var output = connection.Query<Article>($"select * from Article").ToList();                
                return output;
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

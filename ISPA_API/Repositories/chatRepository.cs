using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ISPA_API.Models;

namespace ISPA_API.Repositories
{
    public class chatRepository
    {
        private string connectionString;
        public chatRepository()
        {
            connectionString = @"Data Source = .; Initial Catalog = ISPADB; Persist Security Info = True; User ID = sa; Password = jylbnk07";






        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IEnumerable<Chat> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from chat";
                dbConnection.Open();
                return dbConnection.Query<Chat>(sQuery);

            }
        }


        public void Add(Chat chat)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into chat (chat_host, chat_audience, chat_from, chat_message, chat_datetime) values(@chat_host, @chat_audience, @chat_from, @chat_message, @chat_datetime)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, chat);

            }
        }

        public Chat GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from chat where chat_id=@id";
                dbConnection.Open();
                return dbConnection.Query<Chat>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from chat where chat_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Chat chat)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update chat set chat_host=@chat_host, chat_audience=@chat_audience, chat_from=@chat_from, chat_message=@chat_message, chat_datetime=@chat_datetime";
                dbConnection.Open();
                dbConnection.Execute(sQuery, chat);

            }
        }




















    }
}

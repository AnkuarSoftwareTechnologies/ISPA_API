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
    public class podCmtRepository
    {
        private string connectionString;
        public podCmtRepository()
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

        public IEnumerable<podcastComent> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from podcastcoment";
                dbConnection.Open();
                return dbConnection.Query<podcastComent>(sQuery);

            }
        }


        public void Add(podcastComent podcmt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into podcastcoment (podcastcoment_time, podcastcoment_coment, podcastcoment_by, podcastcoment_podcast) values(@podcastcoment_time, @podcastcoment_coment, @podcastcoment_by, @podcastcoment_podcast)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, podcmt);

            }
        }

        public podcastComent GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from podcastcoment where podcastcoment_id=@id";
                dbConnection.Open();
                return dbConnection.Query<podcastComent>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from podcastcoment where podcastcoment_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(podcastComent podcmt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update podcastcoment set podcastcoment_time=@podcastcoment_time, podcastcoment_coment=@podcastcoment_coment, podcastcoment_by=@podcastcoment_by, podcastcoment_podcast=@podcastcoment_podcast where podcastcoment_id=@podcastcoment_id ";
                dbConnection.Open();
                dbConnection.Execute(sQuery, podcmt);

            }
        }

    }
}

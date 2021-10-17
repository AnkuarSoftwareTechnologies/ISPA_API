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
    public class followerRepository
    {
        private string connectionString;
        public followerRepository()
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

        public IEnumerable<Follower> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from follower";
                dbConnection.Open();
                return dbConnection.Query<Follower>(sQuery);

            }
        }

        public void Add(Follower follower)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into follower (follower_audience, follower_program, follower_datetime) values(@follower_audience, @follower_program, @follower_datetime)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, follower);

            }
        }

        public Follower GetById(int followeraudience)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from follower where follower_audience=@followeraudience";
                dbConnection.Open();
                return dbConnection.Query<Follower>(sQuery, new { Id = followeraudience }).FirstOrDefault();
            }
        }

        public void Delete(int followeraudience, int followerprogram)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from follower where follower_audience=@followeraudience and follower_program = @followerprogram";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { audience = followeraudience, program = followerprogram });
            }
        }


    }
}

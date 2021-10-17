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
    public class pollRepository
    {
        private string connectionString;
        public pollRepository()
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

        public IEnumerable<Poll> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from poll";
                dbConnection.Open();
                return dbConnection.Query<Poll>(sQuery);

            }
        }


        public void Add(Poll poll)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into poll (poll_title, poll_opt1, poll_opt2, poll_opt3, poll_opt4, poll_opt1count, poll_opt2count, poll_opt3count, poll_opt4count, poll_active) values(@poll_title, @poll_opt1, @poll_opt2, @poll_opt3, @poll_opt4, @poll_opt1count, @poll_opt2count, @poll_opt3count, @poll_opt4count, @poll_active)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, poll);

            }
        }

        public Poll GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from poll where poll_id=@id";
                dbConnection.Open();
                return dbConnection.Query<Poll>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from poll where poll_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Poll poll)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update poll set poll_title=@poll_title, poll_opt1=@poll_opt1, poll_opt2=@poll_opt2, poll_opt3=@poll_opt3, poll_opt4=@poll_opt4, poll_opt1count=@poll_opt1count, poll_opt2count=@poll_opt2count, poll_opt3count=@poll_opt3count, poll_opt4count=@poll_opt4count, poll_active=@poll_active";
                dbConnection.Open();
                dbConnection.Execute(sQuery, poll);

            }
        }

    }
}

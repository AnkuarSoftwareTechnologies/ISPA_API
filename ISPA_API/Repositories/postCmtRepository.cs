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
    public class postCmtRepository
    {
        private string connectionString;
        public postCmtRepository()
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

        public IEnumerable<postComent> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from postComent";
                dbConnection.Open();
                return dbConnection.Query<postComent>(sQuery);

            }
        }

        public void Add(postComent postcmt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into postComent (postComent_time, postComent_coment, postComent_by, postComent_post) values(@postComent_time, @postComent_coment, @postComent_by, @postComent_post)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, postcmt);

            }
        }

        public postComent GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from postcoment where postcoment_id=@id";
                dbConnection.Open();
                return dbConnection.Query<postComent>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from postcoment where postcoment_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(postComent postcmt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update postComent postComent_time=@postComent_time, postComent_coment=@postComent_coment, postComent_by=@postComent_by, postComent_post=@postComent_post where postcoment_id=@postcoment_id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, postcmt);

            }
        }

    }
}

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
    public class postRepository
    {
        private string connectionString;
        public postRepository()
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

        public IEnumerable<Post> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from post";
                dbConnection.Open();
                return dbConnection.Query<Post>(sQuery);

            }
        }

        public void Add(Post post)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into post (post_title, post_description, post_date, post_by, post_likeCount, post_dislikecount, post_imgpath, post_poll) values(@post_title, @post_description, @post_date, @post_by, @post_likeCount, @post_dislikecount, @post_imgpath, @post_poll)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, post);

            }
        }

        public Post GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from post where post_id=@id";
                dbConnection.Open();
                return dbConnection.Query<Post>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from post where post_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Post post)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update post set post_title=@post_title, post_description=@post_description, post_date=@post_date, post_by=@post_by, post_likeCount=@post_likeCount, post_dislikecount=@post_dislikecount, post_imgpath=@post_imgpath, post_poll=@post_poll where post_id=@post_id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, post);

            }
        }
    }
}

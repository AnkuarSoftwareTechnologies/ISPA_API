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
    public class usersRepository
    {
        private string connectionString;
        public usersRepository()
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

        public IEnumerable<Users> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from users";
                dbConnection.Open();
                return dbConnection.Query<Users>(sQuery);

            }
        }

        public void Add(Users users)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into users (users_name, users_birthdate, users_sex, users_email, users_password, users_phone, users_address, users_picpath, users_role, users_active) values(@users_name, @users_birthdate, @users_sex, @users_email, @users_password, @users_phone, @users_address, @users_picpath, @users_role, @users_active)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, users);

            }
        }



        public Users GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from users where users_id=@id";
                dbConnection.Open();
                return dbConnection.Query<Users>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public string Login(LoginRequest logrqst)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from users where users_email=@email and users_password=@password";
                dbConnection.Open();
                Users usr = dbConnection.Query<Users>(sQuery, new { email = logrqst.email, password = logrqst.password }).FirstOrDefault();
                if (usr == null)
                    return "false";
                else
                return usr.users_role;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from users where users_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Users users)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update users set  users_name=@users_name, users_birthdate=@users_birthdate, users_sex=@users_sex, users_email=@users_email, users_password=@users_password, users_phone=@users_phone, users_address=@users_address, users_picpath=@users_picpath, users_role=@users_role, users_active=@users_active where users_id=@users_id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, users);

            }
        }
    }
}

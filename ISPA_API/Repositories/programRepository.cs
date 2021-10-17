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
    public class programRepository
    {
        private string connectionString;
        public programRepository()
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

        public IEnumerable<Programs> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from program";
                dbConnection.Open();
                return dbConnection.Query< Programs>(sQuery);

            }
        }


        public void Add(Programs program)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into program (program_title, program_description, program_livetime, program_catagory, program_smsnumber, program_callnumber, program_station, program_picpath, program_followcount) values(@program_title, @program_description, @program_livetime, @program_catagory, @program_smsnumber, @program_callnumber, @program_station, @program_picpath, @program_followcount)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, program);

            }
        }

        public  Programs GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from program where program_id=@id";
                dbConnection.Open();
                return dbConnection.Query< Programs>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Programs> GetByFavorite(string favoriteId)
        {
            using (IDbConnection dbConnection = Connection)
            {
               // string sQuery = @"select * from program where program_id=@id";
                string sQuery = @"select * from program where program_id IN (SELECT follower_program FROM follower WHERE follower_audience = @favoriteId )";
                dbConnection.Open();
                //return dbConnection.Query<Programs>(sQuery);
                return dbConnection.Query<Programs>(sQuery, new { Id = favoriteId });
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from program where program_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update( Programs program)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update program set program_title=@program_title, program_description=@program_description, program_livetime=@program_livetime, program_catagory=@program_catagory, program_smsnumber=@program_smsnumber, program_callnumber=@program_callnumber, program_station=@program_station, program_picpath=@program_picpath, program_followcount=@program_followcount where program_id=@program_id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, program);

            }
        }

    }
}

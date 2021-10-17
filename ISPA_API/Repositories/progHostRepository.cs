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
    public class progHostRepository
    {
        private string connectionString;
        public progHostRepository()
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

        public IEnumerable<ProgHost> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from proghost";
                dbConnection.Open();
                return dbConnection.Query<ProgHost>(sQuery);

            }
        }

        public void Add(ProgHost proghost)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into proghost (proghost_program, proghost_host) values(@proghost_program, @proghost_host)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, proghost);

            }
        }

        public ProgHost GetById(int prog)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from proghost where proghost_prog=@prog";
                dbConnection.Open();
                return dbConnection.Query<ProgHost>(sQuery, new { Id = prog }).FirstOrDefault();
            }
        }

        public void Delete(int prog, int host)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from proghost where proghost_program=@prog and proghost_host=@host";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { program = prog, host = host  });
            }
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ISPA_API.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ISPA_API.Repositories
{
    public class podcastRepository
    {
        private string connectionString;
        public static IWebHostEnvironment _environment;
        public podcastRepository()
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


        public async Task<String> UploadFile(FileUploadAPI objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Upload\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "Faild";
                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }


        public IEnumerable<Podcast> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * from podcast";
                dbConnection.Open();
                return dbConnection.Query<Podcast>(sQuery);

            }
        }

        public void Add(Podcast podcast)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"insert into podcast (podcast_title, podcast_description, podcast_filepath, podcast_date, podcast_uploadby, podcast_likecount, podcast_dislikecount, podcast_listencount, podcast_program) values(@podcast_title, @podcast_description, @podcast_filepath, @podcast_date, @podcast_uploadby, @podcast_likecount, @podcast_dislikecount, @podcast_listencount, @podcast_program)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, podcast);

            }
        }

        public void likeIncreement(string podId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update podcast set podcast_likecount = podcast_likecount +1 where podcast_id = @podId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { podId = podId } );

            }
        }

        public void dislikeIncreement(string podId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update podcast set podcast_dislikecount = podcast_dislikecount +1 where podcast_id = @podId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { podId = podId });

            }
        }

        public async Task<string> writeFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks + extension;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return filename;
        }
        public void listenIncreement(string podId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update podcast set podcast_listencount = podcast_listencount +1 where podcast_id = @podId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { podId = podId });

            }
        }

        public Podcast GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from podcast where podcast_id=@id";
                dbConnection.Open();
                return dbConnection.Query<Podcast>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Delete from podcast where podcast_id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Podcast podcast)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update podcast set podcast_title=@podcast_title, podcast_description=@podcast_description, podcast_filepath=@podcast_filepath, podcast_date=@podcast_date, podcast_uploadby=@podcast_uploadby, podcast_likecount=@podcast_likecount, podcast_dislikecount=@podcast_dislikecount, podcast_listencount=@podcast_listencount, podcast_program=@podcast_program";
                dbConnection.Open();
                dbConnection.Execute(sQuery, podcast);

            }
        }


    }
}

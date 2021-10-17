using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPA_API.Models;
using ISPA_API.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.StaticFiles;

namespace ISPA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodcastController : ControllerBase
    {
        private readonly podcastRepository podcastRepo;

        
        public PodcastController()
        {
            podcastRepo = new podcastRepository();
            
        }

        private async Task<string> writeFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length -1];
                filename = DateTime.Now.Ticks + extension;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");
                if(!Directory.Exists(pathBuilt))
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

       [HttpPost]
       [Route("SaveFile")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
       public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await writeFile(file);
            return Ok(result);
               
        }


        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string NameFile)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", NameFile);
            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(filePath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contenttype, Path.GetFileName(filePath));
        }
        


        [HttpGet]
        public IEnumerable< Podcast> Get()
        {
            return podcastRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                podcastRepo.Add(podcast);
            }
        }



        [HttpGet("{id}")]
        public Podcast Get(int id)
        {
            return podcastRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Podcast podcast)
        {
            podcast.podcast_id = id;
            if (ModelState.IsValid)
            {
                podcastRepo.Update(podcast);
            }
        }

        



        [HttpDelete]
        public void Delete(int id)
        {
            podcastRepo.Delete(id);
        }

    }
}

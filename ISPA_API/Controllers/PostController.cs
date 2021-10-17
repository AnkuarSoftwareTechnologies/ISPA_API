using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPA_API.Models;
using ISPA_API.Repositories;

namespace ISPA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly postRepository postRepo;

        public PostController()
        {
            postRepo = new postRepository();
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return postRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                postRepo.Add(post);
            }
        }

        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return postRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post post)
        {
            post.post_id = id;
            if (ModelState.IsValid)
            {
                postRepo.Update(post);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            postRepo.Delete(id);
        }

    }
}

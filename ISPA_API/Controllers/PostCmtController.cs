using ISPA_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPA_API.Repositories;

namespace ISPA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCmtController : ControllerBase
    {
        private readonly postCmtRepository postCmtRepo;

        public PostCmtController()
        {
            postCmtRepo = new postCmtRepository();
        }

        [HttpGet]
        public IEnumerable< postComent> Get()
        {
            return postCmtRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] postComent postcmt)
        {
            if (ModelState.IsValid)
            {
                postCmtRepo.Add(postcmt);
            }
        }

        [HttpGet("{id}")]
        public postComent Get(int id)
        {
            return postCmtRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] postComent postCmt)
        {
            postCmt.postcoment_id = id;
            if (ModelState.IsValid)
            {
                postCmtRepo.Update(postCmt);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            postCmtRepo.Delete(id);
        }

    }
}

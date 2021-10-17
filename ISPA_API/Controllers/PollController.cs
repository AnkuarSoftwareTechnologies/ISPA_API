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
    public class PollController : ControllerBase
    {
        private readonly pollRepository pollRepo;

        public PollController()
        {
            pollRepo = new pollRepository();
        }

        [HttpGet]
        public IEnumerable< Poll> Get()
        {
            return pollRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Poll poll)
        {
            if (ModelState.IsValid)
            {
                pollRepo.Add(poll);
            }
        }

        [HttpGet("{id}")]
        public Poll Get(int id)
        {
            return pollRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Poll poll)
        {
            poll.poll_id = id;
            if (ModelState.IsValid)
            {
                pollRepo.Update(poll);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            pollRepo.Delete(id);
        }

    }
}

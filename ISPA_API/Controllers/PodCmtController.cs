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
    public class PodCmtController : ControllerBase
    {
        private readonly podCmtRepository podCmtRepo;

        public PodCmtController()
        {
            podCmtRepo = new podCmtRepository();
        }

        [HttpGet]
        public IEnumerable< podcastComent> Get()
        {
            return podCmtRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] podcastComent podcmt)
        {
            if (ModelState.IsValid)
            {
                podCmtRepo.Add(podcmt);
            }
        }

        [HttpGet("{id}")]
        public podcastComent Get(int id)
        {
            return podCmtRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] podcastComent podcmt)
        {
            podcmt.podcastcoment_id = id;
            if (ModelState.IsValid)
            {
                podCmtRepo.Update(podcmt);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            podCmtRepo.Delete(id);
        }

    }
}

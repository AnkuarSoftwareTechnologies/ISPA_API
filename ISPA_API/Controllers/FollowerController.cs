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
    public class FollowerController : ControllerBase
    {
        private readonly followerRepository followerRepo;

        public FollowerController()
        {
            followerRepo = new followerRepository();
        }

        [HttpGet]
        public IEnumerable< Follower> Get()
        {
            return followerRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Follower follower)
        {
            if (ModelState.IsValid)
            {
                followerRepo.Add(follower);
            }
        }
    }
}

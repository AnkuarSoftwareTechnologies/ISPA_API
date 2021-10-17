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
    public class UsersController : ControllerBase
    {
        private readonly usersRepository usersRepo;

        public UsersController()
        {
            usersRepo = new usersRepository();
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return usersRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Users users)
        {
            if (ModelState.IsValid)
            {
                usersRepo.Add(users);
                return Ok("Okay");
;            }

            return BadRequest("this is bad request");
        }

        [HttpPost("{email}")]
        public string Login([FromBody] LoginRequest logrqst)
        {
            if (ModelState.IsValid)
            {
                
                return usersRepo.Login(logrqst);
            }
            return "false";
        }

        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return usersRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users users)
        {
            users.users_id = id;
            if (ModelState.IsValid)
            {
                usersRepo.Update(users);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            usersRepo.Delete(id);
        }

    }
}

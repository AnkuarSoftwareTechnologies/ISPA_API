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
    public class ProgramController : ControllerBase
    {
        private readonly programRepository programRepo;

        public ProgramController()
        {
            programRepo = new programRepository();
        }

        [HttpGet]
        public IEnumerable< Programs> Get()
        {
            return programRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody]  Programs program)
        {
            if (ModelState.IsValid)
            {
                programRepo.Add(program);
            }
        }

        [HttpGet("{id}")]
        public  Programs Get(int id)
        {
            return programRepo.GetById(id);
        }

     

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]  Programs program)
        {
            program.program_id = id;
            if (ModelState.IsValid)
            {
                programRepo.Update(program);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            programRepo.Delete(id);
        }

    }
}

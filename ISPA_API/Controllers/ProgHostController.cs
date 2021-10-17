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
    public class ProgHostController : ControllerBase
    {
        private readonly progHostRepository progHostRepo;

        public ProgHostController()
        {
            progHostRepo = new progHostRepository();
        }

        [HttpGet]
        public IEnumerable< ProgHost> Get()
        {
            return progHostRepo.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] ProgHost proghost)
        {
            if (ModelState.IsValid)
            {
                progHostRepo.Add(proghost);
            }
        }

        [HttpDelete]
        public void Delete(int prog, int host)
        {
            progHostRepo.Delete(prog, host);
        }
    }
}

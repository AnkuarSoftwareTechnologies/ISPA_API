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
    public class ChatController : ControllerBase
    {
        private readonly chatRepository chatRepo;

        public ChatController()
        {
            chatRepo = new chatRepository();
        }

        [HttpGet]
        public IEnumerable< Chat> Get()
        {
            return chatRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Chat Get(int id)
        {
            return chatRepo.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Chat chat)
        {
            chat.chat_id = id;
            if(ModelState.IsValid)
            {
                chatRepo.Update(chat);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            chatRepo.Delete(id);
        }


        [HttpPost]
        public void Post([FromBody] Chat chat)
        {
            if (ModelState.IsValid)
            {
                chatRepo.Add(chat);
            }
        }
    }
}

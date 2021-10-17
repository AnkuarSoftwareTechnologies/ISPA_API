using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPA_API.Models
{
    public class FileUploadAPI
    {
        public IFormFile files { get; set; }
    }
}

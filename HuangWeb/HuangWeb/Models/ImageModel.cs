using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HuangWeb.Models
{
    public class ImageModel
    {
        [Required]
        public IFormFile PictureFile { get; set; }

        public string ImageUrl { get; set; }
    }
}

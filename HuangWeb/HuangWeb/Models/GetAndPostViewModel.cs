using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuangWeb.Models
{
    public class GetAndPostViewModel
    {
        [Display(Name="输入一个0-100之间的整数")]
        //[Range(0, 100)]
        [Required]
        public int Value { get; set; }

        [Required]
        [Display(Name = "输入简要说明")]
        public string Info { get; set; }
    }
}

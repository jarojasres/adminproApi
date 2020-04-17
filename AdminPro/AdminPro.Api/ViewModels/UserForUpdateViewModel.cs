using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPro.Api.ViewModels
{
    public class UserForUpdateViewModel
    {
        public string Img { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }
    }
}

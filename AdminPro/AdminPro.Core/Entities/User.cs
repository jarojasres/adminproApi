using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPro.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Img { get; set; }

        public string Role { get; set; }
    }
}

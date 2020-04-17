using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPro.Api.ViewModels
{
    public class DoctorViewModel
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public Guid UserId { get; set; }

        public Guid HospitalId { get; set; }
    }
}

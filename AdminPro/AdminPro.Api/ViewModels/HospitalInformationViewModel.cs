using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPro.Api.ViewModels
{
    public class HospitalInformationViewModel
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public UserInformationViewModel User { get; set; }
        
    }
}

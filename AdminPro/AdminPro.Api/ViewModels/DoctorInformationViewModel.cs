using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPro.Api.ViewModels
{
    public class DoctorInformationViewModel
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public UserInformationViewModel User { get; set; }

        public AssociatedHospitalViewModel Hospital { get; set; }

    }
}

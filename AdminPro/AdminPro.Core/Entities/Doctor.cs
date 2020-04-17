using System;

namespace AdminPro.Core.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public Guid UserId { get; set; }

        public Guid HospitalId { get; set; }

        public User User { get; set; }

        public Hospital Hospital { get; set; }
    }
}

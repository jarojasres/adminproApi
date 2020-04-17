using System;

namespace AdminPro.Core.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}

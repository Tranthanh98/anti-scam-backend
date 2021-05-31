using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class RoleAdmin
    {
        public Guid UserId { get; set; }
        public int RoldId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

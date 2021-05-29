using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string Content { get; set; }
        public Guid? PostId { get; set; }
        public virtual Posts Posts { get; set; }
        public virtual User User { get; set; }
    }
}

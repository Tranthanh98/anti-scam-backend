using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public DateTimeOffset? JoinedDate { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsActive { get; set; } = true;
        public string CodeValidate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<FileAttachment> FileAttachments { get; set; }

    }
}

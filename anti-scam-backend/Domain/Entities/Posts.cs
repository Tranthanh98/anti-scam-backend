using anti_scam_backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class Posts
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public int? View { get; set; }
        public EKindOf? KindOf { get; set; }
        public string Link { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsHighlight { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TypePost> TypePosts { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FileAttachment> Images { get; set; }

    }
}

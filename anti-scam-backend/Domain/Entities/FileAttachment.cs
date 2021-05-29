using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class FileAttachment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ext { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public virtual FileAttachmentData FileAttachmentData { get; set; }
        public Guid? PostId { get; set; }
        public virtual Posts Posts { get; set; }
        public virtual User User { get; set; }
    }
}

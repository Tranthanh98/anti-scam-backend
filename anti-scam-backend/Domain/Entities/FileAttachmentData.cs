using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class FileAttachmentData
    {
        public int FileId { get; set; }
        public byte[] Data { get; set; }
        public virtual FileAttachment FileAttachment { get; set; }
    }
}

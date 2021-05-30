using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class TypePost
    {
        public int Id { get; set; }
        public Guid PostId { get; set; }
        public int TypeId { get; set; }
        public string Object { get; set; }
        public virtual Posts Posts {get;set;}
        public virtual Type Type { get; set; }
    }
}

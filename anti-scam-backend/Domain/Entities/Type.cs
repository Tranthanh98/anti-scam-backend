using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TypePost> TypePosts { get; set; }
    }
}

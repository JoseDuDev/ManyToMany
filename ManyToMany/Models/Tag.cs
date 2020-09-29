using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}

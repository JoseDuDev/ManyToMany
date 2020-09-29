using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}

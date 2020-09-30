using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Models
{
    public class PostTag
    {
        public PostTag() { }

        public PostTag(Guid postId, Guid tagId)
        {
            PostId = postId;
            TagId = tagId;
        }

        public Guid PostId { get; set; }
        public Guid TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}

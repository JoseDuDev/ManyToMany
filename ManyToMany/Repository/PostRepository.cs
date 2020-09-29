using ManyToMany.Data;
using ManyToMany.Interfaces;
using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Repository
{
    public class PostRepository : IPost
    {
        private readonly ManyToManyContext _context;

        public PostRepository(ManyToManyContext context)
        {
            _context = context;
        }
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(Guid Id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == Id);
        }

        public void Insert(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}

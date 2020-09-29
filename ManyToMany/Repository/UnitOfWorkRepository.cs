using ManyToMany.Data;
using ManyToMany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ManyToManyContext _context;
        private IPost _iPost;
        private ITag _iTag;
        public UnitOfWorkRepository(ManyToManyContext context)
        {
            _context = context;
        }

        public IPost Post
        {
            get
            {
                return _iPost = _iPost ?? new PostRepository(_context);
            }
        }

        public ITag Tag
        {
            get
            {
                return _iTag = _iTag ?? new TagRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

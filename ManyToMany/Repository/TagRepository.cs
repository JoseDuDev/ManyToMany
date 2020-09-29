using ManyToMany.Data;
using ManyToMany.Interfaces;
using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Repository
{
    public class TagRepository : ITag
    {
        private readonly ManyToManyContext _context;

        public TagRepository(ManyToManyContext context)
        {
            _context = context;
        }
        public void Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public List<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(Guid Id)
        {
            return _context.Tags.FirstOrDefault(p => p.Id == Id);
        }

        public void Insert(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }
    }
}

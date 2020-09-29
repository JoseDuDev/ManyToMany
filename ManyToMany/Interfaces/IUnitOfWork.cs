using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Interfaces
{
    public interface IUnitOfWork
    {
        public IPost Post { get; }
        public ITag Tag { get; }
        void Save();
    }
}

using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.ViewModels.TagsViewModel
{
    public class TagViewModel
    {
        public TagViewModel() { }

        public TagViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
    }
}

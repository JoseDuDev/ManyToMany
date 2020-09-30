using ManyToMany.ViewModels.TagsViewModel;
using System;
using System.Collections.Generic;

namespace ManyToMany.ViewModels.PostsViewModel
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<TagViewModel> Tags { get; internal set; }
    }
}

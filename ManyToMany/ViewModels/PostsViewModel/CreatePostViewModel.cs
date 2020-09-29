using ManyToMany.ViewModels.TagsViewModel;
using System.Collections.Generic;

namespace ManyToMany.ViewModels.PostsViewModel
{
    public class CreatePostViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<TagViewModel> Tags { get; internal set; }
    }
}

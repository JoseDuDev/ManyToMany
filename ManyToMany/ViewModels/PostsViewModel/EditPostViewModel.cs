using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ManyToMany.ViewModels.PostsViewModel
{
    public class EditPostViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<SelectListItem> Tags { get; internal set; }
        public Guid[] SelectedTags { get; set; }
    }
}

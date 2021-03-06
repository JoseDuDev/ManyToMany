﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManyToMany.ViewModels.PostsViewModel
{
    public class CreatePostViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<SelectListItem> Tags { get; internal set; }
        public string[] SelectedTags { get; set; }
    }
}

using AutoMapper;
using ManyToMany.Models;
using ManyToMany.ViewModels.PostsViewModel;
using ManyToMany.ViewModels.TagsViewModel;

namespace ManyToMany.Helpers
{
    public class Helper : Profile
    {
        public Helper()
        {
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<CreateTagViewModel, Tag>();
            CreateMap<Post, PostViewModel>();
            CreateMap<CreatePostViewModel, Post>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManyToMany.Interfaces;
using ManyToMany.Models;
using ManyToMany.ViewModels.PostsViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManyToMany.Controllers
{
    public class PostsController : Controller
    {
        // GET: PostsController
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Post.GetAll();
            var vm = _mapper.Map<List<PostViewModel>>(model);
            return View(vm);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _unitOfWork.Post.GetById(id);
            var vm = _mapper.Map<PostViewModel>(model);
            return View(vm);
        }

        // GET: PostsController/Create
        public ActionResult Create()
        {
            var tagsFromRepository = _unitOfWork.Tag.GetAll();
            var selectList = new List<SelectListItem>();
            foreach (var item in tagsFromRepository)
            {
                selectList.Add(new SelectListItem(item.Titulo, item.Id.ToString()));
            }
            var vm = new CreatePostViewModel()
            {
                Tags = selectList
            };
            return View(vm);
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostViewModel vm)
        {
            try
            {
                Post post = new Post
                {
                    Titulo = vm.Titulo,
                    Descricao = vm.Descricao
                };
                foreach (var item in vm.SelectedTags)
                {
                    post.PostTags.Add(new PostTag()
                    {
                        TagId = new Guid(item)
                    });
                }
                _unitOfWork.Post.Insert(post);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _unitOfWork.Post.GetById(id);
            var tags = _unitOfWork.Tag.GetAll();
            var selectTags = model.PostTags.Select(x => new Tag()
            {
                Id = x.Tag.Id,
                Titulo = x.Tag.Titulo
            });
            var selectList = new List<SelectListItem>();
            tags.ForEach(i => selectList.Add(new SelectListItem(i.Titulo, i.Id.ToString(), selectTags.Select(x => x.Id.ToString()).Contains(i.Id.ToString()))));
            var vm = new EditPostViewModel()
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Tags = selectList

            };
            return View(vm);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostViewModel vm)
        {
            try
            {
                var post = _unitOfWork.Post.GetById(vm.Id);
                post.Titulo = vm.Titulo;
                post.Descricao = vm.Descricao;
                var selectedTags = vm.SelectedTags;
                var existingTags = post.PostTags.Select(x => x.TagId).ToList();
                var toAdd = selectedTags.Except(existingTags).ToList();
                var toRemove = existingTags.Except(existingTags).ToList();
                var postTags = post.PostTags.Select(x => !toRemove.Contains(x.TagId));

                foreach (var item in toAdd)
                {
                    post.PostTags.Add(new PostTag()
                    {
                        TagId = item,
                        PostId = post.Id
                    });
                }
                _unitOfWork.Save();

                return RedirectToAction("Index", "posts");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _unitOfWork.Post.GetById(id);
            var vm = _mapper.Map<PostViewModel>(model);

            return View(vm);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PostViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Post>(vm);
                
                _unitOfWork.Post.Delete(model);
                _unitOfWork.Save();

                return RedirectToAction("Index", "posts");
            }
            catch
            {
                return View();
            }
        }
    }
}

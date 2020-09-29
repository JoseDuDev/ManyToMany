using System.Collections.Generic;
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
        public ActionResult Details(int id)
        {
            return View();
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
                Tags = selectList;
            };
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Post>(vm);
                _unitOfWork.Post.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Posts");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

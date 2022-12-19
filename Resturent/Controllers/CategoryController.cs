﻿using Microsoft.AspNetCore.Mvc;
using Resturent.Core.Models;
using Resturent.Core.Repositories;

namespace Resturent.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public CategoryController(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return View(category);
        }
    }
}

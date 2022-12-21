using Microsoft.AspNetCore.Mvc;
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
            Category category = _categoryRepository.GetById(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _categoryRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if(category != null)
            {
                _categoryRepository.Delete(category);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

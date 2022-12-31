using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resturent.Core;
using Resturent.Core.Models;
using Resturent.Core.Repositories;

namespace Resturent.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToastNotification _ToastNotification;

        public CategoryController(IUnitOfWork unitOfWork, IToastNotification ToastNotification)
        {
            _ToastNotification = ToastNotification;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Categories.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Category category = _unitOfWork.Categories.GetById(id);
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
                _unitOfWork.Categories.Add(model);
                _unitOfWork.Complete();
                _ToastNotification.AddSuccessToastMessage("Category added successfully !");
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _unitOfWork.Categories.GetById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Edit(model);
                _unitOfWork.Complete();
                _ToastNotification.AddInfoToastMessage("Category edited successfully !");
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        //ajax delete Action
        public IActionResult Delete(int id)
        {
            Category category = _unitOfWork.Categories.GetById(id);
            if(category != null)
            {
                _unitOfWork.Categories.Delete(category);
                _unitOfWork.Complete();
            }

            return Ok();
        }
    }
}

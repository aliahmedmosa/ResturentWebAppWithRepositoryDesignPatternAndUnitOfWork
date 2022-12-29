using Microsoft.AspNetCore.Mvc;
using Resturent.Core;
using Resturent.Core.Models;

namespace Resturent.Controllers
{
    public class MealController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MealController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<Meal> meals = _unitOfWork.Meals.GetMealsIncludeCategory();
            return View(meals);
        }
        [HttpGet]
        public IActionResult Add()
        {
            
            ViewBag.CategorysList = _unitOfWork.Categories.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Meal model)
        {
            uploadImage(model);
            if (ModelState.IsValid)
            {
                _unitOfWork.Meals.Add(model);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Meal meal = _unitOfWork.Meals.GetById(id);
            if (meal != null)
            {
                _unitOfWork.Meals.Delete(meal);
                _unitOfWork.Complete();
            }

            return RedirectToAction(nameof(Index));
        }

        //upload image
        private void uploadImage(Meal model)
        {
            //first do not forget to add enctype="multipart/form-data" to form tag EX: <form asp-action="Create" enctype="multipart/form-data">
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                //upload Image 
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "Images", imageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.Url = imageName;
            }
            else if (model.Url == null && model.Id == null)
            {
                //when not image uploaded
                model.Url = "DefultImage.png";
            }
            else
            {
                //when edit
                model.Url = model.Url;
            }
        }
    }
}

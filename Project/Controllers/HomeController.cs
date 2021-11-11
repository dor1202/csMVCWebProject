using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        #region HomeSite
        public IActionResult HomeScreenShow()
        {
            var model = _repository.GetTop2ReviewedAnimals();
            if (model == null) return Content("A problem with GetTop2ReviewedAnimals method.");
            return View(model);
        }
        #endregion

        #region CatalogSite
        public IActionResult CatalogShow(int CategoryId = 1)
        {
            ViewBag.CurrentCategory = _repository.GetCategoryById(CategoryId);
            ViewBag.Categories = _repository.GetCategories();
            var model = _repository.GetAnimalDataByCategory(CategoryId);
            if (model == null) return Content("A problem with GetAnimalDataByCategory method.");
            return View(model);
        }
        #endregion

        #region AdministratorSite
        public IActionResult AdministratorShow(int CategoryId = 1)
        {
            ViewBag.CurrentCategory = CategoryId;
            ViewBag.Categories = _repository.GetCategories();
            var model = _repository.GetAnimalDataByCategory(CategoryId);
            if (model == null) return Content("A problem with GetAnimalDataByCategory method.");
            return View(model);
        }
        public IActionResult DeleteAnimal(int id)
        {
            var categoryId = _repository.DeleteAnimal(id);
            if(categoryId == null) return Content("A problem with DeleteAnimal method.");
            else return RedirectToAction("AdministratorShow", new { CategoryId = categoryId});
        }
        #endregion

        #region DisplayAnimalSite
        public IActionResult DisplayAnimal(int id)
        {
            var comments = _repository.GetCommentsById(id);
            if(comments == null) return Content("A problem with GetCommentsById method.");
            DisplayModel model = new DisplayModel() { animal = _repository.GetAnimalDataById(id), Comments = comments };
            if (model.animal == null) return Content("A problem with GetAnimalDataById method.");
            return View(model);
        }
        public IActionResult AddComment(int AnimalId, string Input)
        {
            if(AnimalId == 0) return Content("A problem with the AnimalId.");
            if(Input == null || Input == string.Empty) return RedirectToAction("DisplayAnimal", new { id = AnimalId });

            _repository.AddComment(new CommentModel() { Id = AnimalId, Comment = Input });
            return RedirectToAction("DisplayAnimal", new { id = AnimalId });
        }
        #endregion

        #region AddAnimalSite
        public ViewResult AddNewAnimalShow()
        {
            ViewBag.Categories = _repository.GetCategories();
            return View();
        }
        public IActionResult AddNewAnimalToDatabase(AnimalForm animalForm)
        {
            if (ModelState.IsValid && animalForm.CategoryId != 0)
            {
                if (_repository.CheckIfFileIsImage(animalForm.PictureSource))
                {
                    _repository.AddAnimal(animalForm);
                    return RedirectToAction("AdministratorShow");
                }
                ViewBag.FileError = true;
            }
            ViewBag.Categories = _repository.GetCategories();
            ViewBag.CurrentCategory = animalForm.CategoryId;
            return View("AddNewAnimalShow");
        }
        #endregion

        #region EditAnimalSite
        public IActionResult EditScreenShow(int id)
        {
            var animal = _repository.GetAnimalDataById(id);
            if (animal == null) return Content("A problem with GetAnimalDataById method.");

            // Convert for verification attributes.
            var model = new AnimalForm() 
            { 
                AnimalId = id,
                Name = animal.Name,
                Age = animal.Age,
                CategoryId = animal.CategoryId,
                Description = animal.Description
            };

            ViewBag.Categories = _repository.GetCategories();
            ViewBag.CurrentCategory = animal.CategoryId;
            ViewBag.CurrentImage = animal.Photo;
            return View(model);
        }
        public IActionResult EnableChanges(AnimalForm animalForm)
        {
            if (ModelState.IsValid)
            {
                if (animalForm.PictureSource == null)
                {
                    // Keep image:
                    _repository.UpdateAnimalDataWithoutImage(animalForm);
                    return RedirectToAction("AdministratorShow", new { selectOption = animalForm.CategoryId});
                }
                else
                {
                    // Change image:
                    if(_repository.CheckIfFileIsImage(animalForm.PictureSource))
                    {
                        _repository.UpdateAnimalDataWithImage(animalForm);
                        return RedirectToAction("AdministratorShow", new { selectOption = animalForm.CategoryId });
                    }
                    ViewBag.FileError = true;
                }
            }
            ViewBag.Categories = _repository.GetCategories();
            ViewBag.CurrentCategory = animalForm.CategoryId;
            ViewBag.CurrentImage = _repository.GetAnimalDataById(animalForm.AnimalId).Photo;
            return View("EditScreenShow");
        }
        #endregion

    }
}

using Microsoft.AspNetCore.Http;
using Project.Data;
using Project.IServices;
using Project.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project.Repositories
{
    public class MyRepository : IRepository
    {
        private AnimalContext _context;
        private IDataBaseImagesService _imageService;

        public MyRepository(AnimalContext context, IDataBaseImagesService service)
        {
            _context = context;
            _imageService = service;
        }

        #region AnimalMethods
        public IEnumerable<Animal> GetAnimalDataByCategory(int CategoryId)
        {
            var result = _context.Animals.Where(c => c.CategoryId == CategoryId).ToList();
            if (result == null) { Debug.Write("Invalid result GetAnimalDataByCategory method"); return null; }
            return result;
        }
        public Animal GetAnimalDataById(int Id)
        {
            var animal = _context.Animals.Where(c => c.AnimalId == Id).FirstOrDefault();
            if (animal == null) { Debug.Write("Invalid animal GetAnimalDataById method"); return null; }
            return animal;
        }
        public IEnumerable<HomeModel> GetTop2ReviewedAnimals()
        {
            var GroupedList = _context.Comments.GroupBy(c => c.AnimalId)
                                       .Select(c => new { Name = c.Key, Count = c.Count() })
                                       .ToList();

            List<HomeModel> SimpleModelList = new List<HomeModel>();
            foreach (var GroupedItem in GroupedList)
            {
                var animal = GetAnimalDataById(GroupedItem.Name);
                if (animal == null) { Debug.Write("Invalid Id GetTop2ReviewedAnimals method"); return null; }
                SimpleModelList.Add(new HomeModel() { Name = animal.Name, Count = GroupedItem.Count, Content = animal.Description, Photo = animal.Photo });
            }

            var DesencingList = SimpleModelList.OrderByDescending(c => c.Count).ToList();
            return DesencingList.Take(2);
        }
        public int? DeleteAnimal(int Id)
        {
            var animal = _context.Animals.Where(c => c.AnimalId == Id).FirstOrDefault();
            if (animal == null) { Debug.Write("Invalid animal in delete animal method"); return null; }
            int categoryId = animal.CategoryId;
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return categoryId;
        }
        public void AddAnimal(AnimalForm animal)
        {
            byte[] fileBytes = _imageService.GetByteArrayFromImage(animal.PictureSource);

            _context.Animals.Add(new Animal()
            {   
                Photo = fileBytes,
                Age = animal.Age.Value,
                CategoryId = animal.CategoryId,
                Description = animal.Description,
                Name = animal.Name 
            });
            _context.SaveChanges();
        }
        public void UpdateAnimalDataWithoutImage(AnimalForm animal)
        {
            var tmp = _context.Animals.Where(c => c.AnimalId == animal.AnimalId).FirstOrDefault();
            if (tmp == null) return;
            tmp.Age = animal.Age.Value; tmp.CategoryId = animal.CategoryId; tmp.Description = animal.Description;
            tmp.Name = animal.Name;
            _context.SaveChanges();
        }
        public void UpdateAnimalDataWithImage(AnimalForm animal)
        {
            byte[] fileBytes = _imageService.GetByteArrayFromImage(animal.PictureSource);

            var tmp = _context.Animals.Where(c => c.AnimalId == animal.AnimalId).FirstOrDefault();
            if (tmp == null) return;
            tmp.Age = animal.Age.Value; tmp.CategoryId = animal.CategoryId; tmp.Description = animal.Description;
            tmp.Name = animal.Name; tmp.Photo = fileBytes;
            _context.SaveChanges();
        }
        #endregion

        #region CommentMethods
        public IEnumerable<Comment> GetCommentsById(int id) => _context.Comments.Where(c => c.AnimalId == id).ToList();
        public void AddComment(CommentModel review)
        {
            _context.Comments.Add(new Comment() 
            {
                AnimalId = review.Id,
                CommentData = review.Comment 
            });
            _context.SaveChanges();
        }
        #endregion

        #region CategoryMethods
        public IEnumerable<Category> GetCategories() => _context.Categories.ToList();
        public Category GetCategoryById(int id)
        {
            var res = _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            if(res == null) { Debug.Write("Invalid result GetCategoryById method"); return null; }
            return res;
        }
        #endregion

        #region OtherMethods
        public bool CheckIfFileIsImage(IFormFile file) => file != null && (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg"  || file.ContentType == "image/gif" || file.ContentType == "image/png") ? true : false;
        #endregion
    }
}

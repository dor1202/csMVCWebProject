using Microsoft.AspNetCore.Http;
using Project.Models;
using System.Collections.Generic;

namespace Project.Repositories
{
    public interface IRepository
    {
        #region AnimalMethods
        IEnumerable<Animal> GetAnimalDataByCategory(int categoryId);
        Animal GetAnimalDataById(int id);
        void AddAnimal(AnimalForm animal);
        int? DeleteAnimal(int id);
        IEnumerable<HomeModel> GetTop2ReviewedAnimals();
        void UpdateAnimalDataWithoutImage(AnimalForm animal);
        void UpdateAnimalDataWithImage(AnimalForm animal);
        #endregion

        #region CommentMehtods
        IEnumerable<Comment> GetCommentsById(int id);
        void AddComment(CommentModel review);
        #endregion

        #region CategoryMethods
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        #endregion

        #region OtherMethods
        bool CheckIfFileIsImage(IFormFile file);
        #endregion
    }
}

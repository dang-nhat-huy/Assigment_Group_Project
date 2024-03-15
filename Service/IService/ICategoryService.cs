using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll(int? page, int? quantity);
        IEnumerable<Category> GetAll();
        Category? GetById(long id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Save();
    }
}

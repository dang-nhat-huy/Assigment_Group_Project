using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllWithInclude(string field);
        IEnumerable<Category> GetAllWith2Include(string field1, string field2);
        Category? GetById(long id);
        void Add(Category Category);
        void Update(Category Category);
        void Delete(Category Category);
        void Save();
    }
}

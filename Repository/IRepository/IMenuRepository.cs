using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetAll();
        IEnumerable<Menu> GetAllWithInclude(string field);
        IEnumerable<Menu> GetAllWith2Include(string field1, string field2);
        Menu? GetById(long id);
        void Add(Menu menu);
        void Update(Menu menu);
        void Delete(Menu menu);
        void Save();
    }
}

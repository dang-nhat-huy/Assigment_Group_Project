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
        void Add(Menu Menu);
        void Update(Menu Menu);
        void Delete(Menu Menu);
        void Save();
    }
}

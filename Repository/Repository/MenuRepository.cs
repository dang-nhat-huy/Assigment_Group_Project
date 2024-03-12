using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MenuRepository : IMenuRepository
    {
        public void Add(Menu menu) => MenuDAO.Instance.Add(menu);

        public void Delete(Menu menu) => MenuDAO.Instance.Delete(menu);
        public IEnumerable<Menu> GetAll() => MenuDAO.Instance.GetAll();

        public IEnumerable<Menu> GetAllWith2Include(string field1, string field2) => MenuDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Menu> GetAllWithInclude(string field) => MenuDAO.Instance.GetAllWithInclude(field);

        public Menu? GetById(long id) => MenuDAO.Instance.GetById(id);

        public void Save() => MenuDAO.Instance.Save();

        public void Update(Menu menu) => MenuDAO.Instance.Update(menu);
    }
}

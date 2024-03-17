using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IMenuService
    {
        public void Add(Menu product);

        public void Delete(Menu product);

        public IEnumerable<Menu> GetAll();

        public IEnumerable<Menu> GetAll(int? page, int? quantity);

        public Menu? GetById(long id);

        public void Save();

        public void Update(Menu product);

        public IEnumerable<Menu> GetAllWithInclude();
    }
}

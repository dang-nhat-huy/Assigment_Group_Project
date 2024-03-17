using BusinessObject.Models;
using Repository;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public void Add(Menu menu)
        {
            _menuRepository.Add(menu);
        }

        public void Delete(Menu menu)
        {
            _menuRepository.Delete(menu);
        }    

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllWithInclude()
        {            
            return _menuRepository.GetAllWithInclude("Categories").ToList();
        }

        public Menu? GetById(long id)
        {
            return _menuRepository.GetAllWithInclude("Categories").FirstOrDefault(x => x.MenuId == id);
        }

        public IEnumerable<Menu> GetAll(int? page, int? quantity)
        {
            const int defaultPage = 1;
            const int defaultQuantity = 10;

            if (page.HasValue && page <= 0)
            {
                page = defaultPage;
            }
            if (quantity.HasValue && (quantity <= 0 || quantity > int.MaxValue))
            {
                quantity = defaultQuantity;
            }

            int skip = (page.GetValueOrDefault(defaultPage) - 1) * quantity.GetValueOrDefault(defaultQuantity);
            return _menuRepository.GetAllWithInclude("Categories").ToList()
                .Skip(skip)
                .Take((int)quantity!);
        }
        public void Save()
        {
            _menuRepository.Save();
        }

        public void Update(Menu menu)
        {
            _menuRepository.Update(menu);
        }
    }
}

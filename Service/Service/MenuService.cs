using BusinessObject.Models;
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
        private readonly IMenuRepository _productRepository;
        public MenuService(IMenuRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Menu product)
        {
            _productRepository.Add(product);
        }

        public void Delete(Menu product)
        {
            _productRepository.Delete(product);
        }    

        public IEnumerable<Menu> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllWithInclude()
        {            
            return _productRepository.GetAllWithInclude("Categories").ToList();
        }

        public Menu? GetById(long id)
        {
            return _productRepository.GetAllWithInclude("Categories").FirstOrDefault(x => x.MenuId == id);
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public void Update(Menu product)
        {
            _productRepository.Update(product);
        }
    }
}

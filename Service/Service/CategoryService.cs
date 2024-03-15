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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public IEnumerable<Category> GetAll(int? page, int? quantity)
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
            return _categoryRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category? GetById(long id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Save()
        {
            _categoryRepository.Save();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}

using BusinessObject.Models;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services = BusinessObject.Models.Service;

namespace Service.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _servicesRepository;
        public ServicesService(IServiceRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public void Add(Services services)
        {
            _servicesRepository.Add(services);
        }

        public void Delete(Services services)
        {
            _servicesRepository.Delete(services);
        }

        public IEnumerable<Services> GetAll()
        {
            return _servicesRepository.GetAll();
        }

        public IEnumerable<Services> GetAll(int? page, int? quantity)
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
            return _servicesRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public Services? GetById(long id)
        {
            return _servicesRepository.GetById(id);
        }

        public void Save()
        {
            _servicesRepository.Save();
        }

        public void Update(Services services)
        {
            _servicesRepository.Update(services);
        }
    }
}

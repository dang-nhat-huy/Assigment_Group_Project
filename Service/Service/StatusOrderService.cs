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
    public class StatusOrderService : IStatusOrderService
    {
        private readonly IStatusOrderRepository _statusOrderRepository;
        public StatusOrderService(IStatusOrderRepository statusRepository)
        {
            _statusOrderRepository = statusRepository;
        }

        public void Add(StatusOrder status)
        {
            _statusOrderRepository.Add(status);
        }

        public void Delete(StatusOrder status)
        {
            _statusOrderRepository.Delete(status);
        }

        public IEnumerable<StatusOrder> GetAll()
        {
            return _statusOrderRepository.GetAll();
        }

        public IEnumerable<StatusOrder> GetAll(int? page, int? quantity)
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
            return _statusOrderRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public StatusOrder? GetById(long id)
        {
            return _statusOrderRepository.GetById(id);
        }

        public void Save()
        {
            _statusOrderRepository.Save();
        }

        public void Update(StatusOrder status)
        {
            _statusOrderRepository.Update(status);
        }
    }
}

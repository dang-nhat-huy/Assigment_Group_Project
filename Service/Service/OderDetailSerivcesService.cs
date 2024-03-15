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
    public class OderDetailSerivcesService : IOderDetailSerivcesService
    {
        private readonly IOrderDetailServiceRepository _orderDetailServicesRepository;
        public OderDetailSerivcesService(IOrderDetailServiceRepository orderDetailServicesRepository)
        {
            _orderDetailServicesRepository = orderDetailServicesRepository;
        }

        public void Add(OrderDetailService orderDetailServices)
        {
            _orderDetailServicesRepository.Add(orderDetailServices);
        }

        public void Delete(OrderDetailService orderDetailServices)
        {
            _orderDetailServicesRepository.Delete(orderDetailServices);
        }

        public IEnumerable<OrderDetailService> GetAll()
        {
            return _orderDetailServicesRepository.GetAll();
        }

        public IEnumerable<OrderDetailService> GetAll(int? page, int? quantity)
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
            return _orderDetailServicesRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public OrderDetailService? GetById(long id)
        {
            return _orderDetailServicesRepository.GetById(id);
        }

        public void Save()
        {
            _orderDetailServicesRepository.Save();
        }

        public void Update(OrderDetailService orderDetailServices)
        {
            _orderDetailServicesRepository.Update(orderDetailServices);
        }
    }
}

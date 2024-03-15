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
    public class OrderDetailMenuService : IOrderDetailMenuService
    {
        private readonly IOrderDetailMenuRepository _orderDetailMenuRepository;
        public OrderDetailMenuService(IOrderDetailMenuRepository orderDetailMenuRepository)
        {
            _orderDetailMenuRepository = orderDetailMenuRepository;
        }

        public void Add(OrderDetailMenu orderDetailMenu)
        {
            _orderDetailMenuRepository.Add(orderDetailMenu);
        }

        public void Delete(OrderDetailMenu orderDetailMenu)
        {
            _orderDetailMenuRepository.Delete(orderDetailMenu);
        }

        public IEnumerable<OrderDetailMenu> GetAll()
        {
            return _orderDetailMenuRepository.GetAll();
        }

        public IEnumerable<OrderDetailMenu> GetAll(int? page, int? quantity)
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
            return _orderDetailMenuRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public OrderDetailMenu? GetById(long id)
        {
            return _orderDetailMenuRepository.GetById(id);
        }

        public void Save()
        {
            _orderDetailMenuRepository.Save();
        }

        public void Update(OrderDetailMenu orderDetailMenu)
        {
            _orderDetailMenuRepository.Update(orderDetailMenu);
        }
    }
}

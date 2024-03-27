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
    public class UserOrderService : IUserOrderService
    {
        private readonly IUserOrderRepository _userOrderRepository;
        public UserOrderService(IUserOrderRepository userOrderRepository)
        {
            _userOrderRepository = userOrderRepository;
        }
        public IEnumerable<UserOrder> GetAll(int? page, int? quantity)
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
            return _userOrderRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public void Add(UserOrder Order)
        {
            _userOrderRepository.Add(Order);
        }

        public void Delete(UserOrder Order)
        {
            _userOrderRepository.Delete(Order);
        }

        public IEnumerable<UserOrder> GetAll()
        {
            return _userOrderRepository.GetAll();
        }

        public UserOrder? GetById(long id)
        {
            return _userOrderRepository.GetById(id);
        }

        public void Save()
        {
            _userOrderRepository.Save();
        }

        public void Update(UserOrder Order)
        {
            _userOrderRepository.Update(Order);
        }
    }
}

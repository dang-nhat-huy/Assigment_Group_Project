using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IOrderService
    {
        public void Add(Order order);

        public void Delete(Order order);

        public IEnumerable<Order> GetAll();

        public IEnumerable<Order> GetAll(int? page, int? quantity);

        public Order? GetById(long id);

        public void Save();

        public void Update(Order order);
    }
}

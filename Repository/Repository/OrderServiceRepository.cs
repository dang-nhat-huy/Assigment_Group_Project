using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderServiceServiceRepository : IOrderServiceRepository
    {
        public void Add(OrderService orderService) => OrderServiceDAO.Instance.Add(orderService);

        public void Delete(OrderService orderService) => OrderServiceDAO.Instance.Delete(orderService);
        public IEnumerable<OrderService> GetAll() => OrderServiceDAO.Instance.GetAll();

        public IEnumerable<OrderService> GetAllWith2Include(string field1, string field2) => OrderServiceDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<OrderService> GetAllWithInclude(string field) => OrderServiceDAO.Instance.GetAllWithInclude(field);

        public OrderService? GetById(long id) => OrderServiceDAO.Instance.GetById(id);

        public void Save() => OrderServiceDAO.Instance.Save();

        public void Update(OrderService orderService) => OrderServiceDAO.Instance.Update(orderService);
    }
}

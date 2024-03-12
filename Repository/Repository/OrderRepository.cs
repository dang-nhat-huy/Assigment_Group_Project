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
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order) => OrderDAO.Instance.Add(order);

        public void Delete(Order order) => OrderDAO.Instance.Delete(order);
        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetAll();

        public IEnumerable<Order> GetAllWith2Include(string field1, string field2) => OrderDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Order> GetAllWithInclude(string field) => OrderDAO.Instance.GetAllWithInclude(field);

        public Order? GetById(long id) => OrderDAO.Instance.GetById(id);

        public void Save() => OrderDAO.Instance.Save();

        public void Update(Order order) => OrderDAO.Instance.Update(order);
    }
}

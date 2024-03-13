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
    public class OrderServiceServiceRepository : IOrderDetailServiceRepository
    {
        public void Add(OrderDetailService orderDetailService) => OrderDetailServiceDAO.Instance.Add(orderDetailService);

        public void Delete(OrderDetailService orderDetailService) => OrderDetailServiceDAO.Instance.Delete(orderDetailService);
        public IEnumerable<OrderDetailService> GetAll() => OrderDetailServiceDAO.Instance.GetAll();

        public IEnumerable<OrderDetailService> GetAllWith2Include(string field1, string field2) => OrderDetailServiceDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<OrderDetailService> GetAllWithInclude(string field) => OrderDetailServiceDAO.Instance.GetAllWithInclude(field);

        public OrderDetailService? GetById(long id) => OrderDetailServiceDAO.Instance.GetById(id);

        public void Save() => OrderDetailServiceDAO.Instance.Save();

        public void Update(OrderDetailService orderDetailService) => OrderDetailServiceDAO.Instance.Update(orderDetailService);
    }
}

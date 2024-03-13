using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderDetailDetailRepository
    {
        public void Add(OrderDetail orderDetail) => OrderDetailDAO.Instance.Add(orderDetail);

        public void Delete(OrderDetail orderDetail) => OrderDetailDAO.Instance.Delete(orderDetail);
        public IEnumerable<OrderDetail> GetAll() => OrderDetailDAO.Instance.GetAll();

        public IEnumerable<OrderDetail> GetAllWith2Include(string field1, string field2) => OrderDetailDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<OrderDetail> GetAllWithInclude(string field) => OrderDetailDAO.Instance.GetAllWithInclude(field);

        public OrderDetail? GetById(long id) => OrderDetailDAO.Instance.GetById(id);

        public void Save() => OrderDetailDAO.Instance.Save();

        public void Update(OrderDetail orderDetail) => OrderDetailDAO.Instance.Update(orderDetail);
    }
}

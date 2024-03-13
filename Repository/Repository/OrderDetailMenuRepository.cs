using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderDetailMenuRepository
    {
        public void Add(OrderDetailMenu orderDetailMenu) => OrderDetailMenuDAO.Instance.Add(orderDetailMenu);

        public void Delete(OrderDetailMenu orderDetailMenu) => OrderDetailMenuDAO.Instance.Delete(orderDetailMenu);
        public IEnumerable<OrderDetailMenu> GetAll() => OrderDetailMenuDAO.Instance.GetAll();

        public IEnumerable<OrderDetailMenu> GetAllWith2Include(string field1, string field2) => OrderDetailMenuDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<OrderDetailMenu> GetAllWithInclude(string field) => OrderDetailMenuDAO.Instance.GetAllWithInclude(field);

        public OrderDetailMenu? GetById(long id) => OrderDetailMenuDAO.Instance.GetById(id);

        public void Save() => OrderDetailMenuDAO.Instance.Save();

        public void Update(OrderDetailMenu orderDetailMenu) => OrderDetailMenuDAO.Instance.Update(orderDetailMenu);
    }
}

using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IOrderDetailServices
    {
        public void Add(OrderDetail orderDetail);

        public void Delete(OrderDetail orderDetail);

        public IEnumerable<OrderDetail> GetAll();

        public IEnumerable<OrderDetail> GetAll(int? page, int? quantity);

        public OrderDetail? GetById(long id);

        public void Save();

        public void Update(OrderDetail orderDetail);
    }
}

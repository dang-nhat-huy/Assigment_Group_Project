using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderDetailServiceRepository
    {
        IEnumerable<OrderDetailService> GetAll();
        IEnumerable<OrderDetailService> GetAllWithInclude(string field);
        IEnumerable<OrderDetailService> GetAllWith2Include(string field1, string field2);
        OrderDetailService? GetById(long id);
        void Add(OrderDetailService orderDetailService);
        void Update(OrderDetailService orderDetailService);
        void Delete(OrderDetailService orderDetailService);
        void Save();
    }
}

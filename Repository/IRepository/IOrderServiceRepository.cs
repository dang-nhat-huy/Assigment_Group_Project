using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderServiceRepository
    {
        IEnumerable<OrderService> GetAll();
        IEnumerable<OrderService> GetAllWithInclude(string field);
        IEnumerable<OrderService> GetAllWith2Include(string field1, string field2);
        OrderService? GetById(long id);
        void Add(OrderService OrderService);
        void Update(OrderService OrderService);
        void Delete(OrderService OrderService);
        void Save();
    }
}

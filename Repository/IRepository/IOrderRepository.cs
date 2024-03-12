using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllWithInclude(string field);
        IEnumerable<Order> GetAllWith2Include(string field1, string field2);
        Order? GetById(long id);
        void Add(Order Order);
        void Update(Order Order);
        void Delete(Order Order);
        void Save();
    }
}

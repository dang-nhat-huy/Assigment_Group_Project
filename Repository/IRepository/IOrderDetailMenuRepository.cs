using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderDetailMenuRepository
    {
        IEnumerable<OrderDetailMenu> GetAll();
        IEnumerable<OrderDetailMenu> GetAllWithInclude(string field);
        IEnumerable<OrderDetailMenu> GetAllWith2Include(string field1, string field2);
        OrderDetailMenu? GetById(long id);
        void Add(OrderDetailMenu orderDetailMenu);
        void Update(OrderDetailMenu orderDetailMenu);
        void Delete(OrderDetailMenu orderDetailMenu);
        void Save();
    }
}

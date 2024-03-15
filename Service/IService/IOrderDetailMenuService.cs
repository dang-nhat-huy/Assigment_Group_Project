using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IOrderDetailMenuService
    {
        public void Add(OrderDetailMenu orderDetailMenu);

        public void Delete(OrderDetailMenu orderDetailMenu);

        public IEnumerable<OrderDetailMenu> GetAll();

        public IEnumerable<OrderDetailMenu> GetAll(int? page, int? quantity);

        public OrderDetailMenu? GetById(long id);

        public void Save();

        public void Update(OrderDetailMenu orderDetailMenu);
    }
}

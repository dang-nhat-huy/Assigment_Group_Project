using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IOderDetailSerivcesService
    {
        public void Add(OrderDetailService orderDetailServices);

        public void Delete(OrderDetailService orderDetailServices);

        public IEnumerable<OrderDetailService> GetAll();

        public IEnumerable<OrderDetailService> GetAll(int? page, int? quantity);

        public OrderDetailService? GetById(long id);

        public void Save();

        public void Update(OrderDetailService orderDetailServices);
    }
}

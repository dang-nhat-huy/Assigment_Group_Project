using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserOrderService
    {
        public IEnumerable<UserOrder> GetAll(int? page, int? quantity);

        public void Add(UserOrder order);

        public void Delete(UserOrder order);

        public IEnumerable<UserOrder> GetAll();

        public UserOrder? GetById(long id);

        public void Save();

        public void Update(UserOrder order);
    }
}

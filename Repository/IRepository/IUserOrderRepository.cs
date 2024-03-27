using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserOrderRepository
    {
        public void Add(UserOrder userOrder);

        public void Delete(UserOrder userOrder);
        public IEnumerable<UserOrder> GetAll();

        public IEnumerable<UserOrder> GetAllWith2Include(string field1, string field2);

        public IEnumerable<UserOrder> GetAllWithInclude(string field);

        public UserOrder? GetById(long id);

        public void Save();

        public void Update(UserOrder userOrder);
    }
}

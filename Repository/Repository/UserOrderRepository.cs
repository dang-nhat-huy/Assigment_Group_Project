using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserOrderRepository : IUserOrderRepository
    {
        public void Add(UserOrder userOrder) => UserOrderDAO.Instance.Add(userOrder);

        public void Delete(UserOrder userOrder) => UserOrderDAO.Instance.Delete(userOrder);
        public IEnumerable<UserOrder> GetAll() => UserOrderDAO.Instance.GetAll();

        public IEnumerable<UserOrder> GetAllWith2Include(string field1, string field2) => UserOrderDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<UserOrder> GetAllWithInclude(string field) => UserOrderDAO.Instance.GetAllWithInclude(field);

        public UserOrder? GetById(long id) => UserOrderDAO.Instance.GetById(id);

        public void Save() => UserOrderDAO.Instance.Save();

        public void Update(UserOrder userOrder) => UserOrderDAO.Instance.Update(userOrder);
    }
}

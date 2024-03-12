using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user) => UserDAO.Instance.Add(user);

        public void Delete(User user) => UserDAO.Instance.Delete(user);
        public IEnumerable<User> GetAll() => UserDAO.Instance.GetAll();

        public IEnumerable<User> GetAllWith2Include(string field1, string field2) => UserDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<User> GetAllWithInclude(string field) => UserDAO.Instance.GetAllWithInclude(field);

        public User? GetById(long id) => UserDAO.Instance.GetById(id);

        public void Save() => UserDAO.Instance.Save();

        public void Update(User user) => UserDAO.Instance.Update(user);
    }
}

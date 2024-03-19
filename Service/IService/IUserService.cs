using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();

        public IEnumerable<User> GetAll(int? page, int? quantity);

        public User? GetById(long id);
        void Add(User User);
        void Update(User User);
        void Delete(User User);
        void Save();
    }
}

using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllWithInclude(string field);
        IEnumerable<User> GetAllWith2Include(string field1, string field2);
        User? GetById(long id);
        void Add(User User);
        void Update(User User);
        void Delete(User User);
        void Save();
    }
}

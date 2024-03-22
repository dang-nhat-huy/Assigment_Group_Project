using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IStatusUserRepository
    {
        IEnumerable<StatusUser> GetAll();
        IEnumerable<StatusUser> GetAllWithInclude(string field);
        IEnumerable<StatusUser> GetAllWith2Include(string field1, string field2);
        StatusUser? GetById(long id);
        void Add(StatusUser StatusUser);
        void Update(StatusUser StatusUser);
        void Delete(StatusUser StatusUser);
        void Save();
    }
}

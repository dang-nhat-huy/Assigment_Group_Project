using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IStatusRoomRepository
    {
        IEnumerable<StatusRoom> GetAll();
        IEnumerable<StatusRoom> GetAllWithInclude(string field);
        IEnumerable<StatusRoom> GetAllWith2Include(string field1, string field2);
        StatusRoom? GetById(long id);
        void Add(StatusRoom StatusRoom);
        void Update(StatusRoom StatusRoom);
        void Delete(StatusRoom StatusRoom);
        void Save();
    }
}

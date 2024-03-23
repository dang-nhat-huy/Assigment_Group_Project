using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        IEnumerable<Room> GetAllWithInclude(string field);
        IEnumerable<Room> GetAllWith2Include(string field1, string field2);
        Room? GetById(long id);
        void Add(Room room);
        void Update(Room room);
        void Delete(Room room);
        void Save();
    }
}

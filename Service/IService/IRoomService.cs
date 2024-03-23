using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IRoomService
    {
        public void Add(Room room);

        public void Delete(Room room);

        public IEnumerable<Room> GetAll();

        public IEnumerable<Room> GetAll(int? page, int? quantity);

        public Room? GetById(long id);
        public void Save();

        public void Update(Room room);
    }
}

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
    public class RoomRepository : IRoomRepository
    {
        public void Add(Room room) => RoomDAO.Instance.Add(room);

        public void Delete(Room room) => RoomDAO.Instance.Delete(room);

        public IEnumerable<Room> GetAll() => RoomDAO.Instance.GetAll();

        public IEnumerable<Room> GetAllWith2Include(string field1, string field2) => RoomDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Room> GetAllWithInclude(string field) => RoomDAO.Instance.GetAllWithInclude(field);

        public Room? GetById(long id) => RoomDAO.Instance.GetById(id);

        public void Save() => RoomDAO.Instance.Save();

        public void Update(Room room) => RoomDAO.Instance.Update(room);
    }
}

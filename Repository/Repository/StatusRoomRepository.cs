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
    public class StatusRoomRepository : IStatusRoomRepository
    {
        public void Add(StatusRoom StatusRoom) => StatusRoomDAO.Instance.Add(StatusRoom);

        public void Delete(StatusRoom StatusRoom) => StatusRoomDAO.Instance.Delete(StatusRoom);

        public IEnumerable<StatusRoom> GetAll() => StatusRoomDAO.Instance.GetAll();

        public IEnumerable<StatusRoom> GetAllWith2Include(string field1, string field2) => StatusRoomDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<StatusRoom> GetAllWithInclude(string field) => StatusRoomDAO.Instance.GetAllWithInclude(field);

        public StatusRoom? GetById(long id) => StatusRoomDAO.Instance.GetById(id);

        public void Save() => StatusRoomDAO.Instance.Save();

        public void Update(StatusRoom StatusRoom) => StatusRoomDAO.Instance.Update(StatusRoom);
    }
}

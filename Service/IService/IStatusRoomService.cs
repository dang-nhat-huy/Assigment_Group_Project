using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IStatusRoomService
    {
        public void Add(StatusRoom status);

        public void Delete(StatusRoom status);

        public IEnumerable<StatusRoom> GetAll();

        public IEnumerable<StatusRoom> GetAll(int? page, int? quantity);

        public StatusRoom? GetById(long id);
        public void Save();

        public void Update(StatusRoom status);
    }
}

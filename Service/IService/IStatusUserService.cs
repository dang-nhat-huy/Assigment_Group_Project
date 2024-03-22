using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IStatusUserService
    {
        public void Add(StatusUser status);

        public void Delete(StatusUser status);

        public IEnumerable<StatusUser> GetAll();

        public IEnumerable<StatusUser> GetAll(int? page, int? quantity);

        public StatusUser? GetById(long id);
        public void Save();

        public void Update(StatusUser status);
    }
}

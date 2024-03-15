using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IStatusService
    {
        public void Add(Status status);

        public void Delete(Status status);

        public IEnumerable<Status> GetAll();

        public IEnumerable<Status> GetAll(int? page, int? quantity);

        public Status? GetById(long id);
        public void Save();

        public void Update(Status status);
    }
}

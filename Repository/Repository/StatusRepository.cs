using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StatusRepository : IStatusRepository
    {
        public void Add(Status status) => StatusDAO.Instance.Add(status);

        public void Delete(Status status) => StatusDAO.Instance.Delete(status);
        public IEnumerable<Status> GetAll() => StatusDAO.Instance.GetAll();

        public IEnumerable<Status> GetAllWith2Include(string field1, string field2) => StatusDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Status> GetAllWithInclude(string field) => StatusDAO.Instance.GetAllWithInclude(field);

        public Status? GetById(long id) => StatusDAO.Instance.GetById(id);

        public void Save() => StatusDAO.Instance.Save();

        public void Update(Status status) => StatusDAO.Instance.Update(status);
    }
}

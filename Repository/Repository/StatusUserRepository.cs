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
    public class StatusUserRepository : IStatusUserRepository
    {
        public void Add(StatusUser StatusUser) => StatusUserDAO.Instance.Add(StatusUser);

        public void Delete(StatusUser StatusUser) => StatusUserDAO.Instance.Delete(StatusUser);

        public IEnumerable<StatusUser> GetAll() => StatusUserDAO.Instance.GetAll();

        public IEnumerable<StatusUser> GetAllWith2Include(string field1, string field2) => StatusUserDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<StatusUser> GetAllWithInclude(string field) => StatusUserDAO.Instance.GetAllWithInclude(field);

        public StatusUser? GetById(long id) => StatusUserDAO.Instance.GetById(id);

        public void Save() => StatusUserDAO.Instance.Save();

        public void Update(StatusUser StatusUser) => StatusUserDAO.Instance.Update(StatusUser);
    }
}

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
    public class StatusOrderRepository : IStatusOrderRepository
    {
        public void Add(StatusOrder status) => StatusOrderDAO.Instance.Add(status);

        public void Delete(StatusOrder status) => StatusOrderDAO.Instance.Delete(status);
        public IEnumerable<StatusOrder> GetAll() => StatusOrderDAO.Instance.GetAll();

        public IEnumerable<StatusOrder> GetAllWith2Include(string field1, string field2) => StatusOrderDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<StatusOrder> GetAllWithInclude(string field) => StatusOrderDAO.Instance.GetAllWithInclude(field);

        public StatusOrder? GetById(long id) => StatusOrderDAO.Instance.GetById(id);

        public void Save() => StatusOrderDAO.Instance.Save();

        public void Update(StatusOrder status) => StatusOrderDAO.Instance.Update(status);
    }
}

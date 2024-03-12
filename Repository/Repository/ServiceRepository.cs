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
    public class ServiceRepository : IServiceRepository
    {
        public void Add(Service service) => ServiceDAO.Instance.Add(service);

        public void Delete(Service service) => ServiceDAO.Instance.Delete(service);
        public IEnumerable<Service> GetAll() => ServiceDAO.Instance.GetAll();

        public IEnumerable<Service> GetAllWith2Include(string field1, string field2) => ServiceDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Service> GetAllWithInclude(string field) => ServiceDAO.Instance.GetAllWithInclude(field);

        public Service? GetById(long id) => ServiceDAO.Instance.GetById(id);

        public void Save() => ServiceDAO.Instance.Save();

        public void Update(Service service) => ServiceDAO.Instance.Update(service);
    }
}

using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services = BusinessObject.Models.Service;

namespace Service.IService
{
    public interface IServicesService
    {
        public void Add(Services services);

        public void Delete(Services services);

        public IEnumerable<Services> GetAll();

        public IEnumerable<Services> GetAll(int? page, int? quantity);

        public Services? GetById(long id);

        public void Save();

        public void Update(Services services);
    }
}

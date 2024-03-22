using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IStatusOrderService
    {
        public void Add(StatusOrder status);

        public void Delete(StatusOrder status);

        public IEnumerable<StatusOrder> GetAll();

        public IEnumerable<StatusOrder> GetAll(int? page, int? quantity);

        public StatusOrder? GetById(long id);
        public void Save();

        public void Update(StatusOrder status);
    }
}

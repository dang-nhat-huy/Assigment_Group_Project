using BusinessObject.Models;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public void Add(Status status)
        {
            _statusRepository.Add(status);
        }

        public void Delete(Status status)
        {
            _statusRepository.Delete(status);
        }

        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }

        public IEnumerable<Status> GetAll(int? page, int? quantity)
        {
            const int defaultPage = 1;
            const int defaultQuantity = 10;

            if (page.HasValue && page <= 0)
            {
                page = defaultPage;
            }
            if (quantity.HasValue && (quantity <= 0 || quantity > int.MaxValue))
            {
                quantity = defaultQuantity;
            }

            int skip = (page.GetValueOrDefault(defaultPage) - 1) * quantity.GetValueOrDefault(defaultQuantity);
            return _statusRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public Status? GetById(long id)
        {
            return _statusRepository.GetById(id);
        }

        public void Save()
        {
            _statusRepository.Save();
        }

        public void Update(Status status)
        {
            _statusRepository.Update(status);
        }
    }
}

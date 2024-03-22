using BusinessObject.Models;
using Repository;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StatusUserService : IStatusUserService
    {
        private readonly IStatusUserRepository _statusUserRepository;
        public StatusUserService(IStatusUserRepository statusUserRepository)
        {
            _statusUserRepository = statusUserRepository;
        }

        public void Add(StatusUser status)
        {
            _statusUserRepository.Add(status);
        }

        public void Delete(StatusUser status)
        {
            _statusUserRepository?.Delete(status);
        }

        public IEnumerable<StatusUser> GetAll()
        {
            return _statusUserRepository.GetAll();
        }

        public IEnumerable<StatusUser> GetAll(int? page, int? quantity)
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
            return _statusUserRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public StatusUser? GetById(long id)
        {
            return _statusUserRepository.GetById(id);
        }

        public void Save()
        {
            _statusUserRepository.Save();
        }

        public void Update(StatusUser status)
        {
            _statusUserRepository.Update(status);
        }
    }
}

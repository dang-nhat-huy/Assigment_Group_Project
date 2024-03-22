using BusinessObject.Models;
using Repository;
using Repository.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StatusRoomService : IStatusRoomService
    {
        private readonly IStatusRoomRepository _statusRoomRepository;
        public StatusRoomService(IStatusRoomRepository statusRoomRepository)
        {
            _statusRoomRepository = statusRoomRepository;
        }

        public void Add(StatusRoom status)
        {
            _statusRoomRepository.Add(status);
        }

        public void Delete(StatusRoom status)
        {
            _statusRoomRepository.Delete(status);
        }

        public IEnumerable<StatusRoom> GetAll()
        {
            return _statusRoomRepository.GetAll();
        }

        public IEnumerable<StatusRoom> GetAll(int? page, int? quantity)
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
            return _statusRoomRepository.GetAll()
                .Skip(skip)
                .Take((int)quantity!);
        }

        public StatusRoom? GetById(long id)
        {
            return _statusRoomRepository.GetById(id);
        }

        public void Save()
        {
            _statusRoomRepository.Save();
        }

        public void Update(StatusRoom status)
        {
            _statusRoomRepository.Update(status);
        }
    }
}

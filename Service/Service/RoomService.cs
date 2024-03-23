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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public void Add(Room room)
        {
            _roomRepository.Add(room);
        }

        public void Delete(Room room)
        {
            _roomRepository.Delete(room);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAllWithInclude("StatusRoom");
        }

        public IEnumerable<Room> GetAll(int? page, int? quantity)
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
            return _roomRepository.GetAllWithInclude("StatusRoom")
                .Skip(skip)
                .Take((int)quantity!);
        }

        public Room? GetById(long id)
        {
            return _roomRepository.GetById(id);
        }

        public void Save()
        {
            _roomRepository.Save();
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }
    }
}

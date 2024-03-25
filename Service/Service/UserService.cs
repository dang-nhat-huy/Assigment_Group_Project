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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User User)
        {
            _userRepository.Add(User);
        }

        public void Delete(User User)
        {
            _userRepository.Delete(User);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAll(int? page, int? quantity)
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
            return _userRepository.GetAllWithInclude("StatusUser")
                .Skip(skip)
                .Take((int)quantity!);
        }

        public User? GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public void Save()
        {
            _userRepository.Save();
        }

        public IEnumerable<User> SearchByEmail(string email, int? page, int? quantity)
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
            return _userRepository.GetAllWithInclude("StatusUser")
                .Where(x => x.Email!.Contains(email))
                .Skip(skip)
                .Take((int)quantity!);
        }

        public void Update(User User)
        {
            _userRepository.Update(User);
        }
    }
}

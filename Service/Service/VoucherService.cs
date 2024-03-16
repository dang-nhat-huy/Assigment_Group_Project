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
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucher;
        public VoucherService(IVoucherRepository voucher)
        {
            _voucher = voucher;
        }
        public void Add(Voucher Voucher)
        {
            _voucher.Add(Voucher);
        }

        public void Delete(Voucher Voucher)
        {
            _voucher.Delete(Voucher);//throw new NotImplementedException();
        }

        public IEnumerable<Voucher> GetAll(int? page, int? quantity)
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
            return _voucher.GetAll()
                .Skip(skip)
                .Take((int)quantity!);//throw new NotImplementedException();
        }

        public IEnumerable<Voucher> GetAll()
        {
            return _voucher.GetAll(); //throw new NotImplementedException();
        }

        public Voucher? GetById(long id)
        {
           return _voucher.GetById(id); //throw new NotImplementedException();
        }

        public void Save()
        {
            _voucher.Save();//throw new NotImplementedException();
        }

        public void Update(Voucher Voucher)
        {
            /_voucher.Update(Voucher)//throw new NotImplementedException();
        }
    }
}

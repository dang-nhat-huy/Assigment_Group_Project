using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IVoucherService
    {
        IEnumerable<Voucher> GetAll(int? page, int? quantity);
        IEnumerable<Voucher> GetAll();
        Voucher? GetById(long id);
        Voucher AddVoucher(Voucher Voucher);
        void Update(Voucher Voucher);
        void Delete(Voucher Voucher);
        void Save();
    }
}

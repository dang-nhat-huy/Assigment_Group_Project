using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IVoucherRepository
    {
        IEnumerable<Voucher> GetAll();
        IEnumerable<Voucher> GetAllWithInclude(string field);
        IEnumerable<Voucher> GetAllWith2Include(string field1, string field2);
        Voucher? GetById(long id);
        void Add(Voucher Voucher);
        void Update(Voucher Voucher);
        void Delete(Voucher Voucher);
        void Save();
    }
}

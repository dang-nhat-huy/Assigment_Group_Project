using BusinessObject.Models;
using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        public void Add(Voucher voucher) => VoucherDAO.Instance.Add(voucher);

        public void Delete(Voucher voucher) => VoucherDAO.Instance.Delete(voucher);
        public IEnumerable<Voucher> GetAll() => VoucherDAO.Instance.GetAll();

        public IEnumerable<Voucher> GetAllWith2Include(string field1, string field2) => VoucherDAO.Instance.GetAllWith2Include(field1, field2);

        public IEnumerable<Voucher> GetAllWithInclude(string field) => VoucherDAO.Instance.GetAllWithInclude(field);

        public Voucher? GetById(long id) => VoucherDAO.Instance.GetById(id);

        public void Save() => VoucherDAO.Instance.Save();

        public void Update(Voucher voucher) => VoucherDAO.Instance.Update(voucher);
    }
}

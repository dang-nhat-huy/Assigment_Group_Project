using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Repository.IRepository;
using Service.IService;
using Service.ReponseModel;
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
        public Voucher AddVoucher(Voucher Voucher)
        {
            var listV = _voucher.GetAll();
            var checkDuplicateCode = listV.FirstOrDefault(x => x.Code == Voucher.Code);

            if (!(checkDuplicateCode == null))
            {
                return null;
            }
            else if (Voucher.ExpireDate <= DateTime.Now)
            {
                return null;
            }

            _voucher.Add(Voucher);
            return Voucher;
        }


        public void Delete(Voucher Voucher)
        {
            _voucher.Delete(Voucher);
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
                .Take((int)quantity!);
        }

        public IEnumerable<Voucher> GetAll()
        {
            return _voucher.GetAll();
        }

        public Voucher? GetById(long id)
        {
            return _voucher.GetById(id);
        }

        public void Save()
        {
            _voucher.Save();
        }

        public Voucher Update(Voucher Voucher)
        {
            var listVoucher = _voucher.GetAll();
            var checkDuplicateCodeinListVoucher = listVoucher.Where(x => x.Code == Voucher.Code).ToList();
            int varcheck = 0;
            foreach (var V in checkDuplicateCodeinListVoucher)
            {
                if (Voucher.Code == V.Code && Voucher.VoucherId != V.VoucherId)
                {
                    varcheck += 1;
                }
            }
            if (varcheck > 0)
            {
                return null;
            }
            _voucher.Update(Voucher);
            _voucher.Save();
            return Voucher;
        }
    }
}

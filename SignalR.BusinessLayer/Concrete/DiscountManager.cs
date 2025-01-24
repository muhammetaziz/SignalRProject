using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    
    public class DiscountManager : IDiscountDal
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void Add(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void Delete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount GetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> GetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void Update(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}

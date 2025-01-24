using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureDal
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void Add(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public void Delete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public Feature GetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public List<Feature> GetListAll()
        {
            return _featureDal.GetListAll();
        }

        public void Update(Feature entity)
        {
            _featureDal.Update(entity); 
        }
    }
}

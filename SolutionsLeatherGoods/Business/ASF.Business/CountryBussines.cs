using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CountryBusiness : AuditBusiness
    {
       
        public Country Add(Country Country)
        {
            var CountryDac = new CountryDAC();
            Country.CreatedBy = CreatedBy;
            Country.CreatedOn = CreatedOn;
            Country.ChangedBy = ChangedBy;
            Country.ChangedOn = ChangedOn;
            return CountryDac.Create(Country);
        }

       
        public void Remove(int id)
        {
            var CountryDac = new CountryDAC();
            CountryDac.DeleteById(id);
        }

       
        public List<Country> All()
        {
            var CountryDac = new CountryDAC();
            var result = CountryDac.Select();
            return result;
        }

       
        public Country Find(int id)
        {
            var CountryDac = new CountryDAC();
            var result = CountryDac.SelectById(id);
            return result;
        }

     
        public void Edit(Country Country)
        {
            var CountryDac = new CountryDAC();
            CountryDac.UpdateById(Country);
        }
    }
}

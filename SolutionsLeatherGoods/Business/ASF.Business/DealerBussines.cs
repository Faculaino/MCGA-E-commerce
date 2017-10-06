using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class DealerBussines 
    {
        public List<Dealer> lista()
        {
            var dDAC = new DealerDAC();
            return dDAC.Lista();
        }

        public void Add(Dealer dealer)
        {
            var dDAC = new DealerDAC();
            dDAC.Insert(dealer);
        }
    }
}

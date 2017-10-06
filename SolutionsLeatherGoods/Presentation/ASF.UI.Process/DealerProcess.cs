using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASF.UI.Process
{
    public class DealerProcess : ProcessComponent
    {
        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultDealer;
        }

        public void InsertDealer(Dealer dealer)
        {
            HttpPost<Dealer>("rest/Dealer/Add", dealer, MediaType.Json);
        }
    }
}

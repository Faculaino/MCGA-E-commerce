using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Dealer")]
    public class DealerService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllResponse All()
        {
            try
            {
                var response = new AllResponse();
                var bc = new DealerBussines();
                response.ResultDealer = bc.lista();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Add")]
        public void Add(Dealer dealer)
        {
            try
            {
                var bc = new DealerBussines();
                bc.Add(dealer);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

    }
}

using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public List<Product> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultProduct;
        }

        public void insertProduct(Product product)
        {
            ProcessComponent.HttpPost<Product>("rest/Product/Add", product, MediaType.Json);
        }
        public Product findProduct(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/Product/Find", dic, MediaType.Json);
            return response.ResultProduct;

        }

        public void editProduct(Product product)
        {
            ProcessComponent.HttpPost<Product>("rest/Product/Edit", product, MediaType.Json);
        }

        public void deleteProduct(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<Product>("rest/Product/Remove/{id}", dic, MediaType.Json);
        }
    }
}
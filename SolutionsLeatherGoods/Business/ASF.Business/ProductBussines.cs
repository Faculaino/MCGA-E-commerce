using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class ProductBusiness
    {
        public Product Add(Product product)
        {
            var productDac = new ProductDAC();
            return productDac.Create(product);
        }

        public void Remove(int id)
        {
            var productDac = new ProductDAC();
            productDac.DeleteById(id);
        }

        public List<Product> All()
        {
            var productDac = new ProductDAC();
            var result = productDac.Select();
            return result;
        }

        public Product Find(int id)
        {
            var productDac = new ProductDAC();
            var result = productDac.SelectById(id);
            return result;
        }

        public void Edit(Product product)
        {
            var productDac = new ProductDAC();
            productDac.UpdateById(product);
        }
    }
}